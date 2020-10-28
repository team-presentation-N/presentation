using System;

class Mainclass
{
    static void Main()
    {
        var inst = new Subclass();

        Console.WriteLine(inst.a);
        inst.Calc(ref inst.a);
        Console.WriteLine(inst.a);
    }
}

class Subclass
{
    public int a = 3;

    public void Calc(ref int b)
    {
        b = b + 2;
        Console.WriteLine(b);
    }
}