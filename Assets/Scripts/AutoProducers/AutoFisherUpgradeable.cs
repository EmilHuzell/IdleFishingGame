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

    public float AmountEffect { get => System.Int32.Parse(Amount.ToString()) * amountEffect; }
    public float amountEffect = 1;
    [SerializeField] float costIncrease = 1.05f;
    [SerializeField] int baseCost = 10;

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
        Amount = 0;
    }
}
