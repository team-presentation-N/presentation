using System;

namespace 説明_0
{
    class MainClass
    {
        static void Main()
        {
            int a = 3;
            int b = 5;

            float c = 2.8F;
            float d = -1.5F;

            Console.WriteLine(TestClass.Compare(a, b));
            Console.WriteLine(TestClass.Compare(c, d));

            Console.WriteLine(TestClass.Compare2(a, b));
            Console.WriteLine(TestClass.Compare2(c, d));

            Console.WriteLine(TestClass.Compare(a, b).GetType());
            Console.WriteLine(TestClass.Compare(c, d).GetType());
            Console.WriteLine(TestClass.Compare2<int>(a, b).GetType());
            Console.WriteLine(TestClass.Compare2<float>(c, d).GetType());
        }
    }

    static class TestClass
    {
        public static IComparable Compare(IComparable a,IComparable b)
        {
            Console.WriteLine(a.GetType());

            if(a.CompareTo(b) > 0)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        public static T Compare2<T>(T a,T b) where T : IComparable
        {
            if (a.CompareTo(b) > 0)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}