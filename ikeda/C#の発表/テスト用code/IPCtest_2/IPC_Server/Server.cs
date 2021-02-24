using System;
using System.Diagnostics;
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
            Process.Start("IPC_Client.exe");

            while (true)
            {
                Console.WriteLine("キー入力待ち");
                if (Console.ReadLine() == "exit")
                {
                    if (ipcs.Shareobj.AppExit(null, EventArgs.Empty))
                    {
                        break;
                    }

                    Console.WriteLine("Ev未設定");
                }
            }

            Console.WriteLine("終了");
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


