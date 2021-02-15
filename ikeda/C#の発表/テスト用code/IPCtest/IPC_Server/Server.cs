using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using ShareSpace;

namespace IPCtest
{
    class Server
    {
        static void Main(string[] args)
        {
            IpcServer ipcs = new IpcServer();
            if (ipcs.Shareobj.Str == null)
            {
                ipcs.Shareobj.Str = "未設定";
            }

            while (true)
            {
                Console.WriteLine("キー入力で共有オブジェクトのメンバーを更新");
                ipcs.Shareobj.Str = Console.ReadLine();
                Console.WriteLine("設定時刻：" + DateTime.Now.ToString());
            }
        }
    }

    //IPCサーバー
    class IpcServer
    {
        public IpcRemoteObject Shareobj { get; private set; }

        public IpcServer()
        {
            //サーバーチャンネルの生成
            IpcServerChannel channel = new IpcServerChannel("channel_name");

            //チャンネルを登録
            ChannelServices.RegisterChannel(channel, true);

            //"ipc://channel_name/testurl"にオブジェクトを公開
            Shareobj = new IpcRemoteObject();
            RemotingServices.Marshal(Shareobj, "testurl", typeof(IpcRemoteObject));
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

