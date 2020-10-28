using System;

class Mainclass
{
    static void Main()
    {
        var inst = new Subclass();
        int b, c;
        inst.Calc(2, out b, out c);
        Console.WriteLine(b);
        Console.WriteLine(c);
    }
}

class Subclass
{
    public void Calc(int a,out int a2,out int a3)
    {
        a2 = a * a;
        a3 = a * a * a;
    }
}