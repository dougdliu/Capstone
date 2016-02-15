#include "mraa.h"
#include <stdio.h>
#include <stdlib.h>

int main() {
	/* Setup your example here, code that should run once
	 */

	int i;						// Generic Iterator
	mraa_spi_context spi; 			// Set SPI variable
	spi = mraa_spi_init(1);			// Initialize SPI

	if(spi == NULL)
	{
		printf("Initialization of SPI Failed");
		exit(1);
	}

	printf("SPI Initialized Successfully\n");

	mraa_spi_mode(spi, MRAA_SPI_MODE1);				// Set SPI mode = 1, CPOL = 0, CPHA = 1
	mraa_spi_frequency(spi, 20000000);				// Set SPI frequency = 20MHz
	mraa_spi_lsbmode(spi, 0);						// Set to MSBFIRST
	mraa_spi_bit_per_word(spi, 16);					// Set bit per word to be 16 bits

	mraa_spi_write_word(spi, 0x1802);				// Enable update of digipot wiper position
	mraa_spi_write_word(spi, 0x0400);				// Set digipot to 1/4th of its value

	/* Code in this loop will run repeatedly
	 */
	for (i = 0; i < 1024; i++)
	{
		usleep(100000);
		mraa_spi_write_word(spi, 0x0500);				// Set digipot to 1/4th of its value
	}
	mraa_spi_stop(spi);

	return 0;
}
