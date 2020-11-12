using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class AutoFisher : MonoBehaviour
{
    public AutoFisherType autoFisherType;
    public float timeInvested;
    public string currentUpgradeCost;

    public int FisherAmount { get => PlayerPrefs.GetInt($"{autoFisherType.name}_Amount", 0); set => PlayerPrefs.SetInt($"{autoFisherType.name}_Amount", value); }

    void Update()
    {
        timeInvested += Time.deltaTime;
        if(timeInvested > autoFisherType.ProduceTime)
        {
            Produce();
        }
        currentUpgradeCost = Converters.BigIntToString(autoFisherType.CurrentCost(FisherAmount));

        if (Input.GetKeyDown(KeyCode.U))
        {
            Upgrade();
        }
    }
    void Produce()
    {
        timeInvested -= autoFisherType.ProduceTime;
        Gold.AddGold(autoFisherType.CurrentProduction(FisherAmount));
    }
    public void Upgrade()
    {
        Gold.RemoveGold(autoFisherType.CurrentCost(FisherAmount));
        {
            FisherAmount++;
            Debug.Log("Amount of fishers is: " + FisherAmount);
        }
    }
}
