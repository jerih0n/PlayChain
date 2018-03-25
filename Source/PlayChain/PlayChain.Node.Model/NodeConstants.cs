using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChain.Node.Model
{
    public static class NodeConstants
    {
        public static readonly string ConfigFileDirectory = "Config\\";
        public static readonly string ConfigName = "NodeConfig.json";
        public static readonly Dictionary<string,string> NodeCommands = new Dictionary<string, string>()
        {
            { "-help"," - get all commands" }, // Get help menu
            { "-connect", "- try connect to know PlayChain nodes"}, //Open Connection to know nodes if exist
            { "-connect to", "- try connect to unknow PlayChain node. Require IPAddress and port" }, // Open connection to given IP address

        };
    }
}
