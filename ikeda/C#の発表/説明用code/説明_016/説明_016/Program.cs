using System;
using System.Runtime.InteropServices.ComTypes;

namespace 説明_016
{
    //int型を受け,戻り値のないメソッドを代表するdelegateの型"Testdele"を定義
    delegate void Testdele(int a);

    class MainClass
    {
        static void Main()
        {
            var inst = new SubClass();

            //Testdele型の変数"td"を宣言し,SCmethod1を登録
            var td = new Testdele(inst.SCmethod1);
            td(10);
            Console.WriteLine();

            //tdにSCmethod2を登録(元のSCmethod1は上書きされる)
            td = inst.SCmethod2;
            td(10);
            Console.WriteLine();

            //tdを変数として扱う
            Delexe(td);
            Console.WriteLine();
        }

        static void Delexe(Testdele td)
        {
            td(16);
            td(22);
        }
    }

    class SubClass
    {
        public void SCmethod1(int a)
        {
            Console.WriteLine(2 * a);
        }
        public void SCmethod2(int a)
        {
            Console.WriteLine(a / 2);
        }
    }
}
