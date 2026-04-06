
namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Sending Wake-on-LAN packet...");

            //NOT WORKING: for me, but should work in theory 
            //Probably because i have several "Network Connections".
            //They were created by VMware and Virtualbox.
            //See my 'ipconfig.txt' file.
            //WakeOnLan.MagicPacketSimple.SendBroadcast("00-08-9B-F8-2D-9B", 9); // "255.255.255.255"

            //SUCCESS
            WakeOnLan.MagicPacketSimple.SendToLocalBroadcast("00-08-9B-F8-2D-9B", 9); // "192.168.1.255"

            //SUCCESS
            //WakeOnLan.MagicPacketSimple.SendToMulticast("00-08-9B-F8-2D-9B", 9); // "224.0.0.1"

            //NOT WORKING:
            //WakeOnLan.MagicPacketSimple.SendToLoopback("00-08-9B-F8-2D-9B", 9); // "127.0.0.1"

            //NOT WORKING:
            //WakeOnLan.MagicPacketSimple.SendToGateway("00-08-9B-F8-2D-9B", 9); // "192.168.1.1"

            //ERROR:System.Net.Sockets.SocketException: 'The requested address is not valid in its context.'
            //WakeOnLan.MagicPacketSimple.SendToAny("00-08-9B-F8-2D-9B", 9); // "0.0.0.0"

            //SUCESS (Directly to target NAS)
            //WakeOnLan.MagicPacketSimple.SendToTarget("00-08-9B-F8-2D-9B", "192.168.9", 9);


            Console.WriteLine("Wake-on-LAN packet sent.");
        }
    }
}