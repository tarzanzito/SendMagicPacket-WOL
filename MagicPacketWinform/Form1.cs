using System;
using System.Windows.Forms;

namespace MagicPacketWinform
{
    public partial class Form1 : Form
    {
        private enum NasName
        {
            Qnap,
            Synology
        }

        private enum Method
        {
            Broadcast,
            Multicast,
            Loopback,
            Gateway,
            LocalBroadcast,
            Any
        }

        private bool isFormMounted = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                NasNameInitialize();
                MethodInitialize();

                isFormMounted = true;

                RefreshForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during form load: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during form close: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonWakeOnLan_Click(object sender, EventArgs e)
        {
            try
            {
                int port = int.Parse(textBoxPort.Text);
                string macAddress = textBoxMacAddress.Text;
                string targetIp = textBoxTargetIp.Text;

                WakeOnLan.MagicPacketSimple.SendToTarget(macAddress, targetIp, port);

                MessageBox.Show("Magic packet sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending magic packet: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during 'comboBoxId_SelectedIndexChanged': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during 'comboBoxMethod_SelectedIndexChanged': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NasNameInitialize()
        {
            string[] nasNameArray = Enum.GetNames(typeof(NasName));

            comboBoxName.Items.Clear();
            comboBoxName.Items.AddRange(nasNameArray);

            //set default
            comboBoxName.Text = (comboBoxName.Items[0] ?? string.Empty).ToString();
        }

        private void MethodInitialize()
        {
            string[] methodArray = Enum.GetNames(typeof(Method));

            comboBoxMethod.Items.Clear();
            comboBoxMethod.Items.AddRange(methodArray);

            //set default
            comboBoxMethod.Text = (comboBoxMethod.Items[4] ?? string.Empty).ToString();
        }

        private void RefreshFormNasName()
        {
            NasName nasName = (NasName)Enum.Parse(typeof(NasName), comboBoxName.Text, true);

            switch (nasName)
            {
                case NasName.Qnap:
                    textBoxMacAddress.Text = "00-08-9B-F8-2D-9B";
                    textBoxPort.Text = "9";
                    break;

                case NasName.Synology:
                    textBoxMacAddress.Text = "TODO:";
                    textBoxPort.Text = "8";
                    break;

                default:
                    throw new Exception($"Invalid '{nameof(NasName)}' selection");
            }
        }

        private void RefreshFormMethod()
        {
            Method methodName = (Method)Enum.Parse(typeof(Method), comboBoxMethod.Text, true);

            switch (methodName)
            {
                case Method.Broadcast:
                    textBoxTargetIp.Text = WakeOnLan.MagicPacketSimple.DefaultBroadcastIp;
                    break;

                case Method.Multicast:
                    textBoxTargetIp.Text = WakeOnLan.MagicPacketSimple.DefaulMulticastIp;
                    break;

                case Method.Loopback:
                    textBoxTargetIp.Text = WakeOnLan.MagicPacketSimple.DefaultLoopbackIp;
                    break;

                case Method.Gateway:
                    textBoxTargetIp.Text = WakeOnLan.MagicPacketSimple.DefaultGatewayIp;
                    break;

                case Method.LocalBroadcast:
                    textBoxTargetIp.Text = WakeOnLan.MagicPacketSimple.DefaultLocalBroadcastIp;
                    break;

                case Method.Any:
                    textBoxTargetIp.Text = WakeOnLan.MagicPacketSimple.DefaultAnyIp;
                    break;

                default:
                    throw new Exception($"Invalid '{nameof(Method)}' selection");
            }
        }

        private void RefreshForm()
        {
            if (!isFormMounted)
                return;

            RefreshFormNasName();

            RefreshFormMethod();
        }


    }
}
