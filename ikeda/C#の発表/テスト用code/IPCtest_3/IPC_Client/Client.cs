using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Threading.Tasks;
using ShareSpace;

namespace IPC_Test
{
    class Client
    {
        private static IpcClient ipcc;

        static async Task Main()
        {
            ipcc = new IpcClient();

            Console.WriteLine("Client 準備OK");

            Task.Run(WaitExit);

            while (true)
            {
                Console.WriteLine("待機中" + DateTime.Now.ToString());
                await Task.Delay(500);
            }
        }

        static void WaitExit()
        {
            ipcc.Shareobj.mrev.WaitOne();
            Environment.Exit(0);
        }
    }

    class IpcClient
    {
        public IpcRemoteObject Shareobj { get; private set; }

        public IpcClient()
        {
            //クライアントチャンネルの生成
            IpcClientChannel channel = new IpcClientChannel();

            //チャンネルを登録
            ChannelServices.RegisterChannel(channel, true);

            //"ipc://channel_name/testurl"からオブジェクトを取得
            Shareobj = Activator.GetObject(typeof(IpcRemoteObject), "ipc://channel_name/testurl") as IpcRemoteObject;
        }
    }
}
