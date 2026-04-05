using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace WakeOnLan
{
    public static class MagicPacketSimple
    {
        public static void Broadcast(string macAddress, int port = 9)
        {
            byte[] magicPacket = BuildMagicPacket(macAddress);

            SendWakeOnLan(port, magicPacket);
        }

        private static void SendWakeOnLan(int port, byte[] magicPacket)
        {
            using UdpClient client = new UdpClient() { EnableBroadcast = true };
            client.Connect(IPAddress.Broadcast, port);
            client.Send(magicPacket, magicPacket.Length);
        }

        private static string GetCleanMacAddress(string macAddress)
        {
            string cleanMacAddress = macAddress.Replace(":", "").Replace("-", "").Replace(" ", "").ToUpper();

            if (cleanMacAddress.Length != 12)
                throw new ArgumentException($"Invalid MAC address length. [{macAddress}]");

            bool isLettersAndNumbers = cleanMacAddress.All(c => (Char.IsLetter(c) && Char.IsUpper(c)) || Char.IsDigit(c));

            if (!isLettersAndNumbers)
                throw new ArgumentException($"Invalid MAC address format. [{macAddress}]");

            return cleanMacAddress;
        }

        private static byte[] BuildMagicPacket(string macAddress)
        {
            string cleanMacAddress = GetCleanMacAddress(macAddress);

            int counter = 0;
            byte[] dataArray = new byte[102];

            //header: 6 times with 0xff
            for (int x = 0; x < 6; x++)
                dataArray[counter++] = 0xFF;

            //data: 16 times with the mac address
            for (int x = 0; x < 16; x++)
            {
                for (int macBytes = 0; macBytes < 12; macBytes += 2)
                {
                    string temp = cleanMacAddress.Substring(macBytes, 2);
                    dataArray[counter++] = byte.Parse(temp, NumberStyles.HexNumber);
                }
            }

            return dataArray;
        }
    }
}

