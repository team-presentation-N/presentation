using System;
using System.Threading.Tasks;

namespace 説明_020
{
    class MainClass
    {
        static void Main()
        {
            //非同期で実行するメソッドを定義
            void testmethod(object n)
            {
                for (int i = 1; i <= 1000; i++)
                {
                    Console.WriteLine(n + " " + i);
                }
            }

            //Action型(引数,戻り値なし)のdelegateを10個用意
            Action dele1 = () => { testmethod("1つめ "); };
            Action dele2 = () => { testmethod("2つめ "); };
            Action dele3 = () => { testmethod("3つめ "); };
            Action dele4 = () => { testmethod("4つめ "); };
            Action dele5 = () => { testmethod("5つめ "); };
            Action dele6 = () => { testmethod("6つめ "); };
            Action dele7 = () => { testmethod("7つめ "); };
            Action dele8 = () => { testmethod("8つめ "); };
            Action dele9 = () => { testmethod("9つめ "); };
            Action dele10 = () => { testmethod("10こめ "); };

            Console.WriteLine("何か入力されると非同期処理を開始します");
            _ = Console.ReadLine();

            //usingディレクティブを使用して,Taskクラスの呼び出しを簡易化している
            Task.Run(dele1);
            Task.Run(dele2);
            Task.Run(dele3);
            Task.Run(dele4);
            Task.Run(dele5);
            Task.Run(dele6);
            Task.Run(dele7);
            Task.Run(dele8);
            Task.Run(dele9);
            Task.Run(dele10);

            Console.ReadLine();
        }
    }
}
