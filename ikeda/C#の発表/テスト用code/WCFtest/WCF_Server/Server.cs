using System;
using System.Diagnostics;
using System.IO;
using System.ServiceModel;
using WCF_ShareLibrary;

namespace WCF_Server
{
    class Server
    {
        static void Main()
        {
            string baseAddress = "net.pipe://localhost/WCF_test";
            string endPointAddress = "endpoint";

            ServiceHost serviceHost = new ServiceHost(typeof(ShareObj), new Uri(baseAddress));
            serviceHost.AddServiceEndpoint(typeof(IShareObj), new NetNamedPipeBinding(NetNamedPipeSecurityMode.None), endPointAddress);

            // WCFサービスの開始
            serviceHost.Open();
            Console.WriteLine("サービスホスト確立\nURI:" + baseAddress + "/" + endPointAddress);
            Process.Start("WCF_Client.exe");

            Console.ReadKey();

            // WCFサービスの終了
            serviceHost.Close();
        }
    }

    public class ShareObj : IShareObj
    {
        string text;

        public string GetText()
        {
            return text;
        }

        public void SetText(string str)
        {
            text = str;
        }
    }
}
