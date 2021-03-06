﻿using System.Numerics;
using UnityEngine;

public static class SaveMethods {
    public static void SaveValue(string type, BigInteger value) {
        PlayerPrefs.SetString(type, Converters.BigIntToString(value));
    }

    public static BigInteger LoadValue(string type)
    {
        return Converters.StringToBigInt(PlayerPrefs.GetString(type));
    }
    public static BigInteger LoadValue(string type, string defaultValue)
    {
        if(PlayerPrefs.GetString(type) == "")
        {
            PlayerPrefs.SetString(type, defaultValue);
        }
        return Converters.StringToBigInt(PlayerPrefs.GetString(type));
    }
}
