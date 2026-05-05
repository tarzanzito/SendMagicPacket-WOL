using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;


namespace WakeOnLan
{
    public static class MagicPacketSimple
    {
        #region public const

        public const string DefaultBroadcastIp = "255.255.255.255";    // Common Broadcast
        public const string DefaulMulticastIp = "224.0.0.1";           // Multicast, All-Systems, All-Hosts
        public const string DefaultLoopbackIp = "127.0.0.1";           // Common localhost
        public const string DefaultGatewayIp = "192.168.1.1";          // Common gateway for home networks
        public const string DefaultLocalBroadcastIp = "192.168.1.255"; // Common local Broadcast
        public const string DefaultAnyIp = "0.0.0.0";

        #endregion

        #region public static methods

        public static void SendToBroadcast(string macAddress, int port = 9)
        {
            SendToTarget(macAddress, DefaultBroadcastIp, port); // Broadcast
        }

        public static void SendToLocalBroadcast(string macAddress, int port = 9)
        {
            SendToTarget(macAddress, DefaultLocalBroadcastIp, port);  // local Broadcast
        }

        public static void SendToMulticast(string macAddress, int port = 9)
        {
            SendToTarget(macAddress, DefaulMulticastIp, port); // Multicast, All-Systems, All-Hosts
        }

        public static void SendToLoopback(string macAddress, int port = 9)
        {
            SendToTarget(macAddress, DefaultLoopbackIp, port); // Loopback
        }

        public static void SendToGateway(string macAddress, int port = 9)
        {
            SendToTarget(macAddress, DefaultGatewayIp, port);
        }

        public static void SendToAny(string macAddress, int port = 9)
        {
            //ERROR: System.Net.Sockets.SocketException: 'The requested address is not valid in its context.'
            SendToTarget(macAddress, DefaultAnyIp, port); //any
        }

        public static void SendToTarget(string macAddress, string targetIp, int port = 9)
        {
            byte[] magicPacket = BuildMagicPacket(macAddress);

            IPAddress ipAddress = IPAddress.Parse(targetIp);
            SendWakeOnLan(ipAddress, port, magicPacket);
        }

        #endregion

        #region private static methods top

        private static void SendWakeOnLan(IPAddress ipAddress, int port, byte[] magicPacket)
        {
            using (UdpClient client = new UdpClient())
            {
                //client.EnableBroadcast = true;  //NOTE: for me witn 'false' works too
                IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
                client.Send(magicPacket, magicPacket.Length, endPoint);
            }

            //DotNet 8 or greater
            //using UdpClient client = new UdpClient();
            //client.EnableBroadcast = true;  //NOTE: for me witn 'false' works too

            //IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
            //client.Send(magicPacket, magicPacket.Length, endPoint);
        }

        //not tested yet
        private static void SendSocket(IPAddress ipAddress, int port, byte[] magicPacket)
        {
            IPEndPoint endPoint = new IPEndPoint(ipAddress, port);

            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sock.Bind(endPoint);
            sock.Send(magicPacket, 0, magicPacket.Length, SocketFlags.None);
        }

