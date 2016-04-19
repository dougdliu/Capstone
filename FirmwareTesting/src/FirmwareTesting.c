// FirmwareTesting.c       //
/*  This program test several components integral to the operation of the EIS device
    associated with the Edison Microctronller: Phase Change Calculation, Voltage Gain
    acquisiton, and Data Reception, Pontitometer Sweeping and Data Transmission
*/


#include "mraa.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include <pthread.h>
#include <math.h>

#define ALPHA 0.3f
#define THOUSAND 1000L
#define FINALSTEP 1018L
pthread_t sendData;					// Global sendData handler thread
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;	// Pthread mutex
mraa_uart_context uart;					// uart context
int stepSize;

/*
 * This will calculate the phase change of the signal using an interrupt handler.
 */
volatile uint64_t diff, start, oldV = 0, newV = 0;
volatile uint64_t start, counter;

inline uint64_t rdtsc() {
    uint32_t lo, hi;
    __asm__ __volatile__ (
      "xorl %%eax, %%eax\n"
      "cpuid\n"
      "rdtsc\n"
      : "=a" (lo), "=d" (hi)
      :
      : "%ebx", "%ecx");
    return (uint64_t)hi << 32 | lo;
}


//  SendData Hanlder  //
/*		Does not send data until the Serial Com is ready to receive. This is denoted
			by receiving a 'N' from the com. The Edison will continuing reading from the Serial
			port until a read 'N' is received. Then will send out generated values for frequency,
      gain, and phase shift.

			The Software on the otherside of the Serial connection expects an "E" to
			stop listening to the Serial connection.
*/
void *sendDataHandler(void *arg)
{
	// This thread will send data back to computer periodically until 'E' is sent //
	mraa_aio_context adc;		// Corresponds to A0 on Arduino breakout board
	int ret = 0;
	int ack = 1;
	char c;
	char data[45];
	double dataPoints[3];
	double frequency, resistance, gain, phaseShift;
	uint64_t pTime = *(uint64_t*)arg;

	// Initialize ADC to read gain
	adc = mraa_aio_init(0);

	memset(data, '\0', sizeof(data));

	// Grab the frequency of the data //
	pthread_mutex_lock(&mutex);
	resistance = (((stepSize + 0x406) / 1024) * 50000);
	pthread_mutex_unlock(&mutex);
	frequency = 2 * M_PI * resistance * pow(10.0, -9.0);

	// Grab the gain of the data //
	gain = (double)mraa_aio_read_float(adc);

	// Grab the phase shift of data //
	phaseShift = ((int)pTime*2) / THOUSAND; 		// Convert cycles to nanosecond time
	phaseShift = (frequency * phaseShift) * 360;

  // Data Transmit Out Loop//
	for (;;)
	{
		ret = mraa_uart_read(uart, &c, 1);
		if (ret < 0)
		{
			fprintf(stderr, "UART failed to read");
			break;
		}
		if (c == 'N'){ continue; }
		if (ack == 1)
		{
			dataPoints[0] = frequency;
			dataPoints[1] = gain;
			dataPoints[2] = phaseShift;

			sprintf(data, "%.5lf,%.5lf,%.5lf", dataPoints[0], dataPoints[1], dataPoints[2]);
			printf("%s\n", data);
			mraa_uart_write(uart, data, sizeof(data));
			mraa_uart_flush(uart);
		}
		ret = mraa_uart_read(uart, &c, 1);
		if (ret < 0)
		{
			fprintf(stderr, "UART failed to read");
			break;
		}
		pthread_mutex_lock(&mutex);
		if (stepSize == FINALSTEP)
		{
			mraa_uart_write(uart, "E", 1);	// Call to finish sending data to computer
			mraa_uart_flush(uart);
			mraa_uart_stop(uart);	// Stops the Serial Port
			break;
		}
		else
			break;
		pthread_mutex_unlock(&mutex);
	}
	return 0;
}


//Takes a time measurement, called on a positive edge trigger
void pulseWidthIntHandlerPos(void *pin)
{
	start = rdtsc();
	//printf("%d\n", (int)diff);
}


//Calculates time between previous postive edge trigger
void pulseWidthIntHandlerNeg(void *pin)
{
	uint64_t tempT = 0;			// Temporary Time for sending stuff

	diff = rdtsc() - start;
	if(oldV = 0)
	{
		oldV = diff;
	}
	newV = oldV + ALPHA*(diff - oldV);
	counter++;
	if(counter == 25)
	{
		tempT = newV;
		newV = oldV = 0;
		pthread_create(&sendData, NULL, &sendDataHandler, &tempT);	// Create a thread to send the data back to software
		counter = 0; // Reset counter
	}
	//printf("%d\n", (int)start);
}

// main//
/* Initialize UART, SPI, the TransmitOut interrupt handler, handshake, Initial Read in,
      and Pontiostat set up and running*/
