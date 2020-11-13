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
    public Text producerName;
    public Text costText;

    public int FisherAmount { get => PlayerPrefs.GetInt($"{autoFisherType.name}_Amount", 0); set => PlayerPrefs.SetInt($"{autoFisherType.name}_Amount", value); }
    public BigInteger CurrentCost { get => autoFisherType.CurrentCost; }
    public bool CanAfford { get => Gold.CurrentGold >= CurrentCost; }

    public void Setup(AutoFisherType autoFisherType)
    {
        this.autoFisherType = autoFisherType;
        UpdateNameAndIcon();
        UpdateCostText();
    }
    void Update()
    {
        timeInvested += Time.deltaTime;
        if(timeInvested > autoFisherType.ProduceTime)
        {
            Produce();
        }
        if (false && Input.GetKeyDown(KeyCode.U))
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
        if (CanAfford)
        {
            Gold.RemoveGold(CurrentCost);
            FisherAmount++;
            Debug.Log("Amount of fishers is: " + FisherAmount);
            autoFisherType.UpdateCost();
            UpdateCostText();
        }
    }
    void UpdateNameAndIcon()
    {
        if (producerName != null)
            producerName.text = autoFisherType.name;
    }
    void UpdateCostText()
    {
        currentUpgradeCost = Converters.BigIntToString(CurrentCost);
        if (costText != null)
            costText.text = $"Costs: {currentUpgradeCost}";
    }
}
