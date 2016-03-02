using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;              //For Serial Port.

namespace SerialTesting
{
    public partial class Form1 : Form
    {

        #region shared variables and objects
        String hwInfo;
        String deviceSerialNum = "";

        private static SerialPort serialPort1 = new SerialPort()
        {
            BaudRate = 115200,          //Check this rate for Edison
            ReadTimeout = 100,
            WriteTimeout = 100,         //Should throw an exception on serial timeout
            DtrEnable = true,           //Data terminal ready
            Encoding = System.Text.Encoding.GetEncoding(1252)   //??
        };

        System.Diagnostics.Stopwatch mStopwatch = new System.Diagnostics.Stopwatch();
        bool serialConnectionEstablished = false;
        System.Windows.Forms.Timer pingTimer = new System.Windows.Forms.Timer();
        

        #endregion

        #region MC constants
        //MCU communication
        public const int HANDSHAKE_LENGTH = 5;                   //MCU sends back 15 byte handshake
        public const int RX_PAYLOAD_SIZE = 8;
        public const byte FRAMING_BYTE = 0x50;      //begins each transmission
        public const char HANDSHAKE = 'A';          //handshake command.  MCU responds with "Hello"
        public const char SEND_CAL_DATA = 'a';      //MCU sends the calibration data stored in EEPROM
        public const char RCV_CAL_DATA = 'B';       //MCU waits to receive calibration data and then stores it in EEPROM
        public const char POLLING_ON = 'b';         //MCU enables its ADC polling loop for all channels
        public const char POLLING_OFF = 'C';        //MCU disables its ADC polling loop for all channels
        public const char CHAN_CTRL = 'c';          //MCU turns channels on or off, specified by 'addr' and 'data' bytes
        public const char SETPOINT = 'D';           //MCU updates channel setpoint (specified by 'addr' and 'data' bytes) by writing to appropriate DAC channel
        public const char SAMPLING = 'd';           //MCU updates channel's sampling interval by changing the max value of the counter (software-implemented) that periodically increments
        public const char SP_PROGRAMMING = 'E';
        public const char IRCOMP = 'F';
        public const int DT = 20;
        public const double TIME_CAL_FACTOR = 1.005;
        public const int COUNTSCALER = 1;        //COUNTSCALER * DT = smallest increment of change in the sampling rate, in ms

        public const byte SERIAL_PACKET_LENGTH = 12;
        public const byte NUM_CHANNELS = 4;
        public const int NUM_CALIB_FLOAT_CHARACTERISTICS = 6;           //ADC slope + intercept
        //Low current shunt slope + intercept
        //high current shunt slope + intercept
        public const byte NUM_CALIB_SHORT_CHARACTERISTICS = 5;          //current offset
        //polarity threshold, low
        //polarity threshold, high
        //current threshold, low
        //current threshold, high
        public const byte NUM_CALIB_BYTE_CHARACTERISTICS = 2;           //channel type (galvano vs potentiostat)
        //setpoint variable (Volts vs applied current mA/uA/nA)

        public const int CALIBRATION_INFO = NUM_CALIB_FLOAT_CHARACTERISTICS * NUM_CHANNELS * sizeof(float)
                                            + NUM_CALIB_SHORT_CHARACTERISTICS * NUM_CHANNELS * sizeof(short)
                                            + NUM_CALIB_BYTE_CHARACTERISTICS * NUM_CHANNELS * sizeof(byte);

        #endregion

        #region GUI
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            connectAttempt();
            this.rngField1.Text = "connection made: " + serialConnectionEstablished;


        }

        private void rngField1_Click(object sender, EventArgs e)
        {
            //nothing
        }
#endregion 

        #region Connecting to MC
        public Boolean connectAttempt()
        {
            if (serialConnectionEstablished) {return true;}
            string[] ports = SerialPort.GetPortNames();         //Gets an array of avaliable ports on current computer
            Console.WriteLine(ports[0]);
            Array.Reverse(ports);                               //Reverses the ports. Don't see the point in this
            byte[] handshakeTransmission = new byte[5] { (byte)FRAMING_BYTE, (byte)HANDSHAKE, 0x00, 0x00, 0x00 };
            byte[] handshakeResponse = new byte[HANDSHAKE_LENGTH];

            foreach (string port in ports)  //Check all port that are avaliable
            {
                //Listening for "hello"
                if(serialPort1.IsOpen)  //Attempt to close the port
                {
                    try { serialPort1.Close(); }
                    catch (Exception) { continue; }
                }

                serialPort1.PortName = port;
                string message = string.Empty;  //An empty string
                try
                {
                    serialPort1.Open();
                    serialPort1.DiscardOutBuffer();
                    serialPort1.DiscardInBuffer();
                    serialPort1.Write(handshakeTransmission, 0, 5);
                    //ThreadExceptionDialog.Sleep(1000);
                    serialPort1.Read(handshakeResponse, 0, HANDSHAKE_LENGTH);
                }
                catch (Exception e) {continue;}

                if(!(message == null))
                {
                    message = System.Text.Encoding.ASCII.GetString(handshakeResponse);  //Translate MC message to a string
                    if (message.Equals("Hello"))
                    {
                        MCU_import_device_Info();       //??
                        //serialPort1.DataRecieved += new SerialDataReceivedEventHandler(DataRecieveHandler)
                        //serialPort1.ErrorReceived += new SerialErrorReceivedEventHandler(ErrorReceivedHandler);

                        return (serialConnectionEstablished = true);
                    }

                }
                
            }
            //continue or retry:
            var result = MessageBox.Show("No device found!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Retry) { return (connectAttempt()); }
            else { return false; }
        }
        #endregion

        #region Communicating with the MC (Edison)

        bool MCU_import_device_Info()           //To add serials numbers to channels, batch #s 
        {
            byte[] hwInfoSize = new byte[2];
            byte[] Calibration = new byte[CALIBRATION_INFO];
            char[] hardwareInfoBytes;

            try 
            {
                serialPort1.Write(new byte[5] { FRAMING_BYTE, (byte)SEND_CAL_DATA, 0x00, 0x00, 0x00 }, 0, 5);
                //Thread.Sleep(100);

            }

            catch(Exception)
            {
                //connectionError();
                return false;
            }

            for (int i = 0; i < NUM_CHANNELS; i++)
            {
                //    ch[i].setCalData(CalibrationData);    //For the Channel Data
            }

                return true;
        }

        #endregion
    }
}
