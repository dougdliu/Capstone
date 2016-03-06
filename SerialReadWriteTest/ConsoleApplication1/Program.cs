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
        static void Main(string[] args)
        {
            SerialPort serial = new SerialPort();   
            serial.BaudRate = 9600;                 
            serial.ReadTimeout = 100;
            serial.WriteTimeout = 100;
            serial.DtrEnable = true;
            serial.Encoding = System.Text.Encoding.GetEncoding(1252);

            int tryAgain = 1;
            string[] port = SerialPort.GetPortNames();
            Console.WriteLine(port[0]);

            serial.PortName = port[0];
            byte[] transmit = { (byte)'A', (byte)'B' };
            byte[] response = new byte[10];

            while(tryAgain != 0)
            {
                try
                {
                    if (serial.IsOpen)
                        serial.Close();
                    serial.Open();
                    serial.DiscardInBuffer();
                    serial.DiscardOutBuffer();
                    //serial.Write(transmit, 0, 2);
                    Thread.Sleep(1000);
                    serial.Read(response, 0, 5);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Timeout");
                }
                Thread.Sleep(1000);
                string message = System.Text.Encoding.ASCII.GetString(response);
                Console.WriteLine(message);

                //Convert.ToInt32(Console.Read());
            }
        }
    }
}
