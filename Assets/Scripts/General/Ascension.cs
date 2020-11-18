using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public static class Ascension
{
    public static int Amount { get => PlayerPrefs.GetInt("Ascension_Amount", 0); set => PlayerPrefs.SetInt("Ascension_Amount", value); }

    public static float Multiplier { get => (Amount * 1.1f) + 1; }

    public static BigInteger Requirement { get => 1000 * BigInteger.Pow(10, PlayerPrefs.GetInt("Ascension_Amount", 0)); }

    public static void Ascend()
    {
        Gold.CurrentGold = 0;
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            foreach (IAscend ascend in go.GetComponents<IAscend>())
            {
                ascend.Ascend();
            }
        }
        Amount++;
    }
}
public interface IAscend
{
    void Ascend();
}