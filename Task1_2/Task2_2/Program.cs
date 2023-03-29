// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        Console.Write("Enter a number: ");
        var number = Console.ReadLine();
        
        if (int.TryParse(number, out _))
            Console.WriteLine(number.Reverse().ToArray());
        else
            Console.WriteLine("You didn't enter a number!");
    }
}