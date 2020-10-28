using System;

namespace 説明_010
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

                //int[] array = { 1 };
                //array[0] = array[1];
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch
            {
                Console.WriteLine("ゼロ除算以外の例外が発生");
            }
        }
    }
}