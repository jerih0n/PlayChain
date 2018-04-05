using System;
using System.Collections.Generic;
using System.Text;
using PlayChain.Logic.Common;
using PlayChain.Node.Model;

namespace PlayChain.Logic.CommandManager.CommandStrategy.ComandExecutions
{
    public class PrintHelpCommand : INodeCommand
    {

        Enumerators.CommandInterpretatorResponses INodeCommand.Execute(NodeConfiguration configuration)
        {
            CommonOperations.PrintHelp();
            return Enumerators.CommandInterpretatorResponses.Continue;
        }
    }
}
