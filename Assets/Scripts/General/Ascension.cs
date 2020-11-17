using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Ascension
{
    public static int Amount { get => PlayerPrefs.GetInt("Ascension_Amount", 0); set => PlayerPrefs.SetInt("Ascension_Amount", value); }

    public static float Multiplier { get => (Amount * 1.1f) + 1; }

    public static void Ascend()
    {
        foreach (IAscend item in Object.FindObjectsOfType<Component>())
        {
            item.Ascend();
        }
    }
}
public interface IAscend
{
    void Ascend();
}