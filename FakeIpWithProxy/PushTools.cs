using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeIpWithProxy
{
    internal class PushTools
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
        public void Push()
        {
            ExecuteADBCommand("adb shell rm /data/local/tmp/redsocks");
            ExecuteADBCommand("adb shell rm /data/local/tmp/iptables");
            string addressIptables = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName.Replace("\\", "/")
                                                        + "/tools/iptables";
            string addressRedsocks = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName.Replace("\\", "/")
                                                        + "/tools/redsocks";
            ExecuteADBCommand("adb push " + addressIptables + " /data/local/tmp");
            Thread.Sleep(2000);
            ExecuteADBCommand("adb push " + addressRedsocks + " /data/local/tmp");
            Thread.Sleep(2000);
            ExecuteADBCommand("adb shell chmod 777 /data/local/tmp/redsocks");
            ExecuteADBCommand("adb shell chmod 777 /data/local/tmp/iptables");
        }
    }
}
