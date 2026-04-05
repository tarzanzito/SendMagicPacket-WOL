using Renci.SshNet;
using System.Globalization;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Sending Wake-on-LAN packet...");

            //NOT WORKING: for me, but should work in theory
            //WakeOnLan.MagicPacketSimple.SendBroadcast("00-08-9B-F8-2D-9B", 9); // "255.255.255.255"

            //SUCCESS
            WakeOnLan.MagicPacketSimple.SendLocalBroadcast("00-08-9B-F8-2D-9B", 9); // "192.168.1.255"

            //WakeOnLan.MagicPacketSimple.SendMulticast("00-08-9B-F8-2D-9B", 9); // "224.0.0.1"

            //NOT WORKING:
            //WakeOnLan.MagicPacketSimple.SendLoopback("00-08-9B-F8-2D-9B", 9); // "127.0.0.1"

            //NOT WORKING:
            //WakeOnLan.MagicPacketSimple.SendGateway("00-08-9B-F8-2D-9B", 9); // "192.168.1.1"

            //ERROR:System.Net.Sockets.SocketException: 'The requested address is not valid in its context.'
            //WakeOnLan.MagicPacketSimple.SendToAny("00-08-9B-F8-2D-9B", 9); // "0.0.0.0"


            //WakeOnLan.MagicPacketSimple.SendToTarget("00-08-9B-F8-2D-9B", "192.168.9", 9);


            Console.WriteLine("Wake-on-LAN packet sent.");
        }
    }
}