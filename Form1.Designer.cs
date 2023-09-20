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
            this.textBoxCurrentState = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDataDisplay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
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
            // textBoxCurrentState
            // 
            this.textBoxCurrentState.Location = new System.Drawing.Point(389, 67);
            this.textBoxCurrentState.Name = "textBoxCurrentState";
            this.textBoxCurrentState.Size = new System.Drawing.Size(100, 20);
            this.textBoxCurrentState.TabIndex = 8;
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
            this.textBoxDataDisplay.Location = new System.Drawing.Point(12, 93);
            this.textBoxDataDisplay.Multiline = true;
            this.textBoxDataDisplay.Name = "textBoxDataDisplay";
            this.textBoxDataDisplay.Size = new System.Drawing.Size(477, 345);
            this.textBoxDataDisplay.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Data History";
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            // 
            // StateMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxDataDisplay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCurrentState);
            this.Controls.Add(this.buttonDataProcess);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAZ);
            this.Controls.Add(this.textBoxAY);
            this.Controls.Add(this.textBoxAX);
            this.MinimumSize = new System.Drawing.Size(518, 489);
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
        private System.Windows.Forms.TextBox textBoxCurrentState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDataDisplay;
        private System.Windows.Forms.Label label5;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

