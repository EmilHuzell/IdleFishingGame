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

    //public BigInteger CurrentCost { get => SaveMethods.LoadValue($"{name}_Cost", BaseCost.ToString()); set => SaveMethods.SaveValue($"{name}_Cost", value); }
    public BigInteger UpgradeCost { get => upgrade.CurrentCost; }
    public BigInteger UnitCost { get => amount.CurrentCost; }

    public BigInteger CurrentProduction()
    {
        return (BaseProduce * amount.amountEffect) * (upgrade.amountEffect + 1);
    }
}
