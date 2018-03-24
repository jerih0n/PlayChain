using PlayChain.Node.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PlayChain.Logic.Connecting
{
    public class NodeConnector
    {
        private Enumerators.ConnectorStatus _status = Enumerators.ConnectorStatus.Closed;
        public NodeConnector(string address, int port)
        {
            this.ConnectionStatus = _status;
            
        }
        #region Properties
        public Enumerators.ConnectorStatus ConnectionStatus { get; private set; }
        #endregion
    }
}
