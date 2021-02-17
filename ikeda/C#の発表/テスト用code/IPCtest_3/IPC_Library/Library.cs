using System;
using System.Threading;

namespace ShareSpace
{
    //共有されるオブジェクト
    public class IpcRemoteObject : MarshalByRefObject
    {
        //接続タイムアウトを無効化
        public override object InitializeLifetimeService()
        {
            return null;
        }

        public ManualResetEvent mrev = new ManualResetEvent(false);
    }
}
