using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

[CreateAssetMenu(menuName = "Types/AutoFisherType")]
public class AutoFisherType : ScriptableObject
{
    public int BaseProduce = 1;
    public float ProduceTime = 1;

    public AutoFisherUpgradeable amount;
    public AutoFisherUpgradeable upgrade;

    public BigInteger Amount { get => amount.Amount; }
    public BigInteger Upgrades { get => upgrade.Amount; }

    public BigInteger UpgradeCost { get => upgrade.CurrentCost; }
    public BigInteger UnitCost { get => amount.CurrentCost; }

    public BigInteger CurrentProduction()
    {
        return MathFunctions.MultiplyBigIntByFloat((BaseProduce * amount.amountEffect) * (upgrade.amountEffect + 1), Ascension.Multiplier);
    }
    public void Reset()
    {
        amount.Reset();
        upgrade.Reset();
    }
}
