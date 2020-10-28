using System;

namespace 説明_005
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

    abstract class BaseClass
    {
        public abstract void Say();
    }

    class DerivedClass1 : BaseClass
    {
        public override void Say()
        {
            Console.WriteLine("処理1");
        }
    }

    class DerivedClass2 : BaseClass
    {
        public override void Say()
        {
            Console.WriteLine("処理2");
        }
    }
}