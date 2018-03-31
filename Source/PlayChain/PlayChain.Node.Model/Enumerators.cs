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

        public enum ConnectionMessages
        {
            GiveLastBlockId = 1, // send request go get the last block id
            SendChain = 2, // ask for missing blocks of the chai

        }
    }
    
}
