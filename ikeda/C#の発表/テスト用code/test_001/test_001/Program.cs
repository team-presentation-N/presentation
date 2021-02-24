using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_001
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    throw new IOException();
                }
                catch(IOException ex)
                {
                    Ex_AddRecoverabilitySign(ex);
                    throw;
                }
            }
            catch(Exception ex) when (Recoverability(ex))
            {
                Console.WriteLine("ok");
            }
            catch
            {
                Console.WriteLine("ng");
            }

            /*
            int[] a = { 0 };
            int b = 0;
            //参照渡し
            add(a);
            //値渡し
            add(b);
            Console.WriteLine(a[0]);
            Console.WriteLine(b);
            */
        }
        
        static void Ex_AddRecoverabilitySign(Exception ex)
        {
            ex.Data.Add("回復可能", "");
        }

        static bool Recoverability(Exception ex)
        {
            return ex.Data.Contains("回復可能");
        }

        static void add(int[] a)
        {
            a[0] += 1;
        }

        static void add(int b)
        {
            b += 1;
        }
    }
}
