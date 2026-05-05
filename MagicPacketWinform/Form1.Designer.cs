using System.Drawing;
using System.Windows.Forms;

namespace MagicPacketWinform
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
            buttonQnapWakeOnLanRemote = new Button();
            groupBox1 = new GroupBox();
            textBoxTargetIp = new TextBox();
            label6 = new Label();
            textBoxPort = new TextBox();
            label5 = new Label();
            textBoxMacAddress = new TextBox();
            label4 = new Label();
            comboBoxName = new ComboBox();
            label3 = new Label();
            comboBoxMethod = new ComboBox();
            label2 = new Label();
            buttonQnapWakeOnLan = new Button();
            groupBox2 = new GroupBox();
            label1 = new Label();
            textBoxPublicIP = new TextBox();
            linkLabel3 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            groupBox3 = new GroupBox();
            linkLabel4 = new LinkLabel();
            buttonClose = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // buttonQnapWakeOnLanRemote
            // 
            buttonQnapWakeOnLanRemote.Location = new Point(64, 70);
            buttonQnapWakeOnLanRemote.Name = "buttonQnapWakeOnLanRemote";
            buttonQnapWakeOnLanRemote.Size = new Size(160, 32);
            buttonQnapWakeOnLanRemote.TabIndex = 1;
            buttonQnapWakeOnLanRemote.Text = "Wake On Web (Remote)";
            buttonQnapWakeOnLanRemote.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxTargetIp);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBoxPort);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(textBoxMacAddress);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(comboBoxName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(comboBoxMethod);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(buttonQnapWakeOnLan);
            groupBox1.Location = new Point(12, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(241, 220);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "NAS";
            // 
            // textBoxTargetIp
            // 
            textBoxTargetIp.Location = new Point(94, 109);
            textBoxTargetIp.Name = "textBoxTargetIp";
            textBoxTargetIp.ReadOnly = true;
            textBoxTargetIp.Size = new Size(122, 23);
            textBoxTargetIp.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 112);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 11;
            label6.Text = "Target IP:";
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(94, 137);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.ReadOnly = true;
            textBoxPort.Size = new Size(29, 23);
            textBoxPort.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 140);
            label5.Name = "label5";
            label5.Size = new Size(32, 15);
            label5.TabIndex = 9;
            label5.Text = "Port:";
            // 
            // textBoxMacAddress
            // 
            textBoxMacAddress.Location = new Point(94, 80);
            textBoxMacAddress.Name = "textBoxMacAddress";
            textBoxMacAddress.ReadOnly = true;
            textBoxMacAddress.Size = new Size(130, 23);
            textBoxMacAddress.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 83);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 7;
            label4.Text = "MAC Address:";
            // 
            // comboBoxName
            // 
            comboBoxName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxName.FormattingEnabled = true;
            comboBoxName.Location = new Point(94, 22);
            comboBoxName.Name = "comboBoxName";
            comboBoxName.Size = new Size(67, 23);
            comboBoxName.TabIndex = 6;
            comboBoxName.SelectedIndexChanged += comboBoxId_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 25);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 5;
            label3.Text = "Name:";
            // 
            // comboBoxMethod
            // 
            comboBoxMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMethod.FormattingEnabled = true;
            comboBoxMethod.Items.AddRange(new object[] { "255.255.255.255", "192.168.1.255", "224.0.0.1", "192.168.1.1", "127.0.0.1", "0.0.0.0" });
            comboBoxMethod.Location = new Point(94, 51);
            comboBoxMethod.Name = "comboBoxMethod";
            comboBoxMethod.Size = new Size(130, 23);
            comboBoxMethod.TabIndex = 4;
            comboBoxMethod.SelectedIndexChanged += comboBoxMethod_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 54);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 3;
            label2.Text = "Method:";
            // 
            // buttonQnapWakeOnLan
            // 
            buttonQnapWakeOnLan.Location = new Point(111, 170);
            buttonQnapWakeOnLan.Name = "buttonQnapWakeOnLan";
            buttonQnapWakeOnLan.Size = new Size(113, 33);
            buttonQnapWakeOnLan.TabIndex = 0;
            buttonQnapWakeOnLan.Text = "Wake On Lan";
            buttonQnapWakeOnLan.UseVisualStyleBackColor = true;
            buttonQnapWakeOnLan.Click += buttonWakeOnLan_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(textBoxPublicIP);
            groupBox2.Controls.Add(buttonQnapWakeOnLanRemote);
            groupBox2.Location = new Point(12, 262);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(241, 119);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Public Router IP";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 28);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 1;
            label1.Text = "Public IP target:";
            // 
            // textBoxPublicIP
            // 
            textBoxPublicIP.Location = new Point(102, 25);
            textBoxPublicIP.Name = "textBoxPublicIP";
            textBoxPublicIP.Size = new Size(122, 23);
            textBoxPublicIP.TabIndex = 0;
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Location = new Point(24, 99);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(183, 15);
            linkLabel3.TabIndex = 4;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "https://www.myqnapcloud.com/";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(24, 68);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(134, 15);
            linkLabel2.TabIndex = 3;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "https://nosnet.pt/router";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(24, 40);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(186, 15);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://my.noip.com/dns/records";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(linkLabel4);
            groupBox3.Controls.Add(linkLabel1);
            groupBox3.Controls.Add(linkLabel3);
            groupBox3.Controls.Add(linkLabel2);
            groupBox3.Location = new Point(278, 15);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(248, 284);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Find my public IP";
            // 
            // linkLabel4
            // 
            linkLabel4.AutoSize = true;
            linkLabel4.Location = new Point(27, 140);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(191, 15);
            linkLabel4.TabIndex = 5;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "https://quickconnect.to/belokanto";
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(454, 305);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(77, 33);
            buttonClose.TabIndex = 6;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(543, 437);
            Controls.Add(buttonClose);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Send Wake On Lan";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonQnapWakeOnLanRemote;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private TextBox textBoxPublicIP;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel3;
        private Button buttonWakeOnLan;
        private Button buttonSshSleep;
        private Button buttonClose;
        private ComboBox comboBoxMethod;
        private Label label2;
        private GroupBox groupBox3;
        private LinkLabel linkLabel4;
        private Button buttonQnapWakeOnLan;
        private ComboBox comboBoxName;
        private Label label3;
        private TextBox textBoxMacAddress;
        private Label label4;
        private TextBox textBoxPort;
        private Label label5;
        private TextBox textBoxTargetIp;
        private Label label6;
    }
}
