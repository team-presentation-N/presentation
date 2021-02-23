using System;

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

        public event EventHandler Ev;

        public bool AppExit(object sender, EventArgs e)
        {
            if (Ev == null)
            {
                return false;
            }

            Ev(sender, e);
            return true;
        }
    }
}
