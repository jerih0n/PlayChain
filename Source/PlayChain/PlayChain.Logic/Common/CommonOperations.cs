using PlayChain.Node.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChain.Logic.Common
{
    public static class CommonOperations
    {
        public static void PrintHelp()
        {
            Console.WriteLine(string.Format("Available Commands: "));
            foreach(var command in NodeConstants.NodeCommands)
            {
                Console.WriteLine("{0} {1}",command.Key, command.Value);
            }
        }
    }
}
