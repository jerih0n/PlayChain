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
       
        public int PortListen { get; set; }
        public int PortConnect { get; set; }
        public string IpAddress { get; set; }
        public HashSet<long> KnownIpAddresses { get; set; }

        private void InitialDefaultConfig()
        {
            PortConnect = DefaultConfiguration.PORT_CONNECT;
            PortListen = DefaultConfiguration.PORT_LISTEN;
            IpAddress = DefaultConfiguration.IPADDRESS;
            KnownIpAddresses = new HashSet<long>();
            
        }
    }
}
