using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports; // For Serial objects

namespace SerialReadWriteTest
{
    class Program
    {


        // Handshake Method //
        static bool HandShake(SerialPort serial, string hndShk, byte[] hsResp)
        {
            bool tryAgain = true;
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
                        continue;
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

        // SendData Method //
        static bool Transmit(SerialPort serial, string dataOut, byte[] resp)
        {
            bool tryAgain = true;
            serial.Open();
            while (tryAgain)
            {
                try
                {
                    serial.Write(dataOut);
                }
                catch (TimeoutException)
                {
                    Console.WriteLine("Write timeout occured");
                    continue;
                }
                Thread.Sleep(100);
                try
                {
                    serial.Read(resp, 0, 1);
                    if(System.Text.Encoding.ASCII.GetString(resp).CompareTo("Y") == 0)
                        tryAgain = false;
                    //else
                    //    return false;           //Edison Failed to acknowledge

                }
                catch (TimeoutException)
                {
                    //Console.WriteLine("Read timeout occured");
                }

            }
            serial.Close();
            return true;
        }

        //Receive Data 45 bytes at a time
        static string ReadIn(SerialPort serial, string dataOut, byte[] dataIn)
        {

            bool tryAgain = true;
            while (true)
            {
                serial.Open();

                try
                {
                    serial.Write("N");
                }
                catch(TimeoutException)
                {
                    serial.Close();
                    continue;

                }

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
                        //serial.DiscardOutBuffer();
                        //serial.Write("N");
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
                return message; //float.Parse(message);
            }
        }


        static void Main(string[] args)
        {
            SerialPort serial = new SerialPort();
            serial.BaudRate = 115200;
            serial.DataBits = 8;
            serial.StopBits = StopBits.One;
            serial.ReadTimeout = 50;
            serial.WriteTimeout = 50;
            serial.DtrEnable = true;
            serial.RtsEnable = true;
            serial.Parity = Parity.Odd;
            serial.Encoding = System.Text.Encoding.GetEncoding(1252);

            bool tryAgain = true;
            string[] port = SerialPort.GetPortNames();
            Console.WriteLine(port[0]);

            serial.PortName = port[1];
            string handShake = "HI";
            byte[] hsResponse = new byte[3];
            string transmit = "COMPUTER HI";
            byte[] response = new byte[13];
            string[] toTransmit = new string[6];
            byte[] acknowledgement = new byte[1];
            byte[] recvievedData = new byte[45];
            string display;

            //for (int i=0; i<6; i++)
            //{
            //    toTransmit[i] = Console.ReadLine();
            //}

            //Hard coded float values
            toTransmit[0] = "10.001"; // Frequency Start
            toTransmit[1] = "11.002"; // Frequency End
            toTransmit[2] = "12.003"; // Sweep Rate
            toTransmit[3] = "1";      // Lin or Log
            toTransmit[4] = "13.004"; // Amplitude
            toTransmit[5] = "14.005"; // DC Offset


            //Handshake with Edison
            if (HandShake(serial, handShake, hsResponse))
                Console.WriteLine("Successful Handshake!");
            else
                Console.WriteLine("Unsuccessful Handshake");

            //Transmit
            for (int i=0; i<6; i++)
            {
                if (Transmit(serial, i + toTransmit[i], acknowledgement) == false)
                    Console.WriteLine("Failure to Acknowledge");
            }
            Console.WriteLine("Done Transmitting");

            //Reading Data Continuously
            string testing = "";

            while(tryAgain)
            {
                display = ReadIn(serial, toTransmit[0], recvievedData);
                if (display[0] == 'E')
                    tryAgain = false;
                else
                {
                    //Console.WriteLine(display);
                   
                    if (testing.CompareTo(display) == 0)
                        Console.WriteLine("Duplicate on " + display);
                    testing = display;
                    
                }
            }
            //Ending Data Read



            Console.WriteLine("Tis Over");
            Console.Read();

        }//End of main


    }
}
