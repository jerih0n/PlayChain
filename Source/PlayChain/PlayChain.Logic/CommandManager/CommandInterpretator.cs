using PlayChain.Logic.Common;
using PlayChain.Logic.Connecting;
using PlayChain.Logic.Connecting.WCFConnectionManager;
using PlayChain.Logic.Loader;
using PlayChain.Node.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.ServiceModel;
using PlayChain.Logic.CommandManager.CommandStrategy;
using PlayChain.Logic.CommandManager.CommandStrategy.ComandExecutions;
using PlayChain.Logic.CommandManager.CommandFacotry;

namespace PlayChain.Logic.CommandManager
{
    
    public  class CommandInterpretator
    {

        private  NodeConfiguration _config;
        public CommandInterpretator(NodeConfiguration configuration)
        {
            _config = configuration;
        }
        public Enumerators.CommandInterpretatorResponses ProcessCommand(string command)
        {
            INodeCommand commandAction = null;
            var commandResponse = Enumerators.CommandInterpretatorResponses.Fail;
            if (!CommandFactory.GetCommandActionClass(command, out commandAction))
            {
                Console.WriteLine("Unknow Command");
                return commandResponse;
            }
            return commandAction.Execute(_config);
            
        }
    }
}
