//SerialComTest.c
/*
		This file is used by the Edison to commmunicate with the software serially through UART.
		It goes through 4 stages, connection initialization, handhsake, data reception, and data transmission.
		As written, this code will transmit dummy data to the software to simulate the phase change and voltage gain
		values teh EIS module would produce.
*/


#include "mraa.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

int main(int argc, char** argv)
{

	// initialization		//
	/*		Using the mraa_uart_context, the baudrate is set to 115200 bps, the frame size to 8 bits, and
			and odd parity is started with 1 stop bit. */

	mraa_uart_context uart;						// UART context
	int i, ret;									// Generic iterator and error return
	uart = mraa_uart_init_raw("/dev/ttyGS0");	// Initialize USB Serial Communication
	if (uart < 0)
	{
		fprintf(stderr, "UART failed to setup");
		return EXIT_FAILURE;
	}

	ret = mraa_uart_set_baudrate(uart, 115200);		// Baudrate = 115200 bps
	mraa_uart_set_mode(uart, 8, 2, 1);			// 8 bits per frame, odd parity, 1 stop bit

	if (uart == NULL) {

		fprintf(stderr, "UART failed to setup\n");
		return EXIT_FAILURE;
	}

	char Handshake[3];			// Handshake buffer to receive the Handshake //
	char c;
	char initialBuffer[6][10];	// Buffer for initialization in string
	float translatedBuffer[6];	// Buffer for translated initialization values

	memset(Handshake, '\0', sizeof(Handshake));
	for (i = 0; i < 6; i++)
		memset(initialBuffer[i], '\0', sizeof(initialBuffer[i]));	//Fills the buffer with null terminaters

	// This loop checks for a handshake //
	/* Expects to recieve a string "HI" from the serial connection.
			Upon such reception, a reply is sent back "HIU" */
	for (;;)
	{
		ret = mraa_uart_read(uart, Handshake, sizeof(Handshake));
		if (ret < 0)
		{
			fprintf(stderr, "UART failed to read");
			return EXIT_FAILURE;
		}
		//printf("%s\n", Handshake);				// Print Handshake buffer for debug purposes

		// Checks if the Handshake is received
		// If so, then send an acknowledgment back to the computer
		if (strcmp(Handshake, "HI") == 0)
		{
			sprintf(Handshake, "%s%s", Handshake, "U");
			mraa_uart_write(uart, Handshake, sizeof(Handshake));	// Acknowledges the Handshake sent from the computer
			mraa_uart_flush(uart);
			break;
		}
	}

	// This loop will read data from the device //
	/* Expects to read in from the serial connect 6 times, the size of
			the initlialBuffer array. The strings read in are stored into
			this array. These will be the values for Starting and Ending Frequency,
			Sweep Rate, Voltage Offset, Voltage Amplitutde, and whether to operate
			on linear or exponetial mode.

			Replies to the serial connection with a "Y" upon succesful reception
			and storage.

			Breaks after the 6 reception.
				*/
	i = 0;
	for (;;)
	{
		ret = mraa_uart_read(uart, initialBuffer[i], sizeof(initialBuffer[i]));
		if (ret < 0)
		{
			fprintf(stderr, "UART failed to read");
			return EXIT_FAILURE;
		}
		//printf("%s\n", initialBuffer[i]);				// Print initial buffer incoming data for debug purposes

		// Checks if the buffer is received
		// If so, then send an acknowledgment back to the computer
		sprintf(&c, "%d", i);
		if (strncmp(initialBuffer[i], &c, 1) == 0)
		{
			mraa_uart_write(uart, "Y", 1);	// Acknowledges the Handshake sent from the computer
			mraa_uart_flush(uart);
			i++;
			if (i == 6)
				break;
		}
	}

	// Debug print to see if received float is indeed the float that we want //
	//	for(i = 0; i < 6; i++)
	//	{
	//		translatedBuffer[i] = atof(initialBuffer[i]+1);
	//		printf("%f\n", translatedBuffer[i]);
	//	}


	// This loop will send data back to computer periodically until 'E' is sent //
	/* This portion currently generates randomly seeded data to be sent to simulate
	  	the frequency, phase change, and voltage gain values that EIS module will
			be producing.

			Does not send data until the Serial Com is ready to recieve. This is denoted
			by recieving a 'N'. The Edison will continuing reading from the Serial
			port until a read 'N' is recieved. Then will send out a randomly generated
			triplet of float values.

			The Software on the otherside of the Serial connection expects an "E" to
			stop listening to the Serial connection.*/
	i = 0;
	srand((unsigned int)time(NULL));	// Seed for random number generator
	float num = 4.0;
	float rng[3];
	int ack = 1;
	char random[45];
	memset(random, '\0', sizeof(random));
	for (;;)
	{
		// Generate a random float //
		ret = mraa_uart_read(uart, &c, 1);
		if (ret < 0)
		{
			fprintf(stderr, "UART failed to read");
			return EXIT_FAILURE;
		}
		if (c == 'N'){ continue; }
		if (ack == 1)
		{
			rng[0] = (((float)rand()) / ((float)(RAND_MAX))*num);
			rng[1] = (((float)rand()) / ((float)(RAND_MAX))*num);
			rng[2] = (((float)rand()) / ((float)(RAND_MAX))*num);
			//			rng[0] = (float)i;
			//			rng[1] = (float)i;
			//			rng[2] = (float)i;
			sprintf(random, "%f,%f,%f", rng[0], rng[1], rng[2]);
			printf("%s\n", random);
			ret = mraa_uart_write(uart, random, sizeof(random));
			mraa_uart_flush(uart);
			i++;
		}
		ret = mraa_uart_read(uart, &c, 1);
		if (ret < 0)
		{
			fprintf(stderr, "UART failed to read");
			return EXIT_FAILURE;
		}
		if (i == 100)
		{
			mraa_uart_write(uart, "E", 1);	// Call to finish sending data to computer
			mraa_uart_flush(uart);
			break;
		}
	}

	mraa_uart_stop(uart);	// Stops the Serial Port
	mraa_deinit();			// De-Initialize Stuff
	return EXIT_SUCCESS;	// Returns the program
}
