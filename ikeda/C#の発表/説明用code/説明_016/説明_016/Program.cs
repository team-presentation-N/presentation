using System;

namespace 説明_016
{
    //int型を受け,戻り値のないメソッドを代表するdelegateの型"Testdele"を定義
    delegate void Testdele(int a);

    //int型を受け,int型を返すメソッドのdelegate
    delegate int intdele(int a);

    class MainClass
    {
        static void Main()
        {
            var inst = new SubClass();

            //Testdele型の変数"td"を宣言し,SCmethod1を登録
            var td = new Testdele(inst.SCmethod1);
            td(10); //出力値:20
            Console.WriteLine();

            //tdにSCmethod2を登録(元のSCmethod1は上書きされる)
            td = inst.SCmethod2;
            td(10); //出力値:5
            Console.WriteLine();

            //tdを変数として扱う
            Delexe(td); //出力値:8,11
            Console.WriteLine();

            //マルチキャスティング
            td = inst.SCmethod1;
            td += inst.SCmethod2;
            td(10); //出力値:20,5
            Console.WriteLine();

            td -= inst.SCmethod2;
            td(10); //出力値:20
            Console.WriteLine();

            //int型を返す2つのメソッドをマルチキャスト
            //後に登録したものの値のみが返される
            var inst2 = new SubClass2();
            intdele id;
            id = inst2.SCmethod3;
            id += inst2.SCmethod4;
            Console.WriteLine(id(16)); //出力値:4
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

    class SubClass2
    {
        public int SCmethod3(int a)
        {
            return a * a;
        }

        public int SCmethod4(int a)
        {
            return (int)System.Math.Sqrt(a);
        }
    }
}
