/*
 * Made for Capstone Project for MFC Systems Fall 2015-Spring 2016
 * Communications Version 1
 * Developed By: Alexander Enriquez
 */

using System;
using System.IO.Ports;  // For Serial Communication //
using System.Threading; // For sleep() //

public class Communications
{
    private SerialPort serial;
    private bool tryAgain;
    public string output;

	public Communications()
	{
        // Initialization of Serial Communication Interfaces //
        serial = new SerialPort();
        serial.BaudRate = 115200;
        serial.DataBits = 8;
        serial.StopBits = StopBits.One;
        serial.ReadTimeout = 50;
        serial.WriteTimeout = 50;
        serial.DtrEnable = true;
        serial.RtsEnable = true;
        serial.Parity = Parity.Odd;
        serial.Encoding = System.Text.Encoding.GetEncoding(1252);
        string[] port = SerialPort.GetPortNames();
        serial.PortName = port[0];
        tryAgain = false;
        output = "";

	}

// Used to intitiate communication with the micontroller with the EIS module
//
    public bool HandShake(string hndShk)
    {
        byte[] hsResp = new byte[3];
        bool tryAgain = true;
        string[] port = SerialPort.GetPortNames();

        while (true)
        {
            serial.Open();
            while (tryAgain)
            {
                try
                {
                    serial.Write(hndShk);
                }
                catch (TimeoutException)
                {
                    Console.WriteLine("Write timeout occured");
                }
                Thread.Sleep(100);
                try
                {
                    serial.Read(hsResp, 0, 3);
                    tryAgain = false;
                }
                catch (TimeoutException)
                {
                    //Console.WriteLine("Read timeout occured");
                }
            }
            string message = System.Text.Encoding.ASCII.GetString(hsResp);
            //Console.WriteLine(message);
            serial.Close();
            if (message.CompareTo("HIU") == 0)
                return true;
            return false;
        }
    }

    // Used to send data to the microcontroller.
    // Initially, for transmitting user specified values
    // i.e. Sweep rate, starting and ending frequency, voltage input, DC OFFST, linear vs logarithmic
    public bool Transmit(string dataOut)
    {
        byte[] resp = new byte[1];
        bool tryAgain = true;
        serial.Open();
        while (tryAgain)
        {
          // Attempt to send data
            try
            {
                serial.Write(dataOut);
            }
            // Timeout if the data fails to send
            catch (TimeoutException)
            {
                Console.WriteLine("Write timeout occured");
            }
            Thread.Sleep(100);
            // Wait for acknowledgment from microcontroller in the form of "Y"
            try
            {
                serial.Read(resp, 0, 1);
                if (System.Text.Encoding.ASCII.GetString(resp).CompareTo("Y") == 0)
                    tryAgain = false;
                //else
                //    return false;           //Edison Failed to acknowledge
            }
            catch (TimeoutException)
            {
                //Console.WriteLine("Read timeout occured");
                //Should add a counter under the conditions of continual failure
                //Currently at risk of an inifite loop
            }
        }
        serial.Close();
        return true;
    }


    // Used to read in data from the micrcontroller
    // Sends in an inital dummy data to begin, "N"
    // Stores the string value calculated into output data member of Communications.
    public void ReadIn()
    {
        byte[] dataIn = new byte[45];
        bool tryAgain = true;
        while (true)
        {
            serial.Open();

            /* Dummy Write */
            try
            {
                serial.Write("N");
            }
            catch (TimeoutException)
            {
                serial.Close();
                continue;
            }

            /* Value Read In */
            while (tryAgain)
            {
                Thread.Sleep(10);
                try
                {
                    serial.Read(dataIn, 0, 45);
                    tryAgain = false;
                }
                catch (TimeoutException)
                {
                    //Console.WriteLine("Read timeout occured");
                }
                Thread.Sleep(10);
                try
                {
                    serial.Write("Y");      //Acknowledement
                }
                catch (TimeoutException)
                {
                    //Console.WriteLine("Write timeout occured");
                }
            }
            string message = System.Text.Encoding.ASCII.GetString(dataIn);
            serial.Close();
            output= message; //float.Parse(message);
        }
    }
}
