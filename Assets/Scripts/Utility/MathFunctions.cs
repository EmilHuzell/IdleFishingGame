using UnityEngine;
using System.Numerics;

public static class MathFunctions
{
    public static BigInteger MultiplyBigIntByFloat(BigInteger value, float f, bool roundUp = false)
    {
        BigInteger returnValue = ((value * Mathf.RoundToInt(f * 100)) / 100);
        if (roundUp) 
        {
            return returnValue + 1;
        }
        return returnValue;
    }
    public static float MultiplyFloatByBigInt(float value, BigInteger bigInteger)
    {
        return (float)BigInteger.Multiply(Mathf.RoundToInt(value), bigInteger);
    }

    public static BigInteger BigIntegerPow(BigInteger value, float percent, BigInteger amount, bool roundUp = false)
    {
        for (int i = 0; i < amount; i++)
        {
            value = MultiplyBigIntByFloat(value, percent, roundUp);
        }
        return value;
    }
}
