// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var n = EnterTheNumber("n(count)");
        var m = EnterTheNumber("m(step)");
        var x = EnterTheNumber("x(from)");
        var sum = x;

        for (var i = x; i <= x + (n * m); i += m)
            sum += x;

        Console.WriteLine($"sum = {sum}");
    }
    
    private static int EnterTheNumber (string variableName) 
    {
        Console.WriteLine($"Enter the number {variableName}: ");
        var number = 0;
        
        while (!int.TryParse(Console.ReadLine(), out number))
            Console.WriteLine("You didn't enter a number! Try again");
        
        return number;
    }
}