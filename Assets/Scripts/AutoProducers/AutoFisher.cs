using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class AutoFisher : MonoBehaviour, IAscend
{
    public AutoFisherType autoFisherType;

    public float timeInvested;

    public Sprite icon;
    public Image buttonIcon;
    public Text producerName;
    public Text unitCostText;
    public Text upgradeCostText;
    public Text unitAmountText;
    public Button addUnitButton;
    public Button upgradeButton;

    public bool CanAffordUnit { get => autoFisherType.amount.CanAfford; }
    public bool CanAffordUpgrade { get => autoFisherType.upgrade.CanAfford; }

    public void Start()
    {
        UpdateUI();
        AddSleepProduction();
        if (addUnitButton != null)
        {
            addUnitButton.onClick.AddListener(delegate { AddUnit(); });
        }
        if (upgradeButton != null)
        {
            upgradeButton.onClick.AddListener(delegate { AddUpgrade(); });
        }
    }
    public void Setup(AutoFisherType autoFisherType)
    {
        this.autoFisherType = autoFisherType;
    }
    public void Ascend()
    {
        autoFisherType.Reset();
        UpdateUI();
    }

    //Updates
    void Update() 
    {
        Produce();
    }
    void Produce() 
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
        UpdateUI();
    }
    public void AddUpgrade()
    {
        autoFisherType.upgrade.Upgrade();
        UpdateUI();
    }

    //UI
    void UpdateUI()
    {
        UpdateName(); //<- Aware that this only needs to be called once when doing the setup.
        UpdateUnitCostText();
        UpdateUpgradeCostText();
        UpdateUnitAmountText();
        UpdateSprite();
    }
    void UpdateName()
    {
        if (producerName != null)
            producerName.text = autoFisherType.name;
    }
    void UpdateUnitCostText()
    {
        if (unitCostText != null)
            unitCostText.text = $"Costs: {PrettifyText.Format(autoFisherType.amount.CurrentCost)}";
    }
    void UpdateUpgradeCostText()
    {
        if (upgradeCostText != null)
            upgradeCostText.text = $"Costs: {PrettifyText.Format(autoFisherType.upgrade.CurrentCost)}";
    }
    void UpdateUnitAmountText()
    {
        if (unitAmountText != null)
            unitAmountText.text = autoFisherType.Amount.ToString();
    }
    void UpdateSprite()
    {
        if(buttonIcon != null && icon != null)
            buttonIcon.sprite = icon;
    }

    //ON START
    void AddSleepProduction()
    {
        Gold.AddGold(autoFisherType.CurrentProduction() * Converters.DoubleToBigInt(SystemTime.difference.TotalSeconds * 0.25f));
        //Debug.Log(SystemTime.difference.TotalSeconds);
        //Debug.Log(Converters.DoubleToBigInt(SystemTime.difference.TotalSeconds * 0.25f));
    }
}