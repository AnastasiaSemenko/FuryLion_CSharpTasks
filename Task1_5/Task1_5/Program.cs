// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        Console.Write("Enter a number: ");
        var number = 0;
        
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
            Console.WriteLine("Enter a number greater than 0.");

        var evenNums = EvenNumbers(number);
        Console.Write("Even numbers - ");
        
        foreach (var item in evenNums)
            Console.Write($"{item} ");
    }

    private static int[] EvenNumbers(int before)
    {
        var numbers = new int[before / 2 + 1];

        for (var i = 0; i < numbers.Length; i++)
            numbers[i] = i * 2;

        return numbers;
    }
}