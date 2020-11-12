using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

[CreateAssetMenu(menuName = "Types/AutoFisherType")]
public class AutoFisherType : ScriptableObject
{
    public Texture texture;
    public int BaseProduce = 10;
    //public float ProduceIncrease = 1.05f;
    public int BaseCost = 10;
    public int CostIncrease = 2; //Should be float... Currently a int due to BigInteger.Pow
    public float ProduceTime = 1;

    public BigInteger CurrentCost(BigInteger producerAmount)
    {
        return BaseCost * BigInteger.Pow(producerAmount, 2);
    }
    public BigInteger CurrentProduction(int producerAmount)
    {
        return BaseProduce * producerAmount;
    }
}
