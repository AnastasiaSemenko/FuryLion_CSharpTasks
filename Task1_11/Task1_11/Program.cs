// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var someArray = new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 0, 1, 2 }, {3, 3, 3} };
        Console.WriteLine("mas before:");
        PrintTwoDimensionalArray(someArray);

        for (var i = 0; i < someArray.GetUpperBound(0); i += 2)
            for (var j = 0; j <= someArray.GetUpperBound(1); j++)
                (someArray[i, j], someArray[i + 1, j]) = (someArray[i + 1, j], someArray[i, j]);

        Console.WriteLine("mas after:");
        PrintTwoDimensionalArray(someArray);
    }

    private static void PrintTwoDimensionalArray(int[,] array)
    {
        for (var i = 0; i <= array.GetUpperBound(0); i++)
        {
            for (var j = 0; j <= array.GetUpperBound(1); j++)
                Console.Write($"{array[i, j]}\t");

            Console.WriteLine();
        }
    }
}