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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonQnapWakeOnLanRemote = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxTargetIp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMacAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonQnapWakeOnLan = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPublicIP = new System.Windows.Forms.TextBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonQnapWakeOnLanRemote
            // 
            this.buttonQnapWakeOnLanRemote.Location = new System.Drawing.Point(55, 61);
            this.buttonQnapWakeOnLanRemote.Name = "buttonQnapWakeOnLanRemote";
            this.buttonQnapWakeOnLanRemote.Size = new System.Drawing.Size(137, 28);
            this.buttonQnapWakeOnLanRemote.TabIndex = 1;
            this.buttonQnapWakeOnLanRemote.Text = "Wake On Web (Remote)";
            this.buttonQnapWakeOnLanRemote.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxTargetIp);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxPort);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxMacAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxMethod);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonQnapWakeOnLan);
            this.groupBox1.Location = new System.Drawing.Point(10, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 191);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NAS";
            // 
            // textBoxTargetIp
            // 
            this.textBoxTargetIp.Location = new System.Drawing.Point(81, 94);
            this.textBoxTargetIp.Name = "textBoxTargetIp";
            this.textBoxTargetIp.ReadOnly = true;
            this.textBoxTargetIp.Size = new System.Drawing.Size(105, 20);
            this.textBoxTargetIp.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Target IP:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(81, 119);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.ReadOnly = true;
            this.textBoxPort.Size = new System.Drawing.Size(25, 20);
            this.textBoxPort.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Port:";
            // 
            // textBoxMacAddress
            // 
            this.textBoxMacAddress.Location = new System.Drawing.Point(81, 69);
            this.textBoxMacAddress.Name = "textBoxMacAddress";
            this.textBoxMacAddress.ReadOnly = true;
            this.textBoxMacAddress.Size = new System.Drawing.Size(112, 20);
            this.textBoxMacAddress.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "MAC Address:";
            // 
            // comboBoxName
            // 
            this.comboBoxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Location = new System.Drawing.Point(81, 19);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(58, 21);
            this.comboBoxName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name:";
            // 
            // comboBoxMethod
            // 
            this.comboBoxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMethod.FormattingEnabled = true;
            this.comboBoxMethod.Items.AddRange(new object[] {
            "255.255.255.255",
            "192.168.1.255",
            "224.0.0.1",
            "192.168.1.1",
            "127.0.0.1",
            "0.0.0.0"});
            this.comboBoxMethod.Location = new System.Drawing.Point(81, 44);
            this.comboBoxMethod.Name = "comboBoxMethod";
            this.comboBoxMethod.Size = new System.Drawing.Size(112, 21);
            this.comboBoxMethod.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Method:";
            // 
            // buttonQnapWakeOnLan
            // 
            this.buttonQnapWakeOnLan.Location = new System.Drawing.Point(95, 147);
            this.buttonQnapWakeOnLan.Name = "buttonQnapWakeOnLan";
            this.buttonQnapWakeOnLan.Size = new System.Drawing.Size(97, 29);
            this.buttonQnapWakeOnLan.TabIndex = 0;
            this.buttonQnapWakeOnLan.Text = "Wake On Lan";
            this.buttonQnapWakeOnLan.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxPublicIP);
            this.groupBox2.Controls.Add(this.buttonQnapWakeOnLanRemote);
            this.groupBox2.Location = new System.Drawing.Point(10, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 103);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Public Router IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Public IP target:";
            // 
            // textBoxPublicIP
            // 
            this.textBoxPublicIP.Location = new System.Drawing.Point(87, 22);
            this.textBoxPublicIP.Name = "textBoxPublicIP";
            this.textBoxPublicIP.Size = new System.Drawing.Size(105, 20);
            this.textBoxPublicIP.TabIndex = 0;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(21, 86);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(161, 13);
            this.linkLabel3.TabIndex = 4;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "https://www.myqnapcloud.com/";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(21, 59);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(119, 13);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://nosnet.pt/router";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(21, 35);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(164, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://my.noip.com/dns/records";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkLabel4);
            this.groupBox3.Controls.Add(this.linkLabel1);
            this.groupBox3.Controls.Add(this.linkLabel3);
            this.groupBox3.Controls.Add(this.linkLabel2);
            this.groupBox3.Location = new System.Drawing.Point(238, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(213, 246);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Find my public IP";
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(23, 121);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(172, 13);
            this.linkLabel4.TabIndex = 5;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "https://quickconnect.to/belokanto";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(389, 264);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(66, 29);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 379);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Wake On Lan";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

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
