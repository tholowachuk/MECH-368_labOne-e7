using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace MECH_368_labOne_e7
{
    public partial class StateMachine : Form
    {
        //create some items for later use
        int currentAXValue = 0;
        int currentAYValue = 0;
        int currentAZValue = 0;
        int currentByteIndex = 0;
        int bytesToReadDisplay = 0;
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> aXQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> aYQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> aZQueue = new ConcurrentQueue<Int32>();

        public StateMachine()
        {
            InitializeComponent();
        }



        private void StateMachine_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer queuetimer = new System.Windows.Forms.Timer();
            queuetimer.Interval = 100;
            queuetimer.Tick += new EventHandler(queueTimer_Tick);
            queuetimer.Start();
        }

        //initialize error flag for timer
        private bool errorShown = false;
        private string selectedCOMPort = null;

        private void queueTimer_Tick(object sender, EventArgs e)
        {
            try
            {            
                string[] COMPorts = System.IO.Ports.SerialPort.GetPortNames();

                //check if the selected COM port is in the list of available ports
                if (!string.IsNullOrEmpty(selectedCOMPort) && !COMPorts.Contains(selectedCOMPort))
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    selectedCOMPort = null;
                    errorShown = false;
                }
                
                //check if there are any available COM ports
                if (COMPorts.Length >= 1)
                {
                    //check if port is open or not
                    if (!serialPort1.IsOpen)
                    {
                        //using first available COM port, open and request acceleration data
                        serialPort1.PortName = COMPorts[0];
                        serialPort1.PortName = selectedCOMPort;
                        serialPort1.Open();
                        serialPort1.Write("A");
                        MessageBox.Show($"Serial port {serialPort1.PortName} is open!", "Port Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                if (!errorShown)
                {
                    MessageBox.Show("Error opening the serial port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorShown = true;
                }
            }
        }

        private void buttonDataProcess_Click(object sender, EventArgs e)
        {

        }
    }
}
