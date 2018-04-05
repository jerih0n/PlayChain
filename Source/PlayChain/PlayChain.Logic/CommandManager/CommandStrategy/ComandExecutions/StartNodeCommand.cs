using System;
using System.Collections.Generic;
using System.Text;
using PlayChain.Logic.Connecting.WCFConnectionManager;
using PlayChain.Node.Model;

namespace PlayChain.Logic.CommandManager.CommandStrategy.ComandExecutions
{
    public class StartNodeCommand : INodeCommand
    {
        Enumerators.CommandInterpretatorResponses INodeCommand.Execute(NodeConfiguration configuration)
        {
            var manager = new ConnectionManager();
            manager.Init();
            return Enumerators.CommandInterpretatorResponses.Success;
        }
    }
}
