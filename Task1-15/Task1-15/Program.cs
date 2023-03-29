// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var someString = "test test A test B  233 aaa aAAAGYDHUA JLKaklsiijals; klf;irk sf.sfdrg f    gdg 15 gg";
        var chars = new[]{ ' ', '.', ',', ';', ':', '?', '\n', '\r' };
        var words = someString.Split(chars, StringSplitOptions.RemoveEmptyEntries);
        var count = 0;

        foreach (var word in words)
            if (!int.TryParse(word, out _))
                count++;
        
        Console.WriteLine(count);
    }
}