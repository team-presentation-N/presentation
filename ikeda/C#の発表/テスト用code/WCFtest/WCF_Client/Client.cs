using System;
using System.ServiceModel;
using WCF_ShareLibrary;

namespace WCF_Client
{
    class Client
    {
        static void Main()
        {
            Console.WriteLine("Client起動");

            using (ChannelFactory<IShareObj> channelFactory = new ChannelFactory<IShareObj>(new NetNamedPipeBinding(NetNamedPipeSecurityMode.None)))
            {
                string uri = @"net.pipe://localhost/WCF_test/endpoint";

                IShareObj service = channelFactory.CreateChannel(new EndpointAddress(uri));

                while (true)
                {
                    Console.WriteLine("操作の種類を入力");
                    switch (Console.ReadLine())
                    {
                        case "set":
                            Console.WriteLine("送信する文字列を入力");
                            service.SetText(Console.ReadLine());
                            break;
                        case "get":
                            Console.WriteLine("受信:" + service.GetText());
                            if (service.GetText() == "exit")
                            {
                                return;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
