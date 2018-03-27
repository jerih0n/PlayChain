using PlayChain.Node.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PlayChain.Logic.Connecting
{
    public class NodeReceiver
    {
        #region Fields
        private Enumerators.ReceiverStatus _status = Enumerators.ReceiverStatus.NotListening;
        private string _nodeIpAddress;
        private int _openPort;
        private string a;
        private Socket _socket;
        private IPAddress _address;
        #endregion

        public NodeReceiver(string nodeIpAddress, int port)
        {
            _nodeIpAddress = nodeIpAddress;
            NodeIpAddress = _nodeIpAddress;
            _openPort = port;
            Port = _openPort;
            _address = IPAddress.Parse(nodeIpAddress);
            _socket = new Socket(_address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(new IPEndPoint(_address, port));
            
        }

        #region Public Properties
        public string NodeIpAddress { get; private set; }
        public int Port { get; private set; }
        public Enumerators.ReceiverStatus Status { get; private set; }
        #endregion

        #region Public Methods
        public void StartListener()
        {
            this.Status = Enumerators.ReceiverStatus.Listening;
            _socket.Listen(Int32.MaxValue);
            _socket.BeginAccept(AcceptConnectionAttempt, _socket);
        }

        private void AcceptConnectionAttempt(IAsyncResult ar)
        {
            Socket sock = (Socket)ar.AsyncState;
            byte[] buffer = new byte[65535];
            sock.BeginReceive(buffer, 0, buffer.Length, SocketFlags.Broadcast, OnRecieved, sock);
        }

        private void OnRecieved(IAsyncResult ar)
        {
            
            byte[] buffer = new byte[65535];
            Socket sock = (Socket)ar.AsyncState;
            var end = sock.EndReceive(ar);
            if(end > 0)
            {
                var str = Encoding.Unicode.GetString(buffer, 0, end);
                Console.WriteLine(str);
            }
            sock.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, OnRecieved, sock);
        }

        #endregion
    }
}
