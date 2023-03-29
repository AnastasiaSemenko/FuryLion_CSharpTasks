// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var someArray = new[] { 1, -5, -84, 4, 8, -4, -12, -2 };

        Console.Write("array before - ");

        foreach (var item in someArray)
            Console.Write($"{item} ");

        for (var i = 0; i < someArray.Length; i++)
            for (var j = 0; j < someArray.Length; j++)
                if (someArray[i] < 0 && someArray[j] < 0 && someArray[i] < someArray[j])
                    (someArray[i], someArray[j]) = (someArray[j], someArray[i]);

        Console.Write("\narray after - ");

        foreach (var item in someArray)
            Console.Write($"{item} ");
    }
}