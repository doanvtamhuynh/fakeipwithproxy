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
        public void Push()
        {
            var adbComm = new ADBCommand();

            adbComm.ExecuteADBCommand("adb shell rm /data/local/tmp/redsocks");
            adbComm.ExecuteADBCommand("adb shell rm /data/local/tmp/redsocks.conf");
            adbComm.ExecuteADBCommand("adb shell rm /data/local/tmp/iptables");
            string addressIptables = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName.Replace("\\", "/")
                                                        + "/tools/iptables";
            string addressRedsocks = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName.Replace("\\", "/")
                                                        + "/tools/redsocks";
            string addressRedsocksConfig = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName.Replace("\\", "/")
                                                        + "/tools/redsocks.conf";
            adbComm.ExecuteADBCommand("adb push " + addressIptables + " /data/local/tmp");
            Thread.Sleep(3000);
            adbComm.ExecuteADBCommand("adb push " + addressRedsocks + " /data/local/tmp");
            Thread.Sleep(3000);
            adbComm.ExecuteADBCommand("adb push " + addressRedsocksConfig + " /data/local/tmp");
            Thread.Sleep(3000);
            adbComm.ExecuteADBCommand("adb shell chmod 777 /data/local/tmp/redsocks");
            adbComm.ExecuteADBCommand("adb shell chmod 777 /data/local/tmp/iptables");
            adbComm.ExecuteADBCommand("adb shell chmod 777 /data/local/tmp/redsocks.conf");
        }
    }
}
