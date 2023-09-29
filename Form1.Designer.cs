namespace MECH_368_labOne_e7
{
    partial class StateMachine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxAX = new System.Windows.Forms.TextBox();
            this.textBoxAY = new System.Windows.Forms.TextBox();
            this.textBoxAZ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonDataProcess = new System.Windows.Forms.Button();
            this.textBoxCurrentMovement = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDataDisplay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.buttonUpdateSerial = new System.Windows.Forms.Button();
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxGestures = new System.Windows.Forms.TextBox();
            this.textBoxFilename = new System.Windows.Forms.TextBox();
            this.buttonFilename = new System.Windows.Forms.Button();
            this.checkBoxSave = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxAX
            // 
            this.textBoxAX.Location = new System.Drawing.Point(53, 12);
            this.textBoxAX.Name = "textBoxAX";
            this.textBoxAX.Size = new System.Drawing.Size(100, 20);
            this.textBoxAX.TabIndex = 0;
            // 
            // textBoxAY
            // 
            this.textBoxAY.Location = new System.Drawing.Point(221, 12);
            this.textBoxAY.Name = "textBoxAY";
            this.textBoxAY.Size = new System.Drawing.Size(100, 20);
            this.textBoxAY.TabIndex = 1;
            // 
            // textBoxAZ
            // 
            this.textBoxAZ.Location = new System.Drawing.Point(389, 12);
            this.textBoxAZ.Name = "textBoxAZ";
            this.textBoxAZ.Size = new System.Drawing.Size(100, 20);
            this.textBoxAZ.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ax";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ay";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Az";
            // 
            // buttonDataProcess
            // 
            this.buttonDataProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDataProcess.Location = new System.Drawing.Point(12, 38);
            this.buttonDataProcess.Name = "buttonDataProcess";
            this.buttonDataProcess.Size = new System.Drawing.Size(478, 23);
            this.buttonDataProcess.TabIndex = 7;
            this.buttonDataProcess.Text = "Process New Data Point";
            this.buttonDataProcess.UseVisualStyleBackColor = true;
            this.buttonDataProcess.Click += new System.EventHandler(this.buttonDataProcess_Click);
            // 
            // textBoxCurrentMovement
            // 
            this.textBoxCurrentMovement.Location = new System.Drawing.Point(389, 67);
            this.textBoxCurrentMovement.Name = "textBoxCurrentMovement";
            this.textBoxCurrentMovement.Size = new System.Drawing.Size(100, 20);
            this.textBoxCurrentMovement.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Current State";
            // 
            // textBoxDataDisplay
            // 
            this.textBoxDataDisplay.Location = new System.Drawing.Point(12, 119);
            this.textBoxDataDisplay.Multiline = true;
            this.textBoxDataDisplay.Name = "textBoxDataDisplay";
            this.textBoxDataDisplay.Size = new System.Drawing.Size(477, 319);
            this.textBoxDataDisplay.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Data History";
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "COM Port";
            // 
            // buttonUpdateSerial
            // 
            this.buttonUpdateSerial.Location = new System.Drawing.Point(200, 65);
            this.buttonUpdateSerial.Name = "buttonUpdateSerial";
            this.buttonUpdateSerial.Size = new System.Drawing.Size(108, 23);
            this.buttonUpdateSerial.TabIndex = 14;
            this.buttonUpdateSerial.UseVisualStyleBackColor = true;
            this.buttonUpdateSerial.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(71, 66);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(123, 21);
            this.comboBoxCOMPorts.TabIndex = 15;
            this.comboBoxCOMPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxCOMPorts_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 455);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Last Gesture Recognized:";
            // 
            // textBoxGestures
            // 
            this.textBoxGestures.Location = new System.Drawing.Point(145, 452);
            this.textBoxGestures.Name = "textBoxGestures";
            this.textBoxGestures.Size = new System.Drawing.Size(344, 20);
            this.textBoxGestures.TabIndex = 17;
            // 
            // textBoxFilename
            // 
            this.textBoxFilename.Location = new System.Drawing.Point(146, 478);
            this.textBoxFilename.Name = "textBoxFilename";
            this.textBoxFilename.Size = new System.Drawing.Size(257, 20);
            this.textBoxFilename.TabIndex = 18;
            // 
            // buttonFilename
            // 
            this.buttonFilename.Location = new System.Drawing.Point(12, 476);
            this.buttonFilename.Name = "buttonFilename";
            this.buttonFilename.Size = new System.Drawing.Size(127, 23);
            this.buttonFilename.TabIndex = 19;
            this.buttonFilename.Text = "Select Filename";
            this.buttonFilename.UseVisualStyleBackColor = true;
            this.buttonFilename.Click += new System.EventHandler(this.buttonFilename_Click);
            // 
            // checkBoxSave
            // 
            this.checkBoxSave.AutoSize = true;
            this.checkBoxSave.Enabled = false;
            this.checkBoxSave.Location = new System.Drawing.Point(407, 480);
            this.checkBoxSave.Name = "checkBoxSave";
            this.checkBoxSave.Size = new System.Drawing.Size(82, 17);
            this.checkBoxSave.TabIndex = 20;
            this.checkBoxSave.Text = "Save to File";
            this.checkBoxSave.UseVisualStyleBackColor = true;
            // 
            // StateMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 511);
            this.Controls.Add(this.checkBoxSave);
            this.Controls.Add(this.buttonFilename);
            this.Controls.Add(this.textBoxFilename);
            this.Controls.Add(this.textBoxGestures);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxCOMPorts);
            this.Controls.Add(this.buttonUpdateSerial);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxDataDisplay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCurrentMovement);
            this.Controls.Add(this.buttonDataProcess);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAZ);
            this.Controls.Add(this.textBoxAY);
            this.Controls.Add(this.textBoxAX);
            this.MinimumSize = new System.Drawing.Size(518, 525);
            this.Name = "StateMachine";
            this.Text = "State Machine";
            this.Load += new System.EventHandler(this.StateMachine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAX;
        private System.Windows.Forms.TextBox textBoxAY;
        private System.Windows.Forms.TextBox textBoxAZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDataProcess;
        private System.Windows.Forms.TextBox textBoxCurrentMovement;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDataDisplay;
        private System.Windows.Forms.Label label5;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonUpdateSerial;
        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxGestures;
        private System.Windows.Forms.TextBox textBoxFilename;
        private System.Windows.Forms.Button buttonFilename;
        private System.Windows.Forms.CheckBox checkBoxSave;
    }
}

