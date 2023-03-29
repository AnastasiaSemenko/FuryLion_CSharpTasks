// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        Console.Write("Enter a number: ");
        var number = 0;
        
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
            Console.WriteLine("Enter a number greater than 0.");

        var perfectNumbers = FindPerfectNumbers(number);

        if (perfectNumbers.Count == 0)
        {
            Console.WriteLine("Perfect numbers not found!");
            return;
        }
        
        Console.Write("Perfect numbers - ");
            
        foreach (var item in perfectNumbers) 
            Console.Write($"{item} ");
    }

    private static List<int> FindPerfectNumbers(int someNumber)
    {
        var nums = new List<int>();
        
        for (var i = 1; i <= someNumber; i++)
        {
            var sum = 0;
            
            for (var del = 1; del <= i / 2; del++)
                if (i % del == 0) 
                    sum += del;
            
            if (sum == i)
                nums.Add(i);
        }

        return nums;
    }
}