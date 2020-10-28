using System;

namespace 説明_006
{
    class MainClass
    {
        static void Main()
        {
            BaseClass inst;

            inst = new DerivedClass1();
            inst.Say();

            inst = new DerivedClass2();
            inst.Say();
        }
    }

    class BaseClass
    {
        public void Say()
        {
            Console.WriteLine("処理0");
        }
    }

    class DerivedClass1 : BaseClass
    {
        new public void Say()
        {
            Console.WriteLine("処理1");
        }
    }

    class DerivedClass2 : BaseClass
    {
        new public void Say()
        {
            Console.WriteLine("処理2");
        }
    }
}