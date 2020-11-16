using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class AutoFisher : MonoBehaviour
{
    public AutoFisherType autoFisherType;
    public float timeInvested;
    public string currentUpgradeCost;
    public Image image;
    public Text producerName;
    public Text costText;

    public int FisherAmount { get => PlayerPrefs.GetInt($"{autoFisherType.name}_Amount", 0); set => PlayerPrefs.SetInt($"{autoFisherType.name}_Amount", value); }
    public int UpgradeAmount { get => PlayerPrefs.GetInt($"{autoFisherType.name}_Upgrades", 0); set => PlayerPrefs.SetInt($"{autoFisherType.name}_Upgrades", value); }

    public BigInteger CurrentCost { get => autoFisherType.CurrentCost; }

    public bool CanAfford { get => Gold.CurrentGold >= CurrentCost; }
    public bool CanAffordUpgrade { get => Gold.CurrentGold >= CurrentCost; }

    public void Setup(AutoFisherType autoFisherType)
    {
        this.autoFisherType = autoFisherType;
        UpdateNameAndIcon();
        UpdateCostText();
        AddSleepProduction();
    }
    void Update()
    {
        timeInvested += Time.deltaTime;
        if(timeInvested > autoFisherType.ProduceTime)
        {
            Produce();
        }
    }
    void Produce()
    {
        timeInvested -= autoFisherType.ProduceTime;
        Gold.AddGold(autoFisherType.CurrentProduction(FisherAmount));
    }
    public void Upgrade()
    {
        if (CanAfford)
        {
            Gold.RemoveGold(CurrentCost);
            FisherAmount++;
            //Debug.Log("Amount of fishers is: " + FisherAmount);
            autoFisherType.UpdateCost();
            UpdateCostText();
        }
    }
    void UpdateNameAndIcon()
    {
        if (producerName != null)
            producerName.text = autoFisherType.name;
        if (autoFisherType.icon != null && image != null)
        {
            image.sprite = autoFisherType.icon;
        }
    }
    void UpdateCostText()
    {
        currentUpgradeCost = Converters.BigIntToString(CurrentCost);
        if (costText != null)
            costText.text = $"Costs: {currentUpgradeCost}";
    }
    void AddSleepProduction()
    {
        Gold.AddGold(autoFisherType.CurrentProduction(FisherAmount) * Converters.DoubleToBigInt(SystemTime.difference.TotalSeconds * 0.25f));
        //Debug.Log(SystemTime.difference.TotalSeconds);
        //Debug.Log(Converters.DoubleToBigInt(SystemTime.difference.TotalSeconds * 0.25f));
    }
}

[System.Serializable]
public class UpgradeItem
{
    string name;
    string type;

    public BigInteger Amount { get => SaveMethods.LoadValue($"{name}_{type}", "0"); set => SaveMethods.SaveValue($"{name}_{type}", value); }
    public BigInteger CurrentCost { get => MathFunctions.BigIntegerPow(baseCost, costIncrease, Amount); }

    public float costIncrease = 1.05f;
    public int baseCost = 10;

    public bool Upgrade()
    {
        if (CurrentCost <= Gold.CurrentGold)
        {
            Amount++;
            return true;
        }
        return false;
    }
}
