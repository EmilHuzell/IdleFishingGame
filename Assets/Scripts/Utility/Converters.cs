using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using UnityEngine;

public static class Converters {
    public static string BigIntToString(BigInteger bigIntegerToConvert) {
        return bigIntegerToConvert.ToString();
    }

    public static BigInteger StringToBigInt(string stringToConvert) {
        BigInteger.TryParse(stringToConvert, out var bigInt);
        return bigInt;
    }

    public static float BigIntToFloat(BigInteger bigIntegerToConvert) {
        return float.Parse(BigIntToString(bigIntegerToConvert));
    }

    public static BigInteger FloatToBigInt(float floatToConvert) {
        var final = Mathf.Round(floatToConvert);
        return BigInteger.Parse(final.ToString(CultureInfo.InvariantCulture));
    }

    public static BigInteger TakeAmountOfNumbers(BigInteger initialNumber, int numbersToTake) {
        var numberString = BigIntToString(initialNumber).Take(numbersToTake);
        return StringToBigInt(string.Concat(numberString));
    }

    public static BigInteger DoubleToBigInt(double doubleToConvert) {
        return (BigInteger) doubleToConvert;
    }

    public static Double BigIntToDouble(BigInteger bigIntegerToConvert)
    {
        return (double) bigIntegerToConvert;
    }
}