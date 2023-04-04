namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cnvrtTojsonbtn = new System.Windows.Forms.Button();
            this.txtbox = new System.Windows.Forms.TextBox();
            this.sndmsgBtn = new System.Windows.Forms.Button();
            this.generateMSHMsgBtn = new System.Windows.Forms.Button();
            this.generateSFTMsgBtn = new System.Windows.Forms.Button();
            this.generateEVNMsgBtn = new System.Windows.Forms.Button();
            this.generatePIDMsgBtn = new System.Windows.Forms.Button();
            this.generatePD1MsgBtn = new System.Windows.Forms.Button();
            this.generateROLMsgBtn = new System.Windows.Forms.Button();
            this.generateNK1MsgBtn = new System.Windows.Forms.Button();
            this.generatePV1MsgBtn = new System.Windows.Forms.Button();
            this.generatePV2MsgBtn = new System.Windows.Forms.Button();
            this.generateROL2MsgBtn = new System.Windows.Forms.Button();
            this.generateDB1MsgBtn = new System.Windows.Forms.Button();
            this.generateOBXMsgBtn = new System.Windows.Forms.Button();
            this.generateAL1MsgBtn = new System.Windows.Forms.Button();
            this.generateDG1MsgBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cnvrtTojsonbtn
            // 
            this.cnvrtTojsonbtn.Location = new System.Drawing.Point(670, 12);
            this.cnvrtTojsonbtn.Name = "cnvrtTojsonbtn";
            this.cnvrtTojsonbtn.Size = new System.Drawing.Size(118, 29);
            this.cnvrtTojsonbtn.TabIndex = 0;
            this.cnvrtTojsonbtn.Text = "Convert to Json";
            this.cnvrtTojsonbtn.UseVisualStyleBackColor = true;
            this.cnvrtTojsonbtn.Click += new System.EventHandler(this.cnvrtTojsonbtn_Click_1);
            // 
            // txtbox
            // 
            this.txtbox.Location = new System.Drawing.Point(12, 305);
            this.txtbox.Multiline = true;
            this.txtbox.Name = "txtbox";
            this.txtbox.Size = new System.Drawing.Size(776, 133);
            this.txtbox.TabIndex = 1;
            // 
            // sndmsgBtn
            // 
            this.sndmsgBtn.Location = new System.Drawing.Point(694, 47);
            this.sndmsgBtn.Name = "sndmsgBtn";
            this.sndmsgBtn.Size = new System.Drawing.Size(94, 29);
            this.sndmsgBtn.TabIndex = 2;
            this.sndmsgBtn.Text = "Send MSG";
            this.sndmsgBtn.UseVisualStyleBackColor = true;
            this.sndmsgBtn.Click += new System.EventHandler(this.sndmsgBtn_Click);
            // 
            // generateMSHMsgBtn
            // 
            this.generateMSHMsgBtn.Location = new System.Drawing.Point(12, 12);
            this.generateMSHMsgBtn.Name = "generateMSHMsgBtn";
            this.generateMSHMsgBtn.Size = new System.Drawing.Size(179, 29);
            this.generateMSHMsgBtn.TabIndex = 3;
            this.generateMSHMsgBtn.Text = "Generate Message MSH";
            this.generateMSHMsgBtn.UseVisualStyleBackColor = true;
            this.generateMSHMsgBtn.Click += new System.EventHandler(this.generateMsgBtn_Click);
            // 
            // generateSFTMsgBtn
            // 
            this.generateSFTMsgBtn.Location = new System.Drawing.Point(12, 47);
            this.generateSFTMsgBtn.Name = "generateSFTMsgBtn";
            this.generateSFTMsgBtn.Size = new System.Drawing.Size(179, 29);
            this.generateSFTMsgBtn.TabIndex = 4;
            this.generateSFTMsgBtn.Text = "SFT Message";
            this.generateSFTMsgBtn.UseVisualStyleBackColor = true;
            this.generateSFTMsgBtn.Click += new System.EventHandler(this.generateSFTMsgBtn_Click);
            // 
            // generateEVNMsgBtn
            // 
            this.generateEVNMsgBtn.Location = new System.Drawing.Point(12, 82);
            this.generateEVNMsgBtn.Name = "generateEVNMsgBtn";
            this.generateEVNMsgBtn.Size = new System.Drawing.Size(179, 29);
            this.generateEVNMsgBtn.TabIndex = 5;
            this.generateEVNMsgBtn.Text = "EVN Message";
            this.generateEVNMsgBtn.UseVisualStyleBackColor = true;
            this.generateEVNMsgBtn.Click += new System.EventHandler(this.generateEVNMsgBtn_Click);
            // 
            // generatePIDMsgBtn
            // 
            this.generatePIDMsgBtn.Location = new System.Drawing.Point(12, 117);
            this.generatePIDMsgBtn.Name = "generatePIDMsgBtn";
            this.generatePIDMsgBtn.Size = new System.Drawing.Size(179, 29);
            this.generatePIDMsgBtn.TabIndex = 6;
            this.generatePIDMsgBtn.Text = "PID Message";
            this.generatePIDMsgBtn.UseVisualStyleBackColor = true;
            this.generatePIDMsgBtn.Click += new System.EventHandler(this.generatePIDMsgBtn_Click);
            // 
            // generatePD1MsgBtn
            // 
            this.generatePD1MsgBtn.Location = new System.Drawing.Point(12, 152);
            this.generatePD1MsgBtn.Name = "generatePD1MsgBtn";
            this.generatePD1MsgBtn.Size = new System.Drawing.Size(179, 29);
            this.generatePD1MsgBtn.TabIndex = 7;
            this.generatePD1MsgBtn.Text = "PD1 Message";
            this.generatePD1MsgBtn.UseVisualStyleBackColor = true;
            this.generatePD1MsgBtn.Click += new System.EventHandler(this.generatePD1MsgBtn_Click);
            // 
            // generateROLMsgBtn
            // 
            this.generateROLMsgBtn.Location = new System.Drawing.Point(12, 187);
            this.generateROLMsgBtn.Name = "generateROLMsgBtn";
            this.generateROLMsgBtn.Size = new System.Drawing.Size(179, 29);
            this.generateROLMsgBtn.TabIndex = 8;
            this.generateROLMsgBtn.Text = "ROL Message";
            this.generateROLMsgBtn.UseVisualStyleBackColor = true;
            this.generateROLMsgBtn.Click += new System.EventHandler(this.generateROLMsgBtn_Click);
            // 
            // generateNK1MsgBtn
            // 
            this.generateNK1MsgBtn.Location = new System.Drawing.Point(12, 222);
            this.generateNK1MsgBtn.Name = "generateNK1MsgBtn";
            this.generateNK1MsgBtn.Size = new System.Drawing.Size(179, 29);
            this.generateNK1MsgBtn.TabIndex = 9;
            this.generateNK1MsgBtn.Text = "NK1 Message";
            this.generateNK1MsgBtn.UseVisualStyleBackColor = true;
            this.generateNK1MsgBtn.Click += new System.EventHandler(this.generateNK1MsgBtn_Click);
            // 
            // generatePV1MsgBtn
            // 
            this.generatePV1MsgBtn.Location = new System.Drawing.Point(12, 257);
            this.generatePV1MsgBtn.Name = "generatePV1MsgBtn";
            this.generatePV1MsgBtn.Size = new System.Drawing.Size(179, 29);
            this.generatePV1MsgBtn.TabIndex = 10;
            this.generatePV1MsgBtn.Text = "PV1 Message";
            this.generatePV1MsgBtn.UseVisualStyleBackColor = true;
            this.generatePV1MsgBtn.Click += new System.EventHandler(this.generatePV1MsgBtn_Click);
            // 
            // generatePV2MsgBtn
            // 
            this.generatePV2MsgBtn.Location = new System.Drawing.Point(208, 12);
            this.generatePV2MsgBtn.Name = "generatePV2MsgBtn";
            this.generatePV2MsgBtn.Size = new System.Drawing.Size(179, 29);
            this.generatePV2MsgBtn.TabIndex = 11;
            this.generatePV2MsgBtn.Text = "PV2 Message";
            this.generatePV2MsgBtn.UseVisualStyleBackColor = true;
            this.generatePV2MsgBtn.Click += new System.EventHandler(this.generatePV2MsgBtn_Click);
            // 
            // generateROL2MsgBtn
            // 
            this.generateROL2MsgBtn.Location = new System.Drawing.Point(208, 47);
            this.generateROL2MsgBtn.Name = "generateROL2MsgBtn";
            this.generateROL2MsgBtn.Size = new System.Drawing.Size(179, 29);
            this.generateROL2MsgBtn.TabIndex = 12;
            this.generateROL2MsgBtn.Text = "ROL2 Message";
            this.generateROL2MsgBtn.UseVisualStyleBackColor = true;
            this.generateROL2MsgBtn.Click += new System.EventHandler(this.generateROL2MsgBtn_Click);
            // 
            // generateDB1MsgBtn
            // 
            this.generateDB1MsgBtn.Location = new System.Drawing.Point(208, 82);
            this.generateDB1MsgBtn.Name = "generateDB1MsgBtn";
            this.generateDB1MsgBtn.Size = new System.Drawing.Size(179, 29);
            this.generateDB1MsgBtn.TabIndex = 13;
            this.generateDB1MsgBtn.Text = "DB1 Message";
            this.generateDB1MsgBtn.UseVisualStyleBackColor = true;
            this.generateDB1MsgBtn.Click += new System.EventHandler(this.generateDB1MsgBtn_Click);
            // 
            // generateOBXMsgBtn
            // 
            this.generateOBXMsgBtn.Location = new System.Drawing.Point(208, 117);
            this.generateOBXMsgBtn.Name = "generateOBXMsgBtn";
            this.generateOBXMsgBtn.Size = new System.Drawing.Size(179, 29);
            this.generateOBXMsgBtn.TabIndex = 14;
            this.generateOBXMsgBtn.Text = "OBX Message";
            this.generateOBXMsgBtn.UseVisualStyleBackColor = true;
            this.generateOBXMsgBtn.Click += new System.EventHandler(this.generateOBXMsgBtn_Click);
            // 
            // generateAL1MsgBtn
            // 
            this.generateAL1MsgBtn.Location = new System.Drawing.Point(208, 152);
            this.generateAL1MsgBtn.Name = "generateAL1MsgBtn";
            this.generateAL1MsgBtn.Size = new System.Drawing.Size(179, 29);
            this.generateAL1MsgBtn.TabIndex = 15;
            this.generateAL1MsgBtn.Text = "AL1 Message";
            this.generateAL1MsgBtn.UseVisualStyleBackColor = true;
            this.generateAL1MsgBtn.Click += new System.EventHandler(this.generateAL1MsgBtn_Click);
            // 
            // generateDG1MsgBtn
            // 
            this.generateDG1MsgBtn.Location = new System.Drawing.Point(208, 187);
            this.generateDG1MsgBtn.Name = "generateDG1MsgBtn";
            this.generateDG1MsgBtn.Size = new System.Drawing.Size(179, 29);
            this.generateDG1MsgBtn.TabIndex = 16;
            this.generateDG1MsgBtn.Text = "DG1 Message";
            this.generateDG1MsgBtn.UseVisualStyleBackColor = true;
            this.generateDG1MsgBtn.Click += new System.EventHandler(this.generateDG1MsgBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.generateDG1MsgBtn);
            this.Controls.Add(this.generateAL1MsgBtn);
            this.Controls.Add(this.generateOBXMsgBtn);
            this.Controls.Add(this.generateDB1MsgBtn);
            this.Controls.Add(this.generateROL2MsgBtn);
            this.Controls.Add(this.generatePV2MsgBtn);
            this.Controls.Add(this.generatePV1MsgBtn);
            this.Controls.Add(this.generateNK1MsgBtn);
            this.Controls.Add(this.generateROLMsgBtn);
            this.Controls.Add(this.generatePD1MsgBtn);
            this.Controls.Add(this.generatePIDMsgBtn);
            this.Controls.Add(this.generateEVNMsgBtn);
            this.Controls.Add(this.generateSFTMsgBtn);
            this.Controls.Add(this.generateMSHMsgBtn);
            this.Controls.Add(this.sndmsgBtn);
            this.Controls.Add(this.txtbox);
            this.Controls.Add(this.cnvrtTojsonbtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button cnvrtTojsonbtn;
        private TextBox txtbox;
        private Button sndmsgBtn;
        private Button generateMSHMsgBtn;
        private Button generateSFTMsgBtn;
        private Button generateEVNMsgBtn;
        private Button generatePIDMsgBtn;
        private Button generatePD1MsgBtn;
        private Button generateROLMsgBtn;
        private Button generateNK1MsgBtn;
        private Button generatePV1MsgBtn;
        private Button generatePV2MsgBtn;
        private Button generateROL2MsgBtn;
        private Button generateDB1MsgBtn;
        private Button generateOBXMsgBtn;
        private Button generateAL1MsgBtn;
        private Button generateDG1MsgBtn;
    }
}