using System;

namespace WestCoastEducation;

public static class Printer
{
    public static void Print(IPrintable item)
    {
        Console.WriteLine(item.GetInfo());
    }

    public static void PrintAll(IEnumerable<IPrintable> items)
    {
        foreach(var item in items)
        {
            Print(item);
        }
    }
}
