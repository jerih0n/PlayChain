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
        public enum ReceiverStatus
        {
            NotListening = 1,
            Listening = 2
        }
        public enum ConnectionResponse
        {
            ConnectionExist = 1,
            ConnectionAdded = 2,
            FaildToAddConnection = 3
        }

    }
    
}
