using PlayChain.Node.Connection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PlayChain.Node.Connection.Classes
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ConnectionManager" in both code and config file together.
    public class ConnectionService : IConnectionService
    {
        public string DoWork()
        {
            return "Hello World";
        }
    }
}
