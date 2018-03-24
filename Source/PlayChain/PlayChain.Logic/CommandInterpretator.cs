using PlayChain.Node.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChain.Logic
{
    public static class CommandInterpretator
    {
        public static Enumerators.CommandInterpretatorResponses ProcessCommand(string command)
        {
            switch(command)
            {
                default:
                    Console.WriteLine("Unknown Command!");
                    return Enumerators.CommandInterpretatorResponses.Continue;
            }
        }
    }
}
