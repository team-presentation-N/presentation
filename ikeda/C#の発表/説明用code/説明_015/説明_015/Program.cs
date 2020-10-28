using System;
using System.Collections.Generic;

namespace 説明_015
{
    class MainClass
    {
        static void Main()
        {
            var intlist = new List<int>();

            var floatdict = new Dictionary<string, float>();

            floatdict.Add("円周率", 3.141F);
            floatdict.Add("自然対数の底", 2.718F);
            Console.WriteLine(floatdict["円周率"]);

        }
    }
}
