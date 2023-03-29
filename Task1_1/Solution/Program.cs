// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var numbers = new List<int>();

        Console.WriteLine("Enter the numbers: ");
        
        for (var i = 0; i < 3; i++)
        {
            var num = 0;
            
            while (!int.TryParse(Console.ReadLine(), out num))
                Console.WriteLine("You didn't enter a number! Try again");
            
            numbers.Add(num);
        }

        numbers.Sort();
        
        foreach (var num in numbers)
            Console.Write($"{num} ");
    }
}