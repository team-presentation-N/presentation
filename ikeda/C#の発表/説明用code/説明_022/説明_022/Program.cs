using System;
using System.Threading;
using System.Threading.Tasks;

namespace 説明_022
{
    class MainClass
    {
        static void Main()
        {
            int a = 0;

            Console.WriteLine("何か入力すると非同期処理を開始します");
            Console.ReadLine();

            //5秒掛かる処理をQueueに登録
            Task task = Task.Run(() => {Thread.Sleep(5000); a = 1;});

            //0.1秒毎にタスクの処理状態を確認
            //タスク実行中ならループ継続
            while (!task.IsCompleted)
            {
                Console.WriteLine("タスク実行中");
                Console.WriteLine("a=" + a);
                Thread.Sleep(100);
            }

            Console.WriteLine("\nタスク実行完了");
            Console.WriteLine("a=" + a);
        }
    }
}
