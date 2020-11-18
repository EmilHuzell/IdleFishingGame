using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public static class Ascension
{
    public static int Amount { get => PlayerPrefs.GetInt("Ascension_Amount", 0); set => PlayerPrefs.SetInt("Ascension_Amount", value); }

    public static float Multiplier { get => (Amount * 1.1f) + 1; }

    public static BigInteger Requirement { get =>  BigInteger.Pow(10, PlayerPrefs.GetInt("Ascension_Amount", 0)); }

    public static void Ascend()
    {
        Gold.CurrentGold = 0;
        foreach (GameObject gameObject in GameObject.FindObjectsOfType<GameObject>())
        {
            foreach (IAscend ascend in gameObject.GetComponents<IAscend>())
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