using System;
using System.Threading;
using System.Threading.Tasks;

namespace 説明_021
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("何か入力すると非同期処理を開始します");
            Console.ReadLine();

            Task<int> inttask1 = Task.Run(() => { Console.WriteLine("タスク1 実行開始"); return Subclass.Testmethod(1); });
            Task<int> inttask2 = Task.Run(() => { Console.WriteLine("タスク2 実行開始"); return Subclass.Testmethod(2); });
            Task<int> inttask3 = Task.Run(() => { Console.WriteLine("タスク3 実行開始"); return Subclass.Testmethod(3); });
            Task<int> inttask4 = Task.Run(() => { Console.WriteLine("タスク4 実行開始"); return Subclass.Testmethod(4); });
            Task<int> inttask5 = Task.Run(() => { Console.WriteLine("タスク5 実行開始"); return Subclass.Testmethod(5); });

            //以下の処理が実行されるのは,対応するタスクが終了した後
            Console.WriteLine("タスク1 実行結果：" + inttask1.Result);
            Console.WriteLine("タスク2 実行結果：" + inttask2.Result);
            Console.WriteLine("タスク3 実行結果：" + inttask3.Result);
            Console.WriteLine("タスク4 実行結果：" + inttask4.Result);
            Console.WriteLine("タスク5 実行結果：" + inttask5.Result);
        }
    }

    static class Subclass
    {
        public static int Testmethod(int n)
        {
            Console.WriteLine("タスク" + n + " メソッド処理開始");

            //nミリ秒の遅延
            Thread.Sleep(5000);
            
            Console.WriteLine("タスク" + n + " メソッド処理終了");
            return DateTime.Now.Second;
        }
    }
}
