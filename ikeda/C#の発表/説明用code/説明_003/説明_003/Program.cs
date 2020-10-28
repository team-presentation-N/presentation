using System;

class Mainclass
{
    static void Main()
    {
        var inst = new Subclass();

        Console.WriteLine(inst.Sum(1, 2, 3));
        Console.WriteLine(inst.Sum(5, 6));
        Console.WriteLine(inst.Sum(2, 3, 5, 7));
    }
}

class Subclass
{
    public int Sum(params int[] array)
    {
        int s = 0;
        for(int i = 0; i < array.Length; i++)
        {
            s += array[i];
        }
        return s;
    }
}