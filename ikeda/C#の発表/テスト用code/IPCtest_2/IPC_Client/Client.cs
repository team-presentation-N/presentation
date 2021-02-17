using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using ShareSpace;

namespace IPC_Test
{
    class Client
    {
        static void Main(string[] args)
        {
            IpcClient ipcc = new IpcClient();

            ipcc.Shareobj.Ev += Shareobj_Ev;
            Console.WriteLine("Client 準備OK");
        }

        private static void Shareobj_Ev(object sender, EventArgs e)
        {
            //終了
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
