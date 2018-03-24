using PlayChain.Logic;
using System;
using System.Threading;

namespace PayChain.Node
{
    public class Node
    {
        
        static void Main(string[] args)
        {
            string inputCommand;
            Console.WriteLine("This is PlayChain heavy node");
            Console.WriteLine("Enter -help for all available commands");
            while(true)
            {
                inputCommand = Console.ReadLine().ToLower();
                var response = CommandInterpretator.ProcessCommand(inputCommand);
                if(response == PlayChain.Node.Model.Enumerators.CommandInterpretatorResponses.Exit)
                {
                    Console.WriteLine("Exiting node...");
                    Thread.Sleep(1000);
                    break;
                }
            }
        }
    }
}
