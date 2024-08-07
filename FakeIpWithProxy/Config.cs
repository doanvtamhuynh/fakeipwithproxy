using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeIpWithProxy
{

    internal class Config
    {
        private static string _defaultRedsocksFileName = "redsocks.conf";
        private static string _defaultRedsocksLocalPort = "12345";

        public void ConfigRedsocks(string ip, string port, string password, string username, string type)
        {
            string config = string.Format("base {{log_debug = off;log_info = off;log = \"stderr\";daemon = on;redirector = iptables;}} " +
                "redsocks {{ local_ip = 0.0.0.0; local_port = {0}; ip = {1}; port = {2}; type = {3}; }}"
                , _defaultRedsocksLocalPort
                , ip
                , port
                , type);
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                config = string.Format("base {{log_debug = off;log_info = off;log = \"stderr\";daemon = on;redirector = iptables;}} " +
                "redsocks {{ local_ip = 0.0.0.0; local_port = {0}; ip = {1}; port = {2}; type = {3}; login = \"{4}\"; password = \"{5}\"; }} "
                , _defaultRedsocksLocalPort
                , ip
                , port
                , type
                , username
                , password);
            }
            var pathConfig = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName.Replace("\\", "/")
                                                        + "/tools/" + _defaultRedsocksFileName;
            File.WriteAllText(pathConfig, config);
        }

        public void ConfigIptables(string ip)
        {
            ADBCommand adbComm = new ADBCommand();

            adbComm.ExecuteADBCommand("adb shell iptables -t nat -N REDSOCKS");
            adbComm.ExecuteADBCommand("adb shell iptables -A INPUT -i ap+ -p tcp --dport 12345 -j ACCEPT");
            adbComm.ExecuteADBCommand("adb shell iptables -A INPUT -i lo -p tcp --dport 12345 -j ACCEPT");
            adbComm.ExecuteADBCommand("adb shell iptables -A INPUT -p tcp --dport 12345 -j DROP");
            adbComm.ExecuteADBCommand("adb shell iptables -t nat -A PREROUTING -i ap+ -p tcp -d 192.168.1.0/24 -j RETURN");
            adbComm.ExecuteADBCommand("adb shell iptables -t nat -A PREROUTING -i ap+ -p tcp -j REDIRECT --to 12345");
            adbComm.ExecuteADBCommand("adb shell iptables -t nat -A OUTPUT -p tcp -d " + ip + " -j RETURN");
            adbComm.ExecuteADBCommand("adb shell iptables -t nat -A OUTPUT -p tcp -j REDIRECT --to 12345");
            adbComm.ExecuteADBCommand("adb shell iptables -t mangle -N REDSOCKS");
            adbComm.ExecuteADBCommand("adb shell iptables -t mangle -A REDSOCKS -p udp -j TPROXY --on-port 10053 --tproxy-mark 0x01/0x01");
            adbComm.ExecuteADBCommand("adb shell iptables -t mangle -A PREROUTING -j REDSOCKS");
            adbComm.ExecuteADBCommand("adb shell iptables -t nat -A OUTPUT -p udp --dport 53 -j REDSOCKS");
            adbComm.ExecuteADBCommand("adb shell iptables -t nat -A OUTPUT -p tcp --dport 80 -j REDSOCKS");
            adbComm.ExecuteADBCommand("adb shell iptables -t nat -A OUTPUT -p tcp --dport 443 -j REDSOCKS");
            adbComm.ExecuteADBCommand("adb shell iptables -t nat -A OUTPUT -p udp --dport 3478 -j REDSOCKS");
            adbComm.ExecuteADBCommand("adb shell iptables -t nat -A PREROUTING -p tcp --dport 80 -j REDSOCKS");
            adbComm.ExecuteADBCommand("adb shell iptables -t nat -A PREROUTING -p tcp --dport 443 -j REDSOCKS");
        }
    }
}
