using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChain.Node.Model
{
    [Serializable]
    public class NodeConfiguration
    {
        public int Port { get; set; }
        public string IpAddress { get; set; }
        public List<long> KnownIpAddresses { get; set; }
    }
}
