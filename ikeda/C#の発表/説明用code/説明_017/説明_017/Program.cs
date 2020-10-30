using System;

namespace 説明_017
{
    delegate int Intdele(int a);
    delegate void Statedele(int a, int b);
    class MainClass
    {
        static void Main()
        {
            //Intdele型の変数を宣言し,int型引数を2乗して返すメソッドをラムダ式を利用して登録
            Intdele intdele = a => a * a;

            Console.WriteLine(intdele(3));
            Console.WriteLine();

            //Statedele型の変数を宣言し,int型引数2つに対して処理を行うメソッドをラムダ式により登録
            Statedele statedele = (a, b) =>
            {
                if (a > b)
                {
                    Console.WriteLine(a + 2);
                }
                else
                {
                    Console.WriteLine(b - 3);
                }
            };

            statedele(3, 7);
            statedele(11, 6);
            Console.WriteLine();


            //Action<T>型を用いた同様の記述
            Action<int, int> action = (a, b) =>
            {
                if (a > b)
                {
                    Console.WriteLine(a + 2);
                }
                else
                {
                    Console.WriteLine(b - 3);
                }
            };
            statedele(3, 7);
            statedele(11, 6);
        }
    }
}
