using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NodeWindowsLauncher
{
    public partial class Form1 : Form
    {
        private static string _disc;
        private string cmd = ConfigurationManager.AppSettings["cmdPath"] != null ? ConfigurationManager.AppSettings["cmdPath"] : null;
        private bool isSet = false;
        private string _nodeFilePath;
        private static string NodeFullPath = ConfigurationManager.AppSettings["NodeFullPath"] != null ? ConfigurationManager.AppSettings["NodeFullPath"] : null;
        private static string NodeDllName = ConfigurationManager.AppSettings["NodeDllName"] != null ? ConfigurationManager.AppSettings["NodeDllName"] : null;
        public Form1()
        {
            InitializeComponent();
            if(NodeFullPath == null || NodeDllName == null)
            {
                nodeFullPath.Text = "Path or node .dll name is not set. See app.config file!";
                return;
            }
            if(!Directory.Exists(NodeFullPath))
            {
                nodeFullPath.Text = "Node directry path does not exist. See app.config file!";
                return;
            }
            if(!File.Exists(string.Format("{0}\\{1}",NodeFullPath, NodeDllName)))
            {
                nodeFullPath.Text = "Node .dll file  not exist. See app.config file!";
                return;
            }
            if(!File.Exists(cmd))
            {
                nodeFullPath.Text = "Cannot locate the cmd.exe. See app.config file!";
                return;
            }
            isSet = true;
            launchNodeBtn.Enabled = true;
            _nodeFilePath = string.Format("{0}\\{1}", NodeFullPath, NodeDllName);
            nodeFullPath.Text = _nodeFilePath;
        }

        private void changeDirektoryBtn_Click(object sender, EventArgs e)
        {
            string filePath;
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Dll Files (*.dll)|*.dll";
                dialog.ShowDialog();
                filePath = dialog.FileName;
            }
            var splited = filePath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var fileName = splited[splited.Length - 1];
            var directory = string.Join("\\", splited, 0, splited.Length - 1);           
            if (!Directory.Exists(directory))
            {
                MessageBox.Show(string.Format("Directory {0} is not found!", fileName));
                return;
            }
            if (!File.Exists(filePath))
            {
                MessageBox.Show(string.Format("File {0} is not found!", fileName));
                return;
            }
            if (fileName != NodeDllName)
            {
                MessageBox.Show(string.Format("{0} is not Node dll. Node dll name {1}", fileName, NodeDllName));
                return;
            }
            ConfigurationManager.AppSettings.Set("NodeFullPath", directory);

        }

        private void launchNodeBtn_Click(object sender, EventArgs e)
        {
            //get disc
            
            _disc = NodeFullPath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)[0];
            var process = new Process();
            process.StartInfo = GetProcessStartInfo(true);
            var isStarder = process.Start();
            if(isStarder)
            {
                label1.Text = "Node Started! Exit in 2 seconds...";
            }
            Thread.Sleep(2000);
            this.Close();
        }
        private ProcessStartInfo GetProcessStartInfo(bool showConsole = false )
        {
            var windowStyle = ProcessWindowStyle.Hidden;
            if (showConsole)
            {
                windowStyle = ProcessWindowStyle.Normal;
            }
            return new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                UseShellExecute = false,
                WorkingDirectory = NodeFullPath,
                WindowStyle = windowStyle,
                Arguments = string.Format("/c dotnet {0}", NodeDllName)
            };
        }
    }
}
