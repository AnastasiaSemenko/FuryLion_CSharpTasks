// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        Console.Write("Enter a number: ");

        if (int.TryParse(Console.ReadLine(), out var number))
            Console.WriteLine($"factorial {number} is {Factorial(number)}");
        else
            Console.WriteLine("You didn't enter a number!");
    }

    private static int Factorial(int number)
    {
        if (number is 0 or 1) 
            return 1;
        
        return number * Factorial(number - 1);
    }
}