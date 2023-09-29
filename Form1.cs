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
        int currentState = 0;
        bool isXPlusDetected = false;
        bool isYPlusDetected = false;
        bool isZPlusDetected = false;
        string lastDetectedSequence = "";
        StringBuilder orientationStringBuilder = new StringBuilder();
        DateTime sequenceStartTime;
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> aXQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> aYQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> aZQueue = new ConcurrentQueue<Int32>();

        private StreamWriter csvWriter;

        public StateMachine()
        {
            InitializeComponent();
        }

        private void StateMachine_Load(object sender, EventArgs e)
        {
            //clear the dropdown box, add currently used COM ports to it for selection
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBoxCOMPorts.Items.Count > 0)
                comboBoxCOMPorts.SelectedIndex = 0;
            else
                comboBoxCOMPorts.Text = "No COM ports!";

            //create a timer for events to occur within
            System.Windows.Forms.Timer queueTimer = new System.Windows.Forms.Timer();
            queueTimer.Interval = 100;
            queueTimer.Tick += new EventHandler(queueTimer_Tick);
            queueTimer.Start();
        }

        private string DetermineOrientation(int ax, int ay, int az)
        {
            // Define thresholds for each axis
            int XThreshold = 129;
            int YThreshold = 129;
            int ZThreshold = 151;
            int trueX = ax - XThreshold;
            int trueY = ay - YThreshold;
            int trueZ = az - ZThreshold;
            int thresholdDistance = 8;

            // Calculate the distances from each threshold along each axis
            int distanceX = Math.Abs(trueX) - thresholdDistance;
            int distanceY = Math.Abs(trueY) - thresholdDistance;
            int distanceZ = Math.Abs(trueZ) - thresholdDistance;

            // Check if any axis has moved more than the threshold distance
            bool isMovingX = distanceX > thresholdDistance;
            bool isMovingY = distanceY > thresholdDistance;
            bool isMovingZ = distanceZ > thresholdDistance;

            // Determine the orientation based on the maximum distance
            if (isMovingX || isMovingY || isMovingZ)
            {
                if (distanceX >= distanceY && distanceX >= distanceZ)
                {
                    if (trueX > thresholdDistance)
                    {
                        currentState = 1;
                        return "Moving X+";
                    }
                    else
                    {
                        currentState = 2;
                        return "Moving X-";
                    }
                }
                else if (distanceY >= distanceX && distanceY >= distanceZ)
                {
                    if (trueY > thresholdDistance)
                    {
                        currentState = 3;
                        return "Moving Y+";
                    }
                    else
                    {
                        currentState = 4;
                        return "Moving Y-";
                    }
                }
                else
                {
                    if (trueZ > thresholdDistance)
                    {
                        currentState = 5;
                        return "Moving Z+";
                    }
                    else
                    {
                        currentState = 6;
                        return "Moving Z-";
                    }
                }
            }
            else
            {
                currentState = 0;
                return "Resting";
            }
        }

        private void DetectSequences(string orientationString)
        {
            // Define the three sequences to detect
            string sequence1 = "Moving X+";
            string sequence2 = "Moving Z+Moving X+";
            string sequence3 = "Moving X+Moving Y+Moving Z+";

            // Check if any of the sequences are present in the orientation string
            if (orientationString.Contains(sequence1))
            {
                lastDetectedSequence = "Simple punch";
            }
            else if (orientationString.Contains(sequence2))
            {
                lastDetectedSequence = "High punch";
            }
            else if (orientationString.Contains(sequence3))
            {
                lastDetectedSequence = "Right hook";
            }
            else
            {
                lastDetectedSequence = "";
            }

            // Display the last detected sequence in the textBoxGestures using Invoke
            this.Invoke((MethodInvoker)delegate
            {
                textBoxGestures.Text = lastDetectedSequence;
            });
        }

        private async void queueTimer_Tick(object sender, EventArgs e)
        {
            //check if board is ready to be connected
            if (!serialPort1.IsOpen)
            {
                //update button text with relevant label
                buttonUpdateSerial.Text = "Connect Serial";

                //2023-09-17 - clear text that might have been missed, bug patch
                textBoxDataDisplay.Text = "";
            }
            else
            {
                //update button text with relevant label
                buttonUpdateSerial.Text = "Disconnect Serial";
            }
            
            //dequeue items and insert them into an endless textbox
            while (dataQueue.TryDequeue(out int dequeuedByte))
            {
                //check if next item is 255
                if (dequeuedByte == 255)
                {
                    currentByteIndex = 0;
                }
                else
                {
                    if (currentByteIndex == 0)
                    {
                        currentAXValue = dequeuedByte;
                    }
                    else if (currentByteIndex == 1)
                    {
                        currentAYValue = dequeuedByte;
                    }
                    else if (currentByteIndex == 2)
                    {
                        currentAZValue = dequeuedByte;
                    }

                    currentByteIndex++;

                    aXQueue.Enqueue(currentAXValue);
                    aYQueue.Enqueue(currentAYValue);
                    aZQueue.Enqueue(currentAZValue);

                    textBoxAX.Text = currentAXValue.ToString();
                    textBoxAY.Text = currentAYValue.ToString();
                    textBoxAZ.Text = currentAZValue.ToString();
                }

            }

            // Update state machine textbox with current state of the accelerometer
            if (serialPort1.IsOpen)
            {
                string currentMovement = DetermineOrientation(currentAXValue, currentAYValue, currentAZValue);
                textBoxCurrentMovement.Text = currentMovement;

                // Append the current orientation to the string
                orientationStringBuilder.Append(currentMovement);

                // Limit the length of the orientation string to prevent excessive growth
                if (orientationStringBuilder.Length > 1000)
                {
                    orientationStringBuilder.Remove(0, orientationStringBuilder.Length - 1000);
                }

                // Detect X+, Y+, and Z+ movements and set corresponding flags
                if (currentMovement == "Moving X+")
                {
                    isXPlusDetected = true;
                }
                else if (currentMovement == "Moving Y+")
                {
                    isYPlusDetected = true;
                }
                else if (currentMovement == "Moving Z+")
                {
                    isZPlusDetected = true;
                }

                // Check for sequence presence after 250ms
                await Task.Delay(250);

                if (isXPlusDetected && isYPlusDetected && isZPlusDetected)
                {
                    // Detected "Moving X+Moving Y+Moving Z+" sequence
                    lastDetectedSequence = "Right hook";

                    // Clear flags and orientation string
                    isXPlusDetected = false;
                    isYPlusDetected = false;
                    isZPlusDetected = false;
                    orientationStringBuilder.Clear();

                    // Display the last detected sequence in the textBoxGestures using Invoke
                    this.Invoke((MethodInvoker)delegate
                    {
                        textBoxGestures.Text = lastDetectedSequence;
                    });

                    // Clear the textbox after 1 second
                    await Task.Delay(1000);

                    // Clear the textbox using Invoke
                    this.Invoke((MethodInvoker)delegate
                    {
                        textBoxGestures.Text = "";
                    });
                }
                else if (isZPlusDetected && isXPlusDetected)
                {
                    // Detected "Moving X+Moving Y+Moving Z+" sequence
                    lastDetectedSequence = "High punch";

                    // Clear flags and orientation string
                    isXPlusDetected = false;
                    isYPlusDetected = false;
                    isZPlusDetected = false;
                    orientationStringBuilder.Clear();

                    // Display the last detected sequence in the textBoxGestures using Invoke
                    this.Invoke((MethodInvoker)delegate
                    {
                        textBoxGestures.Text = lastDetectedSequence;
                    });

                    // Clear the textbox after 1 second
                    await Task.Delay(1000);

                    // Clear the textbox using Invoke
                    this.Invoke((MethodInvoker)delegate
                    {
                        textBoxGestures.Text = "";
                    });
                }
                else if (isXPlusDetected)
                {
                    // Detected "Moving X+Moving Y+Moving Z+" sequence
                    lastDetectedSequence = "Simple punch";

                    // Clear flags and orientation string
                    isXPlusDetected = false;
                    isYPlusDetected = false;
                    isZPlusDetected = false;
                    orientationStringBuilder.Clear();

                    // Display the last detected sequence in the textBoxGestures using Invoke
                    this.Invoke((MethodInvoker)delegate
                    {
                        textBoxGestures.Text = lastDetectedSequence;
                    });

                    // Clear the textbox after 1 second
                    await Task.Delay(1000);

                    // Clear the textbox using Invoke
                    this.Invoke((MethodInvoker)delegate
                    {
                        textBoxGestures.Text = "";
                    });
                }
                //else
                //{
                //    await Task.Delay(1000);
                    
                //    // Clear flags and orientation string
                //    isXPlusDetected = false;
                //    isYPlusDetected = false;
                //    isZPlusDetected = false;
                //    orientationStringBuilder.Clear();
                //}
            }
            else
            {
                textBoxCurrentMovement.Text = null;
            }

            //check if the save checkbox is selected, write data if so
            if (checkBoxSave.Checked)
            {
                if (csvWriter == null)
                {
                    try
                    {
                        csvWriter = new StreamWriter(textBoxFilename.Text, false);
                        csvWriter.WriteLine("Ax, Ay, Az, Timestamp");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error writing data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                csvWriter.WriteLine($"{currentAXValue}, {currentAYValue}, {currentAZValue}, {timestamp}, ");
            }
        }

        private void buttonDataProcess_Click(object sender, EventArgs e)
        {
            textBoxDataDisplay.AppendText("(" + currentAXValue + ", " + currentAYValue + ", " + currentAZValue + ", " + currentState + "), ");
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            //implementing some error handling here using exception messaging
            try
            {
                //if the port is closed, open it and request acceleration data; if the port is open, close and clear text fields
                if (!serialPort1.IsOpen)
                {
                    serialPort1.Open();
                    serialPort1.Write("A");
                }
                else
                {
                    serialPort1.Close();
                    textBoxDataDisplay.Text = "";
                    textBoxAX.Text = "";
                    textBoxAY.Text = "";
                    textBoxAZ.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening the serial port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytesToRead;
            int newByte;

            bytesToRead = serialPort1.BytesToRead;
            bytesToReadDisplay = bytesToRead;

            while (bytesToRead > 0)
            {
                newByte = serialPort1.ReadByte();
                dataQueue.Enqueue(newByte);
                bytesToRead = serialPort1.BytesToRead;
            }
        }

        private void comboBoxCOMPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBoxCOMPorts.Text;
        }

        private void buttonFilename_Click(object sender, EventArgs e)
        {
            //initiate a save box
            SaveFileDialog csvSave = new SaveFileDialog();
            csvSave.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

            if (csvSave.ShowDialog() == DialogResult.OK)
            {
                //display selected save path & start data recording
                string filePath = csvSave.FileName;
                textBoxFilename.Text = filePath;
                checkBoxSave.Enabled = true;
                checkBoxSave.Checked = true;
            }
        }
    }
}
