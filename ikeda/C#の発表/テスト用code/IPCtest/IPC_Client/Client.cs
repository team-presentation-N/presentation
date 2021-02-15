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
            if (ipcc.Shareobj.Str == null)
            {
                ipcc.Shareobj.Str = "未設定";
            }

            while (true)
            {
                /*
                Console.WriteLine("キー入力で共有オブジェクトのメンバーを表示");
                Console.ReadKey();
                */
                Console.WriteLine("受信時刻：" + DateTime.Now.ToString() + " " + ipcc.Shareobj.Str);
            }
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

namespace ShareSpace
{
    //共有されるオブジェクト
    public class IpcRemoteObject : MarshalByRefObject
    {
        public override object InitializeLifetimeService()
        {
            return null;
        }
        public string Str { get; set; }
    }
}