        private static byte[] BuildMagicPacket(string macAddress)
        {
            string upperMacAddress = macAddress.ToUpper();

#if USE_REG_EX
            string cleanMacAddress = GetCleanMacAddressRegEx(upperMacAddress);
#else
            string cleanMacAddress = GetCleanMacAddress(upperMacAddress);
#endif

            //Magic Packet Structure:
            byte[] dataArray = new byte[102];

            int counter = 0;

            //Preamble : 6 times with 0xFF
            for (int x = 0; x < 6; x++)
                dataArray[counter++] = 0xFF;

            //Payload: repeat 16 times with the mac address
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

#endregion

        #region private static methods NO regex

        private static string GetCleanMacAddress(string macAddress)
        {
            string cleanMacAddress = CleanMacAddress(macAddress);

            ValidateMacAddress(macAddress, true);

            return cleanMacAddress;
        }

        private static string CleanMacAddress(string macAddress)
        {
            //remove all ':', '-', ' ' and convert to uppercase
            return macAddress.Replace(":", "").Replace("-", "").Replace(" ", "");
        }

        private static void ValidateMacAddress(string macAddress, bool uppercase)
        {
            string macAddressTemp;

            if (macAddress.Length == 17)
                macAddressTemp = CleanMacAddress(macAddress);
            else
                macAddressTemp = macAddress;

            if (macAddressTemp.Length != 12)
                throw new ArgumentException($"Invalid MAC address length. [{macAddress}]");

            bool isValid = IsOnlyLettersAndNumbers(macAddressTemp, uppercase);

            if (!isValid)
                throw new ArgumentException($"MAC address must have only letters (Upper) and numbers. [{macAddress}]");
        }

        private static bool IsOnlyLettersAndNumbers(string data, bool uppercase)
        {

            if (uppercase)
            {
                //Checks if the string contains only uppercase letters and numbers
                return data.All(c => (Char.IsLetter(c) && Char.IsUpper(c)) || Char.IsDigit(c));
            }
            else
            {
                //Checks if the string contains only letters and numbers.
                return data.All(c => Char.IsLetter(c) || Char.IsDigit(c));
            }
        }

        #endregion

        #region private static methods REGEX

        private static string GetCleanMacAddressRegEx(string macAddress)
        {
            string cleanMacAddress = CleanMacAddressRegEx(macAddress);

            ValidateMacAddressRegex(cleanMacAddress, true);

            return cleanMacAddress;
        }

        private static string CleanMacAddressRegEx(string macAddress)
        {
            //remove all ':', '-', ' ' and convert to uppercase

            //I don't like Regex !!! :(
            return Regex.Replace(macAddress, "[: -]", "");
        }

        private static void ValidateMacAddressRegex(string macAddress, bool uppercase)
        {
            string macAddressTemp;

            if (macAddress.Length == 17)
                macAddressTemp = CleanMacAddressRegEx(macAddress);
            else
                macAddressTemp = macAddress;

            if (macAddressTemp.Length != 12)
                throw new ArgumentException($"Invalid MAC address length. [{macAddress}]");

            bool isValid = IsOnlyLettersAndNumbersEx(macAddressTemp, uppercase);

            if (!isValid)
                throw new ArgumentException($"MAC address must have only letters (Upper) and numbers. [{macAddress}]");
        }

        private static bool IsOnlyLettersAndNumbersEx(string data, bool uppercase)
        {
            //I don't like Regex !!! :( 
            if (uppercase)
            {
                //Checks if the string contains only uppercase letters and numbers
                return Regex.IsMatch(data, @"^[A-Z0-9]+$");
            }
            else
            {
                //Checks if the string contains only letters and numbers.
                return Regex.IsMatch(data, @"^[a-zA-Z0-9]+$");
            }
        }

        #endregion

    }
}
//
//Send WOL 255.255.255.255 (limited broadcast) vs 224.0.0.1 (all-hosts multicast)
// Sending a Wake - on - LAN(WoL) "magic packet" to 255.255.255.255 (limited broadcast)
// versus 224.0.0.1 (all-hosts multicast) serves the same fundamental purpose—waking a
// machine on the local network—but they differ in how network hardware treats them. 
//
//255.255.255.255 (Global/Limited Broadcast) is the traditional, most common method for WoL.
//It sends the packet to every device on the local network segment.
//224.0.0.1 (All-Hosts Multicast) is a more efficient approach that targets only hosts
//  that have joined the "all-hosts" multicast group, often reducing unnecessary traffic
//  for other network devices.
//
//Detailed Comparison
//Feature:         255.255.255.255 (Broadcast)	           - 224.0.0.1 (Multicast)
//Type:            Limited Broadcast (Layer 3)	           - Link-Local Multicast (Layer 3)
//Scope:           Local Subnet Only	                   - Local Subnet Only
//Recipient:	   Every device on the segment             - Devices that joined the group
//Reliability:	   Very High (Standard for WOL)            - High (Depends on IGMP/Multicast support)
//Network Impact:  Higher traffic (All devices process it) - Lower traffic (More efficient)
//Router Behavior: Blocked by routers                      - Not forwarded by routers
//
//Key Takeaways
// * 255.255.255.255: This is often preferred for simplicity.Because the target MAC address
//   is embedded in the magic packet(FF: FF:FF: FF:FF: FF layer - 2 frame),
//   it will reach its target regardless of the IP address.
//
// * 224.0.0.1: This is technically more "polite" on a network because it avoids waking up
//   network interface cards(NICs) on machines that don't need to be woken up,
//   assuming the NIC's driver filters multicast properly.
//
// * Best Practice: If you are within the same subnet, 255.255.255.255 is the most reliable option.
//   If you have issues with network flooding or specialized managed switches
//   that block broadcasts, 224.0.0.1 might be necessary, though both fail if they have to
//   pass through a router. 
//
//Both methods, when used with the appropriate magic packet, work on the
// data link layer (Layer 2) to command the Network Interface Card (NIC) to turn on the computer.

//And about "192.168.1.255" (local broadcast) is a specific broadcast address for a common private network range (

//------------------------------------------------------------------------------

//References:
//https://github.com/asifbacchus/ps-cmdlet-wol?tab=readme-ov-file#broadcast-considerations
//https://github.com/asifbacchus/ps-cmdlet-wol
