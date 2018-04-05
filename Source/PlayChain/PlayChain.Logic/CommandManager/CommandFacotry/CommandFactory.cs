using PlayChain.Logic.CommandManager.CommandStrategy;
using PlayChain.Logic.CommandManager.CommandStrategy.ComandExecutions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChain.Logic.CommandManager.CommandFacotry
{
    public static class CommandFactory
    {
        private static Dictionary<string, INodeCommand> _commands = new Dictionary<string, INodeCommand>()
        {
            { "-help", new PrintHelpCommand() },
            { "-start", new StartNodeCommand() }
        };
        public static bool GetCommandActionClass(string command,out INodeCommand nodeCommand)
        {
            nodeCommand = null;
            bool status = false;
            if(_commands.ContainsKey(command))
            {
                status = true;
                nodeCommand = _commands[command];
            }
            return status;
        }
    }
}
