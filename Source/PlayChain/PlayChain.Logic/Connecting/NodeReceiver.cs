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
        private TcpListener _globalListener;
        private string _nodeIpAddress;
        private int _openPort;
        private TcpClient _newTcpClient;
        private string a;
        #endregion

        public NodeReceiver(string nodeIpAddress, int port)
        {
            _nodeIpAddress = nodeIpAddress;
            NodeIpAddress = _nodeIpAddress;
            _openPort = port;
            Port = _openPort;
            var ipAddress = Common.CommonOperations.ConvertIpAddressFromStringToByteArr(nodeIpAddress);
            _globalListener = new TcpListener(new IPAddress(ipAddress), port);
        }

        #region Public Properties
        public string NodeIpAddress { get; private set; }
        public int Port { get; private set; }
        #endregion

        #region Public Methods
        public void StartListener()
        {
            _globalListener.Start();
            _globalListener.BeginAcceptTcpClient(
                new AsyncCallback(AcceptConnectionAttempt),
                _globalListener);
        }
        private void AcceptConnectionAttempt(IAsyncResult ar)
        {
            TcpListener listener = (TcpListener)ar.AsyncState;
            TcpClient client = listener.EndAcceptTcpClient(ar);
            _newTcpClient = client;
            
        }
        
        #endregion
    }
}
