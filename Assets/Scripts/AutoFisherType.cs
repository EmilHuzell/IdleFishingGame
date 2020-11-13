using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

[CreateAssetMenu(menuName = "Types/AutoFisherType")]
public class AutoFisherType : ScriptableObject
{
    public Sprite icon;
    public int BaseProduce = 10;
    //public float ProduceIncrease = 1.05f;
    public int BaseCost = 10;
    public float CostIncrease = 1.05f;
    public float ProduceTime = 1;

    public BigInteger CurrentCost { get => SaveMethods.LoadValue($"{name}_Cost", BaseCost.ToString()); set => SaveMethods.SaveValue($"{name}_Cost", value); }

    public void UpdateCost()
    {
        CurrentCost = MathFunctions.MultiplyBigIntByFloat(CurrentCost, CostIncrease);
    }
    public BigInteger CurrentProduction(int producerAmount)
    {
        return BaseProduce * producerAmount;
    }
}
