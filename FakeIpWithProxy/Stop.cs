using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FakeIpWithProxy
{
    internal class Stop
    {
        public void ExecuteADBCommand(string command)
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c " + command,
                CreateNoWindow = true,
                UseShellExecute = false
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        public void StopFakeIp()
        {
            
        }
    }
}
