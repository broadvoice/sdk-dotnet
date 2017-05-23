using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AuthorizeNET_xunit
{
    public class RandomStringGenerator
{
    readonly Random _rand;

    public RandomStringGenerator(int seed = 0)
    {
        _rand = new Random(seed);
    }

    public string Len(int min, int max = Int32.MaxValue)
    {
        int size = _rand.Next(min, max);
        string resultString = GetRandomBase64EncodedData(size);
        if (resultString.Length > size)
        {
            return resultString.Substring(0, size);
        }
        return resultString;
    }

    private static string GetRandomBase64EncodedData(int size)
    {
        return Convert.ToBase64String(GetRandomByteArray(size));
    }

    private static Byte[] GetRandomByteArray(int size)
    {
        byte[] value = new byte[size];
        var random = RandomNumberGenerator.Create();
        random.GetBytes(value);
        return value;
    }
}
}
