#include "mraa.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

int main(int argc, char** argv)
{


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
		memset(initialBuffer[i], '\0', sizeof(initialBuffer[i]));

	// This loop checks for a handshake //
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

		// Checks if the buffer is received is received
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
