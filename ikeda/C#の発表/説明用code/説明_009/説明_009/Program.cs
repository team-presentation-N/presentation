using System;

namespace 説明_009
{
    class MainClass
    {
        static void Main()
        {
            int a, b, c;
            a = 2;
            b = 0;
            try
            {
                c = a / b;
                Console.WriteLine(c);
            }
            catch
            {
                Console.WriteLine("例外発生：除算エラー");
            }
        }
    }
}
