#include "mraa.h"
int
main(int argc, char** argv)
{
    mraa_uart_context uart;						// UART context
    int i;										// Generic iterator
    uart = mraa_uart_init_raw("/dev/ttyGS0");	// Initialize USB Serial Communication
    if (uart == NULL) {
        fprintf(stderr, "UART failed to setup\n");
        return EXIT_FAILURE;
    }
    char buffer[] = "Hello Mraa!";				// Test buffer to send to

    for(i = 0; i < 10000; i++)
    {
    	mraa_uart_write(uart, buffer, sizeof(buffer));	// Writes to USB Serial port
    }

    mraa_uart_stop(uart);	// Stops the Serial Port
    mraa_deinit();			// De-Initialize Stuff
    return EXIT_SUCCESS;	// Returns the program
}
