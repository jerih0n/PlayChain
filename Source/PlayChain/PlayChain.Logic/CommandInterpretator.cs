using PlayChain.Logic.Common;
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
        public static Enumerators.CommandInterpretatorResponses ProcessCommand(string command)
        {
            switch(command)
            {
                case "-help":
                    CommonOperations.PrintHelp();
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
    }
}
