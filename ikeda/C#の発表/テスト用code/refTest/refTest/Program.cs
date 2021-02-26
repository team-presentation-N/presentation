using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int b = 1;

            ref int a = ref b;
            Debug.WriteLine("a = " + a + " b = " + b);

            a = 2;
            Debug.WriteLine("a = " + a + " b = " + b);
            //aに代入するとbにも同じ値が入る

            b = 3;
            Debug.WriteLine("a = " + a + " b = " + b);
            //bに代入するとaにも同じ値が入る

            //ref によって変数を定義すると,左辺は右辺と同じ対象を示すようになる
            //つまり,"a"は"b"の別名だと思える
        }
    }
}
