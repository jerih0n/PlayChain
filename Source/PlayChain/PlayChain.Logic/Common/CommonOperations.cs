using PlayChain.Node.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PlayChain.Logic.Common
{
    public static class CommonOperations
    {
        public static void PrintHelp()
        {
            Console.WriteLine(string.Format("Available Commands: "));
            foreach(var command in NodeConstants.NodeCommands)
            {
                Console.WriteLine("{0} {1}",command.Key, command.Value);
            }
        }
        public static long ConvertIPAddressFromString(string ipAddressInput)
        {
            return BitConverter.ToInt64(IPAddress.Parse(ipAddressInput).GetAddressBytes(), 0);
            
        }
        public static string ConvertLongInIPAddressString(long ipAddressInput)
        {
            return new IPAddress(BitConverter.GetBytes(ipAddressInput)).ToString();
        }
        public static byte[] ConvertIpAddressFromStringToByteArr(string ipAddressInput)
        {
            return IPAddress.Parse(ipAddressInput).GetAddressBytes();
        }
    }
}
