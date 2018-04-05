using PlayChain.Node.Connection.Classes;
using PlayChain.Node.Connection.Interfaces;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace PlayChain.Logic.Connecting.WCFConnectionManager
{
    public class ConnectionManager
    {
        public ConnectionManager()
        {
            
        }
        private ServiceHost serviceHost = null;
        
        public void Init()
        {
            try
            {
                //Base Address for StudentService
                Uri httpBaseAddress = new Uri("http://localhost:4321/StudentService");
                //Instantiate ServiceHost
                serviceHost = new ServiceHost(typeof(NodeConnectionService),httpBaseAddress);
                //Add Endpoint to Host
                serviceHost.AddServiceEndpoint(typeof(INodeConnectionService),new NetHttpBinding(), "");

                //Metadata Exchange
                ServiceMetadataBehavior serviceBehavior = new ServiceMetadataBehavior();
                serviceBehavior.HttpGetEnabled = true;
                serviceHost.Description.Behaviors.Add(serviceBehavior);

                //Open
                serviceHost.Open();
                Console.WriteLine("Service is live now at : {0}", httpBaseAddress);
                Console.ReadKey();
            }

            catch (Exception ex)
            {
                serviceHost = null;
                Console.WriteLine("There is an issue with StudentService" + ex.Message);
            }
        }
    }
}
