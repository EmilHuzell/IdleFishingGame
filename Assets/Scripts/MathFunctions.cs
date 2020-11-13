using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public static class MathFunctions
{
    public static BigInteger MultiplyBigIntByFloat(BigInteger value, float f)
    {
        value *= Mathf.RoundToInt(f * 100);
        return (value / 100);
    }
}
