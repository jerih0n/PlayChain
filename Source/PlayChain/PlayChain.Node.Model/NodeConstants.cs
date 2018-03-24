using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChain.Node.Model
{
    public static class NodeConstants
    {
        public static readonly HashSet<string> NodeCommands = new HashSet<string>()
        {
            "-help", // Get help menu
            "-connect", //Open Connection to know nodes if exist
            "-connect to", // Open connection to given IP address

        };
    }
}
