using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFisher : MonoBehaviour
{
    public AutoFisherType autoFisherType;
    public float timeInvested;
    public int fisherAmount = 0;
    public int currentUpgradeCost;

    void Update()
    {
        timeInvested += Time.deltaTime;
        if(timeInvested > autoFisherType.ProduceTime)
        {
            Produce();
        }
        currentUpgradeCost = autoFisherType.CurrentCost(fisherAmount);
    }
    void Produce()
    {
        timeInvested -= autoFisherType.ProduceTime;
        Gold.AddGold(autoFisherType.CurrentProduction(fisherAmount));
    }
    public void Upgrade()
    {
        if (Gold.RemoveGold(autoFisherType.CurrentCost(fisherAmount)))
        {
            fisherAmount++;
        }
    }
}
