using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChain.Node.Model
{
    public class Enumerators
    {
        public enum CommandInterpretatorResponses
        {
            Success = 1,
            Fail = 2,
            Exit = 3,
            Continue = 4,
        }
        public enum ConnectorStatus
        {
            Open = 1,
            NotRespondig =2,
            Closed = 3
        }
    }
    
}
