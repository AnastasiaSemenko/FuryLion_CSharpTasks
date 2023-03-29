// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var someString = "test test test A test B aaa aAAAGYDHUAJLKaklsiijals;";
        var count = 0;
        
        foreach (var symbol in someString)
            if (symbol == 'A')
                count++;

        Console.WriteLine(count);
    }
}