using System;

namespace TestNamespace
{
    class MainClass
    {
        static void Main()
        {
            int n = 1;
            string s = "こんにちは";

            var inst = new TestClass();

            inst.Testmethod<int>(n);
            inst.Testmethod<string>(s);
            inst.Testmethod<TestClass>(inst);

            //型の省略
            inst.Testmethod(n);
            inst.Testmethod(s);
            inst.Testmethod(inst);

            inst.Testmethod2(n);
            inst.Testmethod2(s);
            inst.Testmethod2(inst);
        }
    }

    class TestClass
    {
        public void Testmethod<Type>(Type a)
        {
            Console.WriteLine(a);
            Console.WriteLine(a.GetType()+"\n");

            //Console.WriteLine(a + a);
        }

        public void Testmethod2(Object a)
        {
            Console.WriteLine(a);
            Console.WriteLine(a.GetType() + "\n");
        }
    }
}