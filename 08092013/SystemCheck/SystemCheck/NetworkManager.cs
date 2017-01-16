using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;


namespace LicenseManager
{
    class NetworkManager
    {
        public string GetMACID()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            
            // Only check the first NIC card
            NetworkInterface adapter = nics[0];
            IPInterfaceProperties properties = nics[0].GetIPProperties();

            return adapter.GetPhysicalAddress().ToString();
        }
    }
}
