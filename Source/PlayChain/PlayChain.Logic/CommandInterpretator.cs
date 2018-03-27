using PlayChain.Logic.Common;
using PlayChain.Logic.Connecting;
using PlayChain.Logic.Loader;
using PlayChain.Node.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlayChain.Logic
{
    
    public static class CommandInterpretator
    {
        private static NodeConfiguration _config;
        private static NodeReceiver _globalReceiver;
        private static NodeConnector _connector;
        public static Enumerators.CommandInterpretatorResponses ProcessCommand(string command)
        {
            switch(command)
            {
                case "-help":
                    CommonOperations.PrintHelp();
                    return Enumerators.CommandInterpretatorResponses.Continue;
                case "-start":
                    StartListener();
                    return Enumerators.CommandInterpretatorResponses.Continue;
                case "-connect to":
                    var connection = NodeConnectorHelper.GetRequestedConnection();
                    StartSender(connection.IpAddress, connection.Port);
                    return Enumerators.CommandInterpretatorResponses.Continue;
                default:
                    Console.WriteLine("Unknown Command!");
                    return Enumerators.CommandInterpretatorResponses.Continue;
            }
        }
        public static void LoadNodeDependencies()
        {
            LoadHelper.LoadConfig(out _config);
            if(_config == null)
            {
                throw new Exception("Configuration faild to load!");
                
            }
        }


        #region Private Methos
        private static void StartListener()
        {
            if(_globalReceiver == null)
            {
                _globalReceiver = new NodeReceiver(_config.IpAddress, _config.PortListen);
                _globalReceiver.StartListener();
                
            }
            Console.WriteLine("Node is accepting connections at {0} port {1}", _globalReceiver.NodeIpAddress,_globalReceiver.Port);
        }
        private static void StartSender(string ipAddress, int port)
        {
            if(_connector == null)
            {
                _connector = new NodeConnector(_config.IpAddress, _config.PortConnect);
                
            }
            _connector.AddNewConnection(ipAddress, port);
        }
        #endregion
    }
}
