using UnityEngine;
using System.Numerics;

public static class MathFunctions
{
    public static BigInteger MultiplyBigIntByFloat(BigInteger value, float f)
    {
        value *= Mathf.RoundToInt(f * 100);
        return (value / 100);
    }

    public static float MultiplyFloatByBigInt(float value, BigInteger bigInteger)
    {
        return (float)BigInteger.Multiply(Mathf.RoundToInt(value), bigInteger);
    }
}
