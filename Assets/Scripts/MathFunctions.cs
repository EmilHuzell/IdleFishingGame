using UnityEngine;
using System.Numerics;

public static class MathFunctions
{
    public static BigInteger MultiplyBigIntByFloat(BigInteger value, float f)
    {
        return (value * Mathf.RoundToInt(f * 100)) / 100;
    }

    public static float MultiplyFloatByBigInt(float value, BigInteger bigInteger)
    {
        return (float)BigInteger.Multiply(Mathf.RoundToInt(value), bigInteger);
    }

    public static BigInteger BigIntegerPow(BigInteger value, float percent, BigInteger amount)
    {
        for (int i = 0; i < amount; i++)
        {
            value = MultiplyBigIntByFloat(value, percent);
        }
        return value;
    }
}
