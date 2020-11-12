using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFisherType : MonoBehaviour
{
    public Texture texture;
    public int BaseProduce;
    public float ProduceIncrease;
    public int BaseCost;
    public float CostIncrease;

    public int CurrentCost(int upgradeAmount)
    {
        return Mathf.RoundToInt(BaseCost * Mathf.Pow(CostIncrease, upgradeAmount));
    }
    public int CurrentProduction(int producerAmount)
    {
        return Mathf.RoundToInt(BaseProduce * Mathf.Pow(ProduceIncrease, producerAmount));
    }
}
