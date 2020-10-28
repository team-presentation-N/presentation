using System;

namespace 説明_014
{
    class MainClass
    {
        static void Main()
        {
            TestStruct tstr;
            //Console.WriteLine(tstr.a); 値が未割り当てのためエラー
            tstr.a = 2;
            Console.WriteLine(tstr.a);

            TestStruct tstr2 = new TestStruct(1);
            Console.WriteLine(tstr2.a); //コンストラクターによりaは初期化済みのためエラーは発生しない

            TestStruct tstr3 = new TestStruct();
            Console.WriteLine(tstr3.a); //既定のコンストラクターにより,aはint型の既定値である0に
        }
    }

    struct TestStruct
    {
        public int a;

        public TestStruct(int n)
        {
            a = 3;
        }
    }
}
