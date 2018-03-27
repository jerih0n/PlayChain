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
        
        private Dictionary<long, Socket> _allConnections;
        private Socket _socket;
        private IPAddress _address;
        public NodeConnector(string nodeIpAddress, int port)
        {
            _address = IPAddress.Parse(nodeIpAddress);
            _socket = new Socket(_address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(new IPEndPoint(_address, port));
            this._allConnections = new Dictionary<long, Socket>();           
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
        public Enumerators.ConnectionResponse AddNewConnection(string IPaddress, int port)
        {
            var ipAsLong = 5;
            //var ipAsLong = Common.CommonOperations.ConvertIPAddressFromString(IPaddress);
            if (!_allConnections.ContainsKey(ipAsLong))
            {
                
                TryConnect(Common.CommonOperations.ConvertIpAddressFromStringToByteArr(IPaddress), port);
                
            }

            return Enumerators.ConnectionResponse.ConnectionExist;
        }       
        #endregion

        #region Private
        private void TryConnect(byte[] ipAddress, int port)
        {
            var result = Enumerators.ConnectionResponse.FaildToAddConnection;
            var address = new IPAddress(ipAddress);

            _socket.BeginConnect(new IPEndPoint(address, port), OnConnect, _socket);
        }

        private void OnConnect(IAsyncResult ar)
        {
            var socket = (Socket)ar.AsyncState;
            socket.EndConnect(ar);
            var simpleMsg = "Hello World!";
            var bytes = Encoding.Unicode.GetBytes(simpleMsg);
            socket.Send(bytes);
        }

        #endregion
    }
}
