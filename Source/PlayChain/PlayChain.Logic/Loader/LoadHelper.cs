using PlayChain.Node.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlayChain.Logic.Loader
{
    public static class LoadHelper
    {
        public static void LoadConfig(out NodeConfiguration config)
        {
            config = null;
            CreateDefaultConfigIfNeeded();
            config = GetConfiguration();
        }

        private static void CreateDefaultConfigIfNeeded()
        {
            if (!Directory.Exists(NodeConstants.ConfigFileDirectory))
            {
                Directory.CreateDirectory(NodeConstants.ConfigFileDirectory);
            }
            if (!File.Exists(NodeConstants.ConfigFileDirectory + NodeConstants.ConfigName))
            {
                using (var writter = new StreamWriter(NodeConstants.ConfigFileDirectory + NodeConstants.ConfigName))
                {
                    var defauldNodeConfig = new NodeConfiguration(true);
                    var jsonConfig = Newtonsoft.Json.JsonConvert.SerializeObject(defauldNodeConfig);
                    writter.Write(jsonConfig);
                }
            }
        }
        private static NodeConfiguration GetConfiguration()
        {
            try
            {
                using (var reader = new StreamReader(NodeConstants.ConfigFileDirectory + NodeConstants.ConfigName))
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<NodeConfiguration>(reader.ReadToEnd());
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
