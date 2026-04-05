using System.Drawing;
using System.Windows.Forms;

namespace SSHWinForms
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
            buttonQnapWakeOnLan = new Button();
            buttonQnapSshSleep = new Button();
            buttonQnapWakeOnLanRemote = new Button();
            groupBox1 = new GroupBox();
            buttonQnapSshSleepRemote = new Button();
            groupBox2 = new GroupBox();
            linkLabel3 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            textBoxPublicIP = new TextBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // buttonQnapWakeOnLan
            // 
            buttonQnapWakeOnLan.Location = new Point(30, 69);
            buttonQnapWakeOnLan.Name = "buttonQnapWakeOnLan";
            buttonQnapWakeOnLan.Size = new Size(186, 44);
            buttonQnapWakeOnLan.TabIndex = 0;
            buttonQnapWakeOnLan.Text = "Wake On Lan";
            buttonQnapWakeOnLan.UseVisualStyleBackColor = true;
            buttonQnapWakeOnLan.Click += buttonWakeOnLan_Click;
            // 
            // buttonQnapSshSleep
            // 
            buttonQnapSshSleep.Location = new Point(222, 69);
            buttonQnapSshSleep.Name = "buttonQnapSshSleep";
            buttonQnapSshSleep.Size = new Size(138, 44);
            buttonQnapSshSleep.TabIndex = 1;
            buttonQnapSshSleep.Text = "SSH Sleep";
            buttonQnapSshSleep.UseVisualStyleBackColor = true;
            buttonQnapSshSleep.Click += buttonSshSleep_Click;
            // 
            // buttonQnapWakeOnLanRemote
            // 
            buttonQnapWakeOnLanRemote.Location = new Point(30, 119);
            buttonQnapWakeOnLanRemote.Name = "buttonQnapWakeOnLanRemote";
            buttonQnapWakeOnLanRemote.Size = new Size(186, 50);
            buttonQnapWakeOnLanRemote.TabIndex = 1;
            buttonQnapWakeOnLanRemote.Text = "Wake On Lan Remote";
            buttonQnapWakeOnLanRemote.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(buttonQnapSshSleepRemote);
            groupBox1.Controls.Add(buttonQnapWakeOnLanRemote);
            groupBox1.Controls.Add(buttonQnapSshSleep);
            groupBox1.Controls.Add(buttonQnapWakeOnLan);
            groupBox1.Location = new Point(48, 140);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(431, 213);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "QNAP";
            // 
            // buttonQnapSshSleepRemote
            // 
            buttonQnapSshSleepRemote.Location = new Point(222, 125);
            buttonQnapSshSleepRemote.Name = "buttonQnapSshSleepRemote";
            buttonQnapSshSleepRemote.Size = new Size(138, 44);
            buttonQnapSshSleepRemote.TabIndex = 2;
            buttonQnapSshSleepRemote.Text = "SSH Sleep";
            buttonQnapSshSleepRemote.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(linkLabel3);
            groupBox2.Controls.Add(linkLabel2);
            groupBox2.Controls.Add(linkLabel1);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(textBoxPublicIP);
            groupBox2.Location = new Point(48, 19);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(498, 96);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Public Router IP";
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Location = new Point(261, 65);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(183, 15);
            linkLabel3.TabIndex = 4;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "https://www.myqnapcloud.com/";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(262, 47);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(134, 15);
            linkLabel2.TabIndex = 3;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "https://nosnet.pt/router";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(262, 19);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(186, 15);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://my.noip.com/dns/records";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 28);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 1;
            label1.Text = "Public IP:";
            // 
            // textBoxPublicIP
            // 
            textBoxPublicIP.Location = new Point(75, 25);
            textBoxPublicIP.Name = "textBoxPublicIP";
            textBoxPublicIP.Size = new Size(139, 23);
            textBoxPublicIP.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 28);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 3;
            label2.Text = "Target IP:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "255.255.255.255", "224.0.0.1", "192.168.1.255", "192.168.1.1", "127.0.0.1", "0.0.0.0" });
            comboBox1.Location = new Point(82, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(134, 23);
            comboBox1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 437);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonQnapWakeOnLan;
        private Button buttonQnapSshSleep;
        private Button buttonQnapWakeOnLanRemote;
        private GroupBox groupBox1;
        private Button buttonQnapSshSleepRemote;
        private GroupBox groupBox2;
        private Label label1;
        private TextBox textBoxPublicIP;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel3;
        private Button buttonWakeOnLan;
        private Button buttonSshSleep;
        private Button button1;
        private ComboBox comboBox1;
        private Label label2;
    }
}
