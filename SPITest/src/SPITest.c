#include "mraa.h"
#include <stdio.h>
#include <stdlib.h>

volatile uint64_t start;
volatile uint64_t diff;

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

void pulseWidthIntHandlerPos(void *pin)
{
	start = rdtsc();
	//printf("%d\n", (int)diff);
}

void pulseWidthIntHandlerNeg(void *pin)
{
	diff = rdtsc() - start;
	//printf("%d\n", (int)start);
}

int main() {
	/* Setup your example here, code that should run once
	 */
	int i;							// Generic Iterator
	mraa_spi_context spi; 			// Set SPI variable
	mraa_gpio_context pin2;		// Set up interrupt pin as IO2
	mraa_gpio_context pin3;		// Set up interrupt pin as IO2
	spi = mraa_spi_init(1);			// Initialize SPI

	if(spi == NULL)
	{
		printf("Initialization of SPI Failed");
		exit(1);
	}

	printf("SPI Initialized Successfully\n");

	// Initialize Interrupt Handler
	pin2 = mraa_gpio_init(2);
	pin3 = mraa_gpio_init(3);
	mraa_gpio_dir(pin2, MRAA_GPIO_IN);
	mraa_gpio_dir(pin3, MRAA_GPIO_IN);
	mraa_gpio_isr(pin2, MRAA_GPIO_EDGE_RISING, &pulseWidthIntHandlerPos, pin2);
	mraa_gpio_isr(pin3, MRAA_GPIO_EDGE_FALLING, &pulseWidthIntHandlerNeg, pin3);

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
		printf("%llu\n", diff);
		mraa_spi_write_word(spi, 0x0450);				// Set digipot to 1/4th of its value
	}
	mraa_spi_stop(spi);

	return 0;
}
