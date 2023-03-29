// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var someArray = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var n = 4;
        var m = 5;
        var moreThanMSum = 0;
        var lessThanNSum = 0;

        foreach (var item in someArray)
        {
            if (item > m)
                moreThanMSum += item;
            else if (item < n)
                lessThanNSum += item;
        }

        Console.Write("array - { ");

        foreach (var item in someArray)
            Console.Write($"{item} ");

        Console.WriteLine($"}}\na) Sum - {moreThanMSum}\nb) Sum - {lessThanNSum}");
    }
}