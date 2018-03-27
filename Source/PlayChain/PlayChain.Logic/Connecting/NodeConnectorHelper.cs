using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PlayChain.Logic.Connecting
{
    public static class NodeConnectorHelper
    {
        public class Connection
        {
            public string IpAddress { get; set; }
            public int Port { get; set; }
        }

        public static Connection GetRequestedConnection()
        {
            Connection connection;
            Console.WriteLine("Ender connection in following variant IPADDRESS:PORT\nExample 127.0.0.1:80");
            var input = Console.ReadLine();
            IPAddress address;
            int port;
            var parts = input.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if(parts.Length != 2 
                || !IPAddress.TryParse(parts[0], out address)
                || !int.TryParse(parts[1],out port)
                || address.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork
                || (port < 0 || port > 65535 ))
            {
                throw new Exception("Invalid input");
            }
            return new Connection
            {
                IpAddress = parts[0],
                Port = port
            };
        }
    }
}
