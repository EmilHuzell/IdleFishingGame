using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Fish
{
    public class FishStore : MonoBehaviour
    {
        private FishType fish;
        public RawImage fishImage;
        public Text fishWeight;
        public Button[] buttons;
        public Text marketText;
        private float marketPrice;
        public float maxPriceMultifier;
        public float updateInterval = 5;
        private float elapsedTime;
        private int[] sellAmount = {10,100,1000};

        private void Start()
        {
            CalculatePrice();
            ButtonUI();
        }

        private void Update()
        {
            fishWeight.text = $"{fish.Weight}";
            ButtonUI();
            UpdatePrice();
        }
        
        private void UpdatePrice()
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= updateInterval)
            {
                CalculatePrice();
                elapsedTime = 0;
            }
        }

        private void ButtonUI()
        {
            for (int i = 0; i < 4; i++)
            {
                if (i != 3)
                {
                    buttons[i].GetComponentInChildren<Text>().text = $"Sell\nX{sellAmount[i]}";
                    buttons[i].gameObject.active = fish.Weight >= sellAmount[i];
                }
                else
                {
                    buttons[i].GetComponentInChildren<Text>().text = $"Sell\nAll";
                    buttons[i].gameObject.active = fish.Weight != 0;
                }


            }
        }
        
        private void CalculatePrice()
        {
        marketPrice = Random.Range(fish.minPrice,fish.minPrice*maxPriceMultifier);
            marketText.text = $"{marketPrice.ToString("F")} Gold/Kg";
        }

        public void OnClicked(Button button)
        {
            switch (button.name)
            {
                case "SellButton1":
                    sellFish(sellAmount[0]);
                    break;
                case "SellButton2":
                    sellFish(sellAmount[1]);
                    break;
                case "SellButton3":
                    sellFish(sellAmount[2]);
                    break;
                case "SellButton4":
                    sellFish(fish.Weight);
                    break;
                default:
                    return;
            }
        }
        public void sellFish(int amount)
        {
            if (fish.Weight >= amount)
            {
                fish.Weight -= amount;
                Gold.AddGold(new BigInteger(amount * marketPrice));
            }
        }
        public void setup(FishType fishType)
        {
            gameObject.name = fishType.name;
            fish = fishType;
            this.fishImage.texture = fishType.image;
        }
    }
}