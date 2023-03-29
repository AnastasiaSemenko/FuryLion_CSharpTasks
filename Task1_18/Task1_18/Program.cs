// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Text.RegularExpressions;

public static class Program
{
    public static void Main()
    {
        var str = "test test Kak A test B KAK 233KAAR kain gdg 15 gg";
        var count = Regex.Matches(str, "\b+K([a-z]+|[A-Z]+)\b+").Count;
        Console.WriteLine(count);
    }
}