// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var someArray = new []{ 1, 2, 3, 4, 5, 6, 7, 8 };
        var evenSum = 0;
        var oddSum = 0;
        
        for (var i = 0; i < someArray.Length; i++)
        {
            if (i % 2 == 1) 
                oddSum += someArray[i];
            else 
                evenSum += someArray[i];
        }

        Console.Write("mas - { ");
        
        foreach (var item in someArray) 
            Console.Write($"{item} ");
        
        Console.WriteLine($"}}\nevenSum - {evenSum}\noddSum - {oddSum}");
    }
}