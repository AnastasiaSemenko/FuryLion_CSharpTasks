// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var someString = "computer";
        var arrayLetters = someString.ToCharArray();
        Array.Reverse(arrayLetters);
        Console.WriteLine(new string(arrayLetters));
    }
}