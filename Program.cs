using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        // Test
        List<int> inputList = new List<int> { 0, 1, 2, 3 };
        List<int> mappedList = new List<int> { 1, 2, 3, 4 };

        Func<int, int> mapFunc = a => a + 1;
        Func<int, int, int> reduceFunc = (a, b) => a + b;

        bool mapWorks = map(inputList, mapFunc).SequenceEqual(mappedList);
        bool reduceWorks = reduce(inputList, reduceFunc, 4) == 10;

        Console.WriteLine("Running tests");
        Console.WriteLine("Reduce works: " + reduceWorks);
        Console.WriteLine("Map works: " + mapWorks);
    }

    // use for(each) loops to implement below functions
    public static List<B> map<A, B>(List<A> list, Func<A, B> func)
    {
        List<B> bList = new List<B>();
        list.ForEach((x) => bList.Add(func(x)));
        return bList;
    }

    public static B reduce<A, B>(List<A> list, Func<B, A, B> func, B initial)
    {
        bool measure = typeof(A) == typeof(B);
        list.ForEach(x => initial = func(initial, x));
        return initial;
    }
}