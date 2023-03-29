// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var array = new[,] {{1, 2, 3, 8, 4},{4, 5, 6, 7, 3},{7, 8, 9, 6, 2}, {0, 1, 2, 5, 1}, {1, 2, 3, 4, 5}};

        Console.WriteLine("array before:");
        PrintTwoDimensionalArray(array);
        var strings = array.GetUpperBound(0) + 1;
        var columns = array.GetUpperBound(1);

        for (var i = 0; i < strings; i++)
            (array[i, i], array[i, columns - i]) = (array[i, columns - i], array[i, i]);
        
        Console.WriteLine("array before:");
        PrintTwoDimensionalArray(array);
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