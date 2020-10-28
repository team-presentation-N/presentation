using System;

namespace 説明_011
{
    class MainClass
    {
        static void Main()
        {
            try
            {
                try
                {
                    //例外を検出したい処理
                    int a = 0;
                    int b = 1 / a;
                    Console.WriteLine(b);
                }
                catch(IndexOutOfRangeException ex)
                {
                    Console.WriteLine("例外発生時処理1");
                    throw;
                }

                //その他の処理
                Console.WriteLine("正常処理");

            }
            catch
            {
                Console.WriteLine("例外発生時処理2");
            }
        }
    }
}
