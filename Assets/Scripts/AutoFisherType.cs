using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Types/AutoFisherType")]
public class AutoFisherType : ScriptableObject
{
    public Texture texture;
    public int BaseProduce = 10;
    //public float ProduceIncrease = 1.05f;
    public int BaseCost = 10;
    public float CostIncrease = 1.05f;
    public float ProduceTime = 1;

    public int CurrentCost(int producerAmount)
    {
        return Mathf.RoundToInt(BaseCost * Mathf.Pow(CostIncrease, producerAmount));
    }
    public int CurrentProduction(int producerAmount)
    {
        return Mathf.RoundToInt(BaseProduce * producerAmount);
    }
}
