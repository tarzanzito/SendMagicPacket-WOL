using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace SSHWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonWakeOnLan_Click(object sender, EventArgs e)
        {
            WakeOnLan.MagicPacketSimple.Broadcast("00-08-9B-F8-2D-9B", 7); //OK
        }

        private void buttonSshSleep_Click(object sender, EventArgs e)
        {
            //IP=192.168.1.8 synology
            //IP=192.168.1.9 qnap
            //SSH Port= 2002 

            //https://sshnet.github.io/SSH.NET/examples.html

            //using (var client = new SshClient("192.168.1.9", 2002, "adminpaulogoncalves", new PrivateKeyFile("path/to/my/key")))

            using var client = new SshClient("192.168.1.8", 2002, "adminpaulogoncalves", "ubikubik+snas-1965");
            
            client.Connect();
            //using SshCommand cmd = client.RunCommand("echo 'Hello World!'");
            //Console.WriteLine(cmd.Result); // "Hello World!\n"
            //string res = cmd.Result;

            using SshCommand cmd1 = client.RunCommand("synopoweroff -s"); //not work
            using SshCommand cmd2 = client.RunCommand("sudo echo disk > /sys/power/state"); //deu problemas para fzer login no painel
                                                                                            //tive fazer restart pelo butão fisico

            string res = cmd1.Result;

            string aaa = "";

            //using (var client = new SftpClient("sftp.foo.com", "guest", "pwd"))
            //{
            //    client.Connect();

            //    using (FileStream fs = File.OpenRead(@"C:\tmp\test-file.txt"))
            //    {
            //        client.UploadFile(fs, "/home/guest/test-file.txt");
            //    }

            //    foreach (ISftpFile file in client.ListDirectory("/home/guest/"))
            //    {
            //        Console.WriteLine($"{file.FullName} {file.LastWriteTime}");
            //    }
            //}




        }
    }
}
