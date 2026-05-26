namespace DeviceNetApp
{
    partial class SendMessage
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxMacID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtService = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInstance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAttributeAndData = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMessageLog = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReceiveMessageSize = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "MacID:";
            // 
            // cbxMacID
            // 
            this.cbxMacID.FormattingEnabled = true;
            this.cbxMacID.Location = new System.Drawing.Point(139, 14);
            this.cbxMacID.Name = "cbxMacID";
            this.cbxMacID.Size = new System.Drawing.Size(100, 21);
            this.cbxMacID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Service (Hex):";
            // 
            // txtService
            // 
            this.txtService.Location = new System.Drawing.Point(139, 43);
            this.txtService.Name = "txtService";
            this.txtService.Size = new System.Drawing.Size(100, 20);
            this.txtService.TabIndex = 2;
            this.txtService.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Class (Hex):";
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(139, 72);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(100, 20);
            this.txtClass.TabIndex = 3;
            this.txtClass.Text = "31";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Instance (Hex):";
            // 
            // txtInstance
            // 
            this.txtInstance.Location = new System.Drawing.Point(139, 101);
            this.txtInstance.Name = "txtInstance";
            this.txtInstance.Size = new System.Drawing.Size(100, 20);
            this.txtInstance.TabIndex = 4;
            this.txtInstance.Text = "01";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Attribute and Data (Hex):";
            // 
            // txtAttributeAndData
            // 
            this.txtAttributeAndData.Location = new System.Drawing.Point(139, 130);
            this.txtAttributeAndData.Name = "txtAttributeAndData";
            this.txtAttributeAndData.Size = new System.Drawing.Size(233, 20);
            this.txtAttributeAndData.TabIndex = 5;
            this.txtAttributeAndData.Text = "5D 01";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Message Log:";
            // 
            // txtMessageLog
            // 
            this.txtMessageLog.Location = new System.Drawing.Point(16, 211);
            this.txtMessageLog.Name = "txtMessageLog";
            this.txtMessageLog.Size = new System.Drawing.Size(621, 205);
            this.txtMessageLog.TabIndex = 8;
            this.txtMessageLog.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(381, 66);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Receive Message Size:";
            // 
            // txtReceiveMessageSize
            // 
            this.txtReceiveMessageSize.Location = new System.Drawing.Point(139, 159);
            this.txtReceiveMessageSize.Name = "txtReceiveMessageSize";
            this.txtReceiveMessageSize.Size = new System.Drawing.Size(100, 20);
            this.txtReceiveMessageSize.TabIndex = 6;
            this.txtReceiveMessageSize.Text = "1";
            // 
            // SendMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 428);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessageLog);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtReceiveMessageSize);
            this.Controls.Add(this.txtInstance);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.txtAttributeAndData);
            this.Controls.Add(this.txtService);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxMacID);
            this.Controls.Add(this.label1);
            this.Name = "SendMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Explicit Message";
            this.Load += new System.EventHandler(this.SendMessage_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SendMessage_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxMacID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtService;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInstance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAttributeAndData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtMessageLog;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReceiveMessageSize;
    }
}