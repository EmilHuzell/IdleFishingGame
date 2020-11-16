using System.Numerics;
using UnityEngine;
public class Gold : MonoBehaviour
{
    public static BigInteger CurrentGold { get => SaveMethods.LoadValue("Gold"); set => SaveMethods.SaveValue("Gold", value); }

    public static void AddGold(BigInteger goldToAdd) {
        CurrentGold += goldToAdd;
    }

    public static void MultiplyGold(BigInteger multiplyFactor) {
        CurrentGold *= multiplyFactor;
    }
    
    public static bool RemoveGold(BigInteger goldToRemove) {
        if (goldToRemove <= 0) return false;
        CurrentGold -= goldToRemove;
        return true;
    }
}