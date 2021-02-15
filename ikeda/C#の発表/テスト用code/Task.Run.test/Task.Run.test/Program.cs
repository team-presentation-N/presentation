using System;
using System.Threading.Tasks;
namespace ns
{
    class MainClass
    {
        static void Main()
        {
            Task[] tasks = new Task[3];


            int count = 0;
            tasks[0] = Task.Run(() => Method0(count));
            count++;
            tasks[1] = Task.Run(() => Method1(count));
            count++;
            tasks[2] = Task.Run(() => Method2(count));
            count++;

            Task.WaitAll(tasks);
            Console.WriteLine("Task.Run実行時のカウンタの値がメソッドに渡されていない");
            Console.WriteLine("\n\n\n");

            for (int i = 0; i < 3; i++)
            {
                //カウンタに対応するメソッドにカウンタの値を渡して呼び出す
                switch (i)
                {
                    case 0:
                        tasks[0] = Task.Run(() => Method0(i));
                        break;
                    case 1:
                        tasks[1] = Task.Run(() => Method1(i));
                        break;
                    case 2:
                        tasks[2] = Task.Run(() => Method2(i));
                        break;
                }                
            }

            Task.WaitAll(tasks);
            Console.WriteLine("for文でも同様");
            Console.WriteLine("\n\n\n");

            for (int j = 0; j < 3; j++)
            {
                //カウンタの値を一旦ローカル変数にキャプチャして,上と同様の処理を行う
                int i = j;

                switch (i)
                {
                    case 0:
                        tasks[0] = Task.Run(() => Method0(i));
                        break;
                    case 1:
                        tasks[1] = Task.Run(() => Method1(i));
                        break;
                    case 2:
                        tasks[2] = Task.Run(() => Method2(i));
                        break;
                }
            }

            Task.WaitAll(tasks);
            Console.WriteLine("一旦ローカル変数にキャプチャすればよい");
            Console.WriteLine("\n\n\n");
        }

        static void Method0(int i)
        {
            Console.WriteLine("カウンタ=0 渡された引数=" + i);
        }
        static void Method1(int i)
        {
            Console.WriteLine("カウンタ=1 渡された引数=" + i);
        }
        static void Method2(int i)
        {
            Console.WriteLine("カウンタ=2 渡された引数=" + i);
        }
    }
}
