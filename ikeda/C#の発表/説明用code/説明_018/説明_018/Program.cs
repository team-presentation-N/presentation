using System;

namespace 説明_018
{
    class MainClass
    {
        static void Main()
        {
            var inst = new Subclass(3);
            Console.WriteLine(inst.a);
        }
    }

    class Subclass
    {
        public int a;
        public Subclass(int n) => a = n;
    }
}
