using PlayChain.Node.NodeConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChain.Node.Model
{
    [Serializable]
    public class NodeConfiguration
    {
        public NodeConfiguration(bool shouldInitialzeDefault = true)
        {
            if(shouldInitialzeDefault)
            {
                InitialDefaultConfig();
            }
        }
       
        public int Port { get; set; }
        public string IpAddress { get; set; }
        public HashSet<long> KnownIpAddresses { get; set; }

        private void InitialDefaultConfig()
        {
            Port = DefaultConfiguration.PORT;
            IpAddress = DefaultConfiguration.IPADDRESS;
            KnownIpAddresses = new HashSet<long>();
        }
    }
}