int main(int argc, char** argv)
{
	mraa_uart_context uart;			// UART context
	mraa_spi_context spi; 			// Set SPI variable
	mraa_gpio_context pin2, pin3;	// Set up interrupt pin as IO2
	int i, ret;						// Generic iterator and error return
	char Handshake[3];				// Handshake buffer to receive the Handshake //
	char c;
	char initialBuffer[6][10];		// Buffer for initialization in string
	//float translatedBuffer[6];		// Buffer for translated initialization values

	// Initialize UART //
	uart = mraa_uart_init_raw("/dev/ttyGS0");	// Initialize USB Serial Communication
	if(uart < 0)
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

	// Initialize SPI
	spi = mraa_spi_init(1);					// Initialize SPI
	mraa_spi_mode(spi, MRAA_SPI_MODE1);		// Set SPI mode = 1, CPOL = 0, CPHA = 1
	mraa_spi_frequency(spi, 20000000);		// Set SPI frequency = 20MHz
	mraa_spi_lsbmode(spi, 0);				// Set to MSBFIRST
	mraa_spi_bit_per_word(spi, 16);			// Set bit per word to be 16 bits

	// Initialize Interrupt Handler
	pin2 = mraa_gpio_init(2);
	pin3 = mraa_gpio_init(3);
	mraa_gpio_dir(pin2, MRAA_GPIO_IN);
	mraa_gpio_dir(pin3, MRAA_GPIO_IN);
	mraa_gpio_isr(pin2, MRAA_GPIO_EDGE_RISING, &pulseWidthIntHandlerPos, pin2);
	mraa_gpio_isr(pin3, MRAA_GPIO_EDGE_FALLING, &pulseWidthIntHandlerNeg, pin3);

  // Wait for Handshake //
  /* Expects to recieve a string "HI" from the serial connection.
      Upon such reception, a reply is sent back "HIU" */
	for(;;)
	{
		memset(Handshake, '\0', sizeof(Handshake));
		for(i = 0; i < 6; i++)
			memset(initialBuffer[i], '\0', sizeof(initialBuffer[i]));

		// This loop checks for a handshake //
		for(;;)
		{
			ret = mraa_uart_read(uart, Handshake, sizeof(Handshake));
			if(ret < 0)
			{
				fprintf(stderr, "UART failed to read");
				return EXIT_FAILURE;
			}
			//printf("%s\n", Handshake);				// Print Handshake buffer for debug purposes

			// Checks if the Handshake is received
			// If so, then send an acknowledgment back to the computer
			if(strcmp(Handshake, "HI") == 0)
			{
				sprintf(Handshake, "%s%s", Handshake, "U");
				mraa_uart_write(uart, Handshake, sizeof(Handshake));	// Acknowledges the Handshake sent from the computer
				mraa_uart_flush(uart);
				break;
			}
		}

    // This loop will read data from the device for EIS Test Initialization //
    /* Expects to read in from the serial connect 6 times, the size of
        the initlialBuffer array. The strings read in are stored into
        this array. These will be the values for Starting and Ending Frequency,
        Sweep Rate, Voltage Offset, Voltage Amplitude, and whether to operate
        on linear or exponential mode.

        Replies to the serial connection with a "Y" upon successful reception
        and storage.

        Breaks after the sixth storage reception.
    */
		i = 0;
		for(;;)
		{
			ret = mraa_uart_read(uart, initialBuffer[i], sizeof(initialBuffer[i]));
			if(ret < 0)
			{
				fprintf(stderr, "UART failed to read");
				return EXIT_FAILURE;
			}
			//printf("%s\n", initialBuffer[i]);				// Print initial buffer incoming data for debug purposes

			// Checks if the buffer is received is received
			// If so, then send an acknowledgment back to the computer
			sprintf(&c, "%d", i);
			if(strncmp(initialBuffer[i], &c, 1) == 0)
			{
				mraa_uart_write(uart, "Y", 1);	// Acknowledges the Handshake sent from the computer
				mraa_uart_flush(uart);
				i++;
				if(i == 6)
					break;
			}
		}

		// Setup SPI Potentiometer
		mraa_spi_write_word(spi, 0x1802);				// Enable update of digipot wiper position
		mraa_spi_write_word(spi, 0x0400);				// Set digipot to 1/4th of its value

    //Pontentiometer Sweep
		for (stepSize = 0; stepSize < FINALSTEP; stepSize++)
		{
			usleep(100000);
			mraa_spi_write_word(spi, 0x0406 + stepSize);				// Set digipot to 1/4th of its value
		}
		mraa_spi_stop(spi);

		// Debug print to see if received float is indeed the float that we want //
	//	for(i = 0; i < 6; i++)
	//	{
	//		translatedBuffer[i] = atof(initialBuffer[i]+1);
	//		printf("%f\n", translatedBuffer[i]);
	//	}

		mraa_uart_stop(uart);	// Stops the Serial Port
	}
	mraa_deinit();			// De-Initialize Stuff
	return EXIT_SUCCESS;	// Returns the program
}
