using System;

namespace 説明_012
{
    class MainClass
    {
        static void Main()
        {
            try
            {
                var inst = new CalcClass();
                inst.Division();
            }
            catch(Exception ex)
            {
                Console.WriteLine("例外発生");
                Console.WriteLine(ex.Message);
            }
        }
    }

    class CalcClass
    {
        public void Division()
        {
            int a, b, c;

            Console.WriteLine("整数の割り算を行うアプリケーションです");
            Console.WriteLine("割られる数を入力してください");

            /*
            while (true)
            {
                try
                {
                    a = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("不正な入力です 入力をやり直してください");
                }
            }
            */

            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("不正な値が入力されました 入力をやり直してください");
            }


            Console.WriteLine("割られる数を入力してください");

            while (!int.TryParse(Console.ReadLine(), out b) || b == 0)
            {
                Console.WriteLine("不正な値または0が入力されました 入力をやり直してください");
            }

            Console.WriteLine("商：" + (a / b));

            /*
            try
            {
                c = a / b;
                Console.WriteLine(c);
            }
            catch
            {
                Console.WriteLine("例外発生：除算エラー");
            }
            */
        }
    }
}
