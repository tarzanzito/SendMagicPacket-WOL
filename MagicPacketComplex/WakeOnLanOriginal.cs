using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace WOL 
{
    //
    //original from net run with success
    //
    public static class MagicPackOriginal
    {
        public static async Task WakeOnLan(string macAddress)
        {
            byte[] magicPacket = BuildMagicPacket(macAddress);

            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces().Where((n) =>
                n.NetworkInterfaceType != NetworkInterfaceType.Loopback && n.OperationalStatus == OperationalStatus.Up))
            {
                IPInterfaceProperties iPInterfaceProperties = networkInterface.GetIPProperties();

                foreach (MulticastIPAddressInformation multicastIPAddressInformation in iPInterfaceProperties.MulticastAddresses)
                {

                    IPAddress multicastIpAddress = multicastIPAddressInformation.Address;

                    if (multicastIpAddress.ToString().StartsWith("ff02::1%", StringComparison.OrdinalIgnoreCase)) // Ipv6: All hosts on LAN (with zone index)
                    {
                        UnicastIPAddressInformation? unicastIPAddressInformation = iPInterfaceProperties.UnicastAddresses.Where((u) =>
                            u.Address.AddressFamily == AddressFamily.InterNetworkV6 && !u.Address.IsIPv6LinkLocal).FirstOrDefault();

                        if (unicastIPAddressInformation != null)
                        {
                            await SendWakeOnLan(unicastIPAddressInformation.Address, multicastIpAddress, magicPacket);
                        }

                    }
                    else
                    {
                        if (multicastIpAddress.ToString().Equals("224.0.0.1")) // Ipv4: All hosts on LAN
                        {
                            UnicastIPAddressInformation? unicastIPAddressInformation = iPInterfaceProperties.UnicastAddresses.Where((u) =>
                                u.Address.AddressFamily == AddressFamily.InterNetwork && !iPInterfaceProperties.GetIPv4Properties().IsAutomaticPrivateAddressingActive).FirstOrDefault();
                            if (unicastIPAddressInformation != null)
                            {
                                await SendWakeOnLan(unicastIPAddressInformation.Address, multicastIpAddress, magicPacket);
                            }
                        }
                    }
                }
            }
        }

        private static byte[] BuildMagicPacket(string macAddress) // MacAddress in any standard HEX format
        {
            macAddress = Regex.Replace(macAddress, "[: -]", "");
            byte[] macBytes = Convert.FromHexString(macAddress);

            IEnumerable<byte> header = Enumerable.Repeat((byte)0xff, 6); //First 6 times 0xff
            IEnumerable<byte> data = Enumerable.Repeat(macBytes, 16).SelectMany(m => m); // then 16 times MacAddress
            return header.Concat(data).ToArray();
        }

        private static async Task SendWakeOnLan(IPAddress localIpAddress, IPAddress multicastIpAddress, byte[] magicPacket)
        {
            using UdpClient client = new(new IPEndPoint(localIpAddress, 0));

            await client.SendAsync(magicPacket, magicPacket.Length, new IPEndPoint(multicastIpAddress, 9)); // port 9 sucess
        }
    }
}

//===========================
//My Notes
//
//224.0.0.1 is the reserved "All-Hosts" multicast group address, used to communicate
//with all multicast-capable devices on a local network segment (subnet).
//It is a link-local address, meaning it is not routed beyond the local network.
//It is commonly used for network management, such as IGMP Queries in this
//Cisco Community forum post 
//https://community.cisco.com/t5/switching/why-switch-generating-traffic-for-224-0-0-1/td-p/1441939
//and mDNS in this PCMag article
//https://www.pcmag.com/encyclopedia/term/ip-multicast

//Key details about 224.0.0.1 include:
// - Purpose: Allows one device to send a single packet that is received by all other devices on the same network that have joined the group.

// - Scope: It is restricted to the local link(subnet), as 224.0.0.1 is not routed beyond local routers, as explained in this Barix Help Center article.

// -Function: It is primarily used by protocols like Internet Group Management Protocol (IGMP) to determine which hosts want to receive specific multicast traffic.

// - Visibility: You might see it in firewall logs, which is typically harmless, as shown in this Reddit thread and this Netgate Forum thread.
//https://www.reddit.com/r/linuxadmin/comments/4neuk0/224001_in_ufw_logs/
//https://forum.netgate.com/topic/129797/traffic-coming-from-0-0-0-0-ethernet-switch

//===========================