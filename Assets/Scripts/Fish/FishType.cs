using System.Numerics;
using UnityEngine;

[CreateAssetMenu]
public class FishType : ScriptableObject
{
    public int sizeMin = 5;
    public int sizeMax = 10;
    public float minPrice = 2;
    public Texture image;

    public BigInteger Weight
    {
        get => SaveMethods.LoadValue($"{name}", "0");
        set => SaveMethods.SaveValue($"{name}", value);
    }
}

