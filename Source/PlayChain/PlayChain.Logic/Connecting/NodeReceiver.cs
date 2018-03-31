using PlayChain.Node.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace PlayChain.Logic.Connecting
{
    public class NodeReceiver
    {
        #region Fields
        private const int BACKGROUND = 10;
        private Enumerators.ReceiverStatus _status = Enumerators.ReceiverStatus.NotListening;
        private string _nodeIpAddress;
        private int _openPort;
        private string a;
        private Socket _socket;
        private IPAddress _address;
        private List<Socket> _connectedSockets;
        private byte[] _defaultBuffer = new byte[2048];
        #endregion

        public NodeReceiver(string nodeIpAddress, int port)
        {
            _nodeIpAddress = nodeIpAddress;
            NodeIpAddress = _nodeIpAddress;
            _openPort = port;
            Port = _openPort;
            this._connectedSockets = new List<Socket>();
            _address = IPAddress.Parse(nodeIpAddress);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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
            _socket.Listen(BACKGROUND);
            _socket.BeginAccept(new AsyncCallback(AcceptConnectionAttempt),null);
        }

        private void AcceptConnectionAttempt(IAsyncResult ar)
        {
            Socket sock = _socket.EndAccept(ar); // client socket
            
            _connectedSockets.Add(sock);
            Console.WriteLine($"Client Connected! IP {((IPEndPoint)sock.RemoteEndPoint).Address} Port {((IPEndPoint)sock.RemoteEndPoint).Port}");
            sock.BeginReceive(_defaultBuffer, 0, _defaultBuffer.Length, SocketFlags.None, new AsyncCallback(OnRecieved), sock);
            _socket.BeginAccept(new AsyncCallback(AcceptConnectionAttempt), null);
            
        }
        
        private void OnRecieved(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int bytesRecieved = socket.EndReceive(ar);
            byte[] recievedInfoBytes = new byte[bytesRecieved];
            Array.Copy(_defaultBuffer, recievedInfoBytes, bytesRecieved);
            var msg = Encoding.ASCII.GetString(recievedInfoBytes);
            Console.WriteLine(msg);
            _socket.BeginReceive(_defaultBuffer, 0, _defaultBuffer.Length, SocketFlags.None, new AsyncCallback(OnRecieved), socket);
        }
        

        #endregion
    }
}
