// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var someArray = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        Console.Write("mas before - ");

        foreach (var item in someArray)
            Console.Write($"{item} ");

        for (var i = 0; i < someArray.Length / 2; i++)
            (someArray[i], someArray[^(i + 1)]) = (someArray[^(i + 1)], someArray[i]);

        Console.Write("\nmas after - ");

        foreach (var item in someArray)
            Console.Write($"{item} ");
    }
}