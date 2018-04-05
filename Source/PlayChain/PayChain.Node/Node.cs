using PlayChain.Logic;
using PlayChain.Logic.CommandManager;
using PlayChain.Logic.Loader;
using PlayChain.Node.Model;
using System;
using System.Threading;

namespace PayChain.Node
{
    public class Node
    {
        private static NodeConfiguration _config;
        static void Main(string[] args)
        {
            LoadDependecies();
            var commandInterpretator = new CommandInterpretator(_config);
            string inputCommand;
            Console.WriteLine("This is PlayChain heavy node");
            Console.WriteLine("Enter -help for all available commands");
            while (true)
            {
                try
                {
                    inputCommand = Console.ReadLine().ToLower();
                    var response = commandInterpretator.ProcessCommand(inputCommand);
                    if (response == PlayChain.Node.Model.Enumerators.CommandInterpretatorResponses.Exit)
                    {
                        Console.WriteLine("Exiting node...");
                        Thread.Sleep(1000);
                        break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
        }
        private static void LoadDependecies()
        {
            LoadHelper.LoadConfig(out _config);
        }
    }
}
