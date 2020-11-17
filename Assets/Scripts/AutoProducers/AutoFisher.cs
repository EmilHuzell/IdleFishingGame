using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class AutoFisher : MonoBehaviour, IAscend
{
    public AutoFisherType autoFisherType;

    public float timeInvested;

    public Text producerName;
    public Text unitCostText;
    public Text upgradeCostText;

    public int FisherAmount { get => PlayerPrefs.GetInt($"{autoFisherType.name}_Amount", 0); set => PlayerPrefs.SetInt($"{autoFisherType.name}_Amount", value); }
    public int UpgradeAmount { get => PlayerPrefs.GetInt($"{autoFisherType.name}_Upgrades", 0); set => PlayerPrefs.SetInt($"{autoFisherType.name}_Upgrades", value); }

    public bool CanAffordUnit { get => autoFisherType.amount.CanAfford; }
    public bool CanAffordUpgrade { get => autoFisherType.upgrade.CanAfford; }

    public void Setup(AutoFisherType autoFisherType)
    {
        this.autoFisherType = autoFisherType;
        UpdateUI();
        AddSleepProduction();
    }
    public void Ascend()
    {
        autoFisherType.Reset();
        UpdateUI();
    }

    //Updates
    void Update() //Works as intended
    {
        Produce();
    }
    void Produce() //Revamp
    {
        timeInvested += Time.deltaTime;
        if (timeInvested > autoFisherType.ProduceTime)
        {
            timeInvested -= autoFisherType.ProduceTime;
            Gold.AddGold(autoFisherType.CurrentProduction());
        }
    }

    //Upgrades
    public void AddUnit()
    {
        autoFisherType.amount.Upgrade();
        UpdateUnitCostText();
    }
    public void AddUpgrade()
    {
        autoFisherType.upgrade.Upgrade();
        UpdateUpgradeCostText();
    }

    //UI
    void UpdateUI()
    {
        UpdateName(); //<- Aware that this only needs to be called once when doing the setup.
        UpdateUnitCostText();
        UpdateUpgradeCostText();
    }
    void UpdateName()
    {
        if (producerName != null)
            producerName.text = autoFisherType.name;
    }
    void UpdateUnitCostText()
    {
        if (unitCostText != null)
            unitCostText.text = $"Costs: {autoFisherType.amount.CurrentCost}";
    }
    void UpdateUpgradeCostText()
    {
        if (upgradeCostText != null)
            upgradeCostText.text = $"Costs: {autoFisherType.upgrade.CurrentCost}";
    }

    //ON START
    void AddSleepProduction() //Make gold take upgrades into consideration
    {
        Gold.AddGold(autoFisherType.CurrentProduction() * Converters.DoubleToBigInt(SystemTime.difference.TotalSeconds * 0.25f));
        //Debug.Log(SystemTime.difference.TotalSeconds);
        //Debug.Log(Converters.DoubleToBigInt(SystemTime.difference.TotalSeconds * 0.25f));
    }
}