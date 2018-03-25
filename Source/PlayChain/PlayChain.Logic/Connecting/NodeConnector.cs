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
        
        private Dictionary<long, TcpClient> _allConnections;
        public NodeConnector()
        {
            this._allConnections = new Dictionary<long, TcpClient>();           
        }

        #region Public
        public void CloseAllConnections()
        {
            foreach(var connection in _allConnections)
            {
                connection.Value.Close();
            }
        }
        public int GetActiveConnectionsCount()
        {
            int activeConnectionsCount = 0;
            foreach(var pair in _allConnections)
            {
                if(pair.Value.Connected)
                {
                    activeConnectionsCount++;
                }
            }
            return activeConnectionsCount;
        }
        public bool AddNewConnection(string IPaddress, int port)
        {
            throw new NotImplementedException();
        }
        public bool AddNewConnection(long IPaddress, int port)
        {
            throw new Exception();
        }
        #endregion

        #region Private
        private void AddNewClient(long ipAddress, int port)
        {
            var address = new IPAddress(ipAddress);
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(address, port);
            }
            catch(SocketException ex)
            {              
            }
            catch(Exception)
            {

            }
        }
        #endregion
    }
}
