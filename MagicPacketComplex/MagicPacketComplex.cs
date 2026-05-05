using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WakeOnLan
{
    // Source - https://stackoverflow.com/q/13634868
    //read   about -> multicast vs broadcast

    public static class MagicPacketComplex
    {
        public static void Broadcast(string macAddress, int port = 9)
        {
            IPAddress[] ipAdressArray =  GetAllLocalIPAddress();
            string[] ipAdressNameArray = GetAllLocalIPAddressName();


            IPAddress ip1 = GetLocalIPAddressV1(); //OK
            IPAddress ip2 = GetLocalIPAddressV2(); //OK
            IPAddress ip4 = GetLocalIPAddressV3();

            IPAddress ipDg1 = GetDefaultGatewayV1();
            IPAddress ipDg2 = GetLocalIPAddressV2();
            IPAddress ipDg3 = GetLocalIPAddressV3();


            string publicIPAddress = GetPublicIPAddress();

            string broadcastIp = IPAddress.Broadcast.ToString(); //  

            ///////////////////

            //224.0.0.1 is the reserved "All-Hosts" multicast group address,
            //used to communicate with all multicast-capable devices on a local network segment(subnet)
            const string MulticastIp = "224.0.0.1";

            byte[] magicPacket = BuildMagicPacket(macAddress);

            string myLocalIp = ip1.ToString();//My case "192.168.1.12"
            IPAddress localIpAddress = IPAddress.Parse(myLocalIp); 
            IPAddress multicastIpAddress = IPAddress.Parse(MulticastIp);

            SendWakeOnLan(localIpAddress, multicastIpAddress, port, magicPacket);
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

            //another way to do it 
            //byte[] macBytes = Convert.FromHexString(cleanMacAddress);
            //IEnumerable<byte> header = Enumerable.Repeat((byte)0xff, 6); //First 6 times 0xff
            //IEnumerable<byte> data = Enumerable.Repeat(macBytes, 16).SelectMany(m => m); // then 16 times MacAddress
            //return header.Concat(data).ToArray();
        }

        private static void SendWakeOnLan(IPAddress localIpAddress, IPAddress multicastIpAddress, int port, byte[] magicPacket)
        {
            IPEndPoint localIpEndPoint = new(localIpAddress, 0);
            IPEndPoint multicastIpEndPoint = new(multicastIpAddress, port);

            using UdpClient client = new(localIpEndPoint);
            client.Send(magicPacket, magicPacket.Length, multicastIpEndPoint);
        }

        #region Other methods to get local IP address and default gateway


        private static IPAddress[] GetAllLocalIPAddress()
        {
            string hostName = Dns.GetHostName();

            IPAddress[] ipAddressArray = Dns.GetHostAddresses(hostName);

            foreach (IPAddress ipAddress in ipAddressArray)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                    Console.WriteLine($"IP Address V4: [{ipAddress.ToString()}]");

                if (ipAddress.AddressFamily == AddressFamily.InterNetworkV6)
                    Console.WriteLine($"IP Address V6: {ipAddress.ToString()}");
            }

            return ipAddressArray;
        }

        private static string[] GetAllLocalIPAddressName()
        {
            string hostName = Dns.GetHostName();

            string[] ipAddressStringArray = Dns.GetHostAddresses(hostName).Select(x => x.ToString()).ToArray();

            return ipAddressStringArray;
        }



        private static IPAddress GetLocalIPAddressV1() //GetPrivateIP
        {
            NetworkInterface[] networkInterfaceArray = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in networkInterfaceArray)
            {
                if (networkInterface.OperationalStatus != OperationalStatus.Up)
                    continue;

                //count gateways, if it doesn't have one, it's not a valid network interface for our purposes
                int gatewaysCount = networkInterface.GetIPProperties().GatewayAddresses.Count();
                if (gatewaysCount == 0)
                    continue;

                UnicastIPAddressInformationCollection addressCollectionArray = networkInterface.GetIPProperties().UnicastAddresses;

                //UnicastIPAddressInformation? UnicastInfo = addressCollectionArray.First(x => x.Address.AddressFamily == AddressFamily.InterNetwork);
                UnicastIPAddressInformation? UnicastInfo = addressCollectionArray.FirstOrDefault(p => p.Address.AddressFamily == AddressFamily.InterNetwork);
                if (UnicastInfo == null)
                    continue;

                return UnicastInfo.Address;


                //find gateway, if it doesn't have one, it's not a valid network interface for our purposes
                //IPInterfaceProperties properties = networkInterface.GetIPProperties();
                //GatewayIPAddressInformationCollection GatewayCollection = properties.GatewayAddresses;
                //if (GatewayCollection.Count == 0)
                //    continue;

                ////bool hasAddressGateway = false;
                ////foreach (GatewayIPAddressInformation gatewayInfo in GatewayCollection)
                ////{
                ////    hasAddressGateway = true;
                ////    break;
                ////}

                ////if (!hasAddressGateway)
                ////    continue;


                //foreach (var addressItem in addressCollectionArray)
                //{
                //    //if (addressItem.Address.AddressFamily == AddressFamily.InterNetworkV6) // V6
                //    //{
                //    //    Console.WriteLine($"Network Interface UnicastAddresses V6: {addressItem.Address.ToString()}");
                //    //    return addressItem.Address;
                //    //}

                //    if (addressItem.Address.AddressFamily == AddressFamily.InterNetwork) // V4
                //    {
                //        //Console.WriteLine($"Network Interface UnicastAddresses V4: {addressItem.Address.ToString()}");
                //        return addressItem.Address;
                //    }
                //}

            }

            throw new Exception("No network adapters with an IPv4 address in the system!");

        }

        private static IPAddress GetLocalIPAddressV2() //GetPrivateIP
        {
            IPAddress? ipAddress = NetworkInterface
               .GetAllNetworkInterfaces()
               .Where(p => p.OperationalStatus == OperationalStatus.Up)
               .Where(p => p.NetworkInterfaceType != NetworkInterfaceType.Loopback)
               .SelectMany(s => s.GetIPProperties().GatewayAddresses)
               .Select(s => s.Address)
               .Where(a => a != null)
               .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
               // .Where(a => Array.FindIndex(a.GetAddressBytes(), b => b != 0) >= 0)
               .FirstOrDefault();

            return ipAddress ?? throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private static IPAddress GetLocalIPAddressV3() //GetPrivateIP
        {
            string hostName = Dns.GetHostName();
            IPAddress[] iPAddressArray = Dns.GetHostAddresses(hostName);

            foreach (IPAddress ipAddress in iPAddressArray)
            {
                Console.WriteLine(ipAddress.ToString());
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine("--->" + ipAddress.ToString());
                    //return ipAddress.ToString();
                }
            }

            return null;
        }
        private static string[] GetLocalIPAddressV99()
        {
            var ipList = NetworkInterface.GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .SelectMany(n => n.GetIPProperties().UnicastAddresses)
                .Where(a => a.Address.AddressFamily == AddressFamily.InterNetwork)
                .Select(a => a.Address.ToString())
                .ToArray();

            return ipList;
        }

        //private static IPAddress[] GetAllLocalIPAddress() 
        //{
        //    IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

        //    IPAddress[] ipAddress1 = host.AddressList;

        //    foreach (IPAddress ip in host.AddressList)
        //    {
        //        if (ip.AddressFamily == AddressFamily.InterNetwork)
        //        {
        //            Console.WriteLine($"return {ip.ToString()}");
        //            //Console.WriteLine($"return {ip..Address..ToString()}");
        //            //192.168.1.1
        //        }
        //    }

            //throw new Exception("No network adapters with an IPv4 address in the system!");

        //    return null;

            //var host = Dns.GetHostEntry(Dns.GetHostName());
            //var ipAddress = host.AddressList
            //    .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);

            //if (ipAddress == null)
            //    throw new Exception("No IPv4 address found for this machine.");

            //return ipAddress.ToString();
        //}
        


        private static async Task<string> GetPublicIPAddressAsync()
        {
            Uri url = new ("ttps://api.ipquery.io");

            using HttpClient client = new();

            string response = await client.GetStringAsync(url);

            return response.Trim();

        }

        private static string GetPublicIPAddress()
        {
            Uri url = new("https://api.ipquery.io");

            using HttpClient client = new();

            string response = client.GetStringAsync(url).GetAwaiter().GetResult();
            //best way compared to .Result or .Wait() because it unwraps the AggregateException
            //and throws the original exception if there is one, instead of an AggregateException
            //https://medium.com/@chikuokuo/what-different-between-result-and-getawaiter-getresult-f33c334af14b

            return response.Trim();
        }

        public static IPAddress GetDefaultGatewayV1()
        {
            
            NetworkInterface[] networkInterfaceArray = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in networkInterfaceArray)
            {
                if (networkInterface.OperationalStatus != OperationalStatus.Up)
                    continue;

                if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                    continue;

                IPInterfaceProperties properties = networkInterface.GetIPProperties();
                GatewayIPAddressInformationCollection GatewayCollection = properties.GatewayAddresses;
                
                foreach (GatewayIPAddressInformation gatewayInfo in GatewayCollection)
                {
                    return gatewayInfo.Address;
                }

            }

            throw new Exception("No default gateway found.");
        }

        public static IPAddress GetDefaultGatewayV2()
        {
            return NetworkInterface.GetAllNetworkInterfaces()[0].GetIPProperties().GatewayAddresses[0].Address;
        }

        public static IPAddress GetDefaultGatewayV3()
        {
            IPAddress? iPAddress = NetworkInterface.GetAllNetworkInterfaces()
                    .Where(p1 => p1.OperationalStatus == OperationalStatus.Up)
                    .Where(p1 => p1.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    .SelectMany(p1 => p1.GetIPProperties().GatewayAddresses)
                    .Select(p2 => p2.Address)
                    //.Where(p2 => p2.AddressFamily == AddressFamily.InterNetwork)
                    .FirstOrDefault(p3 => p3 != null);

            return iPAddress ?? throw new Exception("No default gateway found.");
        }

        #endregion Other methods to get local IP address and default gateway
    }
}

