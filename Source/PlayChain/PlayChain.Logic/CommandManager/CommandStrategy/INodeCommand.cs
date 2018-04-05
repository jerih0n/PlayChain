using PlayChain.Node.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChain.Logic.CommandManager.CommandStrategy
{
    public interface INodeCommand
    {
        Enumerators.CommandInterpretatorResponses Execute(NodeConfiguration configuration);
        
    }
}
