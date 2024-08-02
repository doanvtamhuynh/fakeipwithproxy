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
        public void StopFakeIp()
        {
            var adbCommand = new ADBCommand();

            adbCommand.ExecuteADBCommand("adb shell iptables -t nat -F");
            adbCommand.ExecuteADBCommand("adb shell iptables -t mangle -F");
            adbCommand.ExecuteADBCommand("adb shell iptables -F");
            adbCommand.ExecuteADBCommand("adb shell iptables -t nat -X REDSOCKS");
            adbCommand.ExecuteADBCommand("adb shell killall redsocks");
        }
    }
}
