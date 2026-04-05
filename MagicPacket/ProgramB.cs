using System.Globalization;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Timers;

//namespace ConsoleApp1
//{
//    internal class ProgramB
//    {

//        private static readonly string[] MAGIC_PACKET = new string[17]
//{
//    "FF-FF-FF-FF-FF-FF",
//    "00-08-9B-F8-2D-9B", //00-08-9B-F8-2D-9B,00-08-9B-F8-2D-9C
//    "00-08-9B-F8-2D-9C",
//    "TARGET DEVICE MAC ADDRESS",
//    "TARGET DEVICE MAC ADDRESS",
//    "TARGET DEVICE MAC ADDRESS",
//    "TARGET DEVICE MAC ADDRESS",
//    "TARGET DEVICE MAC ADDRESS",
//    "TARGET DEVICE MAC ADDRESS",
//    "TARGET DEVICE MAC ADDRESS",
//    "TARGET DEVICE MAC ADDRESS",
//    "TARGET DEVICE MAC ADDRESS",
//    "TARGET DEVICE MAC ADDRESS",
//    "TARGET DEVICE MAC ADDRESS",
//    "TARGET DEVICE MAC ADDRESS",
//    "TARGET DEVICE MAC ADDRESS",
//    "TARGET DEVICE MAC ADDRESS"
//};

//        private static readonly string BROADCAST_IP = "BROADCAST IP";

//        static void Main(string[] args)
//        {
//            Console.WriteLine($"Your broadcast IP: {IPAddress.Parse(BROADCAST_IP)}");
//            Console.WriteLine($"The MAC address to wake up is: {MAGIC_PACKET[1]}");
//            Console.WriteLine(string.Empty);
//            Console.Write($"Press any key to send the MAGIC PACKET...");
//            Console.Read();

//            Console.WriteLine(string.Empty);
//            Console.WriteLine($"Sending broadcast to {IPAddress.Broadcast}...");
//            SendWakeOnLan(PhysicalAddress.Parse(MAGIC_PACKET[1]));
//            Console.Write("Done! Press any key to exit...");

//            _ = Console.ReadKey();
//        }

//        static void SendWakeOnLan(PhysicalAddress target)
//        {
//            byte[] toByteArray(string[] addressBytes) => addressBytes.Select(b => Convert.ToByte(b, 16)).ToArray();

//            var magicPacket = MAGIC_PACKET.SelectMany(macAddress => toByteArray(macAddress.Split('-', ':'))).ToArray();
//            using (var client = new UdpClient())
//            {
//                client.Send(magicPacket, magicPacket.Length, new IPEndPoint(IPAddress.Parse(BROADCAST_IP), 9));
//            }
//        }

//        // Source - https://stackoverflow.com/a/447444
//        // Posted by Tarnay Kálmán, modified by community. See post 'Timeline' for change history
//        // Retrieved 2026-03-11, License - CC BY-SA 2.5

//        //You need SharpPcap for this to work

//        private void WakeFunction(string MAC_ADDRESS)
//        {
            
//            /* Retrieve the device list */
//            Tamir.IPLib.PcapDeviceList devices = Tamir.IPLib.SharpPcap.GetAllDevices();

//            /*If no device exists, print error */
//            if (devices.Count < 1)
//            {
//                Console.WriteLine("No device found on this machine");
//                return;
//            }

//            foreach (NetworkDevice device in devices)
//            {
//                //Open the device
//                device.PcapOpen();

//                //A magic packet is a broadcast frame containing anywhere within its payload: 6 bytes of ones
//                //(resulting in hexadecimal FF FF FF FF FF FF), followed by sixteen repetitions 

//                byte[] bytes = new byte[120];
//                int counter = 0;
//                for (int y = 0; y < 6; y++)
//                    bytes[counter++] = 0xFF;
//                //now repeat MAC 16 times
//                for (int y = 0; y < 16; y++)
//                {
//                    int i = 0;
//                    for (int z = 0; z < 6; z++)
//                    {
//                        bytes[counter++] =
//                            byte.Parse(MAC_ADDRESS.Substring(i, 2),
//                            NumberStyles.HexNumber);
//                        i += 2;
//                    }
//                }

//                byte[] etherheader = new byte[54];//If you say so...
//                var myPacket = new Tamir.IPLib.Packets.UDPPacket(EthernetFields_Fields.ETH_HEADER_LEN, etherheader);

//                //Ethernet
//                myPacket.DestinationHwAddress = "FFFFFFFFFFFFF";//it's buggy if you don't have lots of "F"s... (I don't really understand it...)
//                try { myPacket.SourceHwAddress = device.MacAddress; }
//                catch { myPacket.SourceHwAddress = "0ABCDEF"; }//whatever
//                myPacket.EthernetProtocol = EthernetProtocols_Fields.IP;

//                //IP
//                myPacket.DestinationAddress = "255.255.255.255";
//                try { myPacket.SourceAddress = device.IpAddress; }
//                catch { myPacket.SourceAddress = "0.0.0.0"; }
//                myPacket.IPProtocol = IPProtocols_Fields.UDP;
//                myPacket.TimeToLive = 50;
//                myPacket.Id = 100;
//                myPacket.Version = 4;
//                myPacket.IPTotalLength = bytes.Length - EthernetFields_Fields.ETH_HEADER_LEN;           //Set the correct IP length
//                myPacket.IPHeaderLength = IPFields_Fields.IP_HEADER_LEN;

//                //UDP
//                myPacket.SourcePort = 9;
//                myPacket.DestinationPort = 9;
//                myPacket.UDPLength = UDPFields_Fields.UDP_HEADER_LEN;


//                myPacket.UDPData = bytes;
//                myPacket.ComputeIPChecksum();
//                myPacket.ComputeUDPChecksum();

//                try
//                {
//                    //Send the packet out the network device
//                    device.PcapSendPacket(myPacket);
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine(e.Message);
//                }

//                device.PcapClose();
//            }
//        }
//    }
//}