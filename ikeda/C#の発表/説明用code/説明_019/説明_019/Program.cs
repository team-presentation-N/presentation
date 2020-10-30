using System;

namespace 説明_019
{
    class MainClass
    {
        static void Main()
        {
            //非同期で実行するメソッドを定義
            void testmethod(object n)
            {
                for(int i = 0; i < 50000; i++)
                {
                    Console.WriteLine(n + " " + i);

                    //1秒待機
                    //System.Threading.Thread.Sleep(1000);
                }
            }

            //WaitCallback はobject型を受け,戻り値を返さないメソッドに対応するdelegate型
            var dele = new System.Threading.WaitCallback(testmethod);

            //QueueUserWorkItem はWaitCallback型とobject型の引数を与えると,
            //WaitCallbackのdelegateにobject型を渡して実行待ちQueueに登録する
            //スレッドプール
            //ここでは,3つのtestmethodをスレッドプールに登録している
            /*
            System.Threading.ThreadPool.QueueUserWorkItem(dele, "1つめ");
            System.Threading.ThreadPool.QueueUserWorkItem(dele, "2つめ");
            System.Threading.ThreadPool.QueueUserWorkItem(dele, "3つめ");

            //出力される文字の並びはプログラムを実行する度に異なる

            //プログラムが勝手に終了しないために入力待ち状態を維持
            Console.ReadLine();
            */

            //スレッド数4のCPUなので,10個の処理には時間が掛かる
            //ただし,windowsによりCPUに実行させるスレッドが切り替えられているため,ある程度全てが並列処理されているように見える
            System.Threading.ThreadPool.QueueUserWorkItem(dele, "1つめ");
            System.Threading.ThreadPool.QueueUserWorkItem(dele, "2つめ");
            System.Threading.ThreadPool.QueueUserWorkItem(dele, "3つめ");
            System.Threading.ThreadPool.QueueUserWorkItem(dele, "4つめ");
            System.Threading.ThreadPool.QueueUserWorkItem(dele, "5つめ");
            System.Threading.ThreadPool.QueueUserWorkItem(dele, "6つめ");
            System.Threading.ThreadPool.QueueUserWorkItem(dele, "7つめ");
            System.Threading.ThreadPool.QueueUserWorkItem(dele, "8つめ");
            System.Threading.ThreadPool.QueueUserWorkItem(dele, "9つめ");
            System.Threading.ThreadPool.QueueUserWorkItem(dele, "10こめ");

            Console.ReadLine();
        }
    }
}
