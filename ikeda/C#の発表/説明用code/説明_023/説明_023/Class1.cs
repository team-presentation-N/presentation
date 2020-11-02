using System;
using System.Threading.Tasks;

namespace 説明_023
{
    class MainClass
    {
        static void Main()
        {
            Console.WriteLine("何か入力すると非同期処理を開始します");
            Console.ReadLine();

            Task<int> task = Testmethod();
            Task<int> task2 = Testmethod2();

            Console.WriteLine("Main待機中");
            Task.WaitAll(task,task2);
            Console.WriteLine("Main終了");
        }

        static async Task<int> Testmethod()
        {
            Console.WriteLine("Test開始");
            await Task.Delay(2000);
            Console.WriteLine("Test終了");
            return 0;
        }
        static async Task<int> Testmethod2()
        {
            Console.WriteLine("Test2開始");
            await Task.Delay(3000);
            Console.WriteLine("Test2終了");
            return 0;
        }
    }
}
