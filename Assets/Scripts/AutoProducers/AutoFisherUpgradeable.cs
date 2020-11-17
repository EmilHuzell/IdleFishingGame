using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[System.Serializable]
public class AutoFisherUpgradeable
{
    public string saveCode;

    public BigInteger Amount { get => SaveMethods.LoadValue($"{saveCode}", "0"); set => SaveMethods.SaveValue($"{saveCode}", value); }
    public BigInteger CurrentCost { get => MathFunctions.BigIntegerPow(baseCost, costIncrease, Amount, true); }

    public bool CanAfford { get => CurrentCost <= Gold.CurrentGold; }

    public int amountEffect = 1;
    [SerializeField] float costIncrease = 1.05f;
    [SerializeField] int baseCost = 20; //BE AWARE! The upgrade value always rounds down. So basecost * costincrease ALWAYS have to result in basecost+1 or higher!!!

    public bool Upgrade()
    {
        if (CanAfford)
        {
            Gold.RemoveGold(CurrentCost);
            Amount++;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        Debug.Log("DidAReset");
        Amount = 0;
    }
}
