using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRefTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var inst = new TestClass();
            inst.a = 1;
            inst.class2 = new TestClass2();
            inst.class2.str = "1";

            Console.WriteLine(inst.a + " : " + inst.class2.str);

            var sub = new SubClass(inst);
            sub.Method(2);

            Console.WriteLine(inst.a + " : " + inst.class2.str);
        }

    }

    class SubClass
    {
        private TestClass test;
        public SubClass(TestClass test)
        {
            this.test = test;
        }

        public void Method(int i)
        {
            test.a = i;
            test.class2.str = i.ToString();
            Console.WriteLine(test.a + " : " + test.class2.str);
        }
    }
    //!あああああ
    class TestClass
    {
        public int a;
        public TestClass2 class2;
    }

    class TestClass2
    {
        public string str;
    }
}
