using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Fish
{
    public class FishStore : MonoBehaviour
    {
        private FishType fish;
        public RawImage fishImage;
        public Text fishWeight;
        public Button button1;
        public Button button2;
        public Button button3;
        public Button button4;
        public Text marketText;
        private float marketPrice;
        public float maxPriceMultifier;
        public float updateInterval = 5;
        private float elapsedTime;
        private int sellMultifier1 = 10;
        private int sellMultifier2 = 100;
        private int sellMultifier3 = 1000;

        private void Start()
        {
            priceUI();
        }

        private void Update()
        {
            fishWeight.text = $"{fish.Weight}";
            button1.GetComponentInChildren<Text>().text= $"X{sellMultifier1}";
            button2.GetComponentInChildren<Text>().text= $"X{sellMultifier2}";
            button3.GetComponentInChildren<Text>().text = $"X{sellMultifier3}";
            button4.GetComponentInChildren<Text>().text = $"All";
            UpdatePrice();
        }
        
        private void UpdatePrice()
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= updateInterval)
            {
                priceUI();
                elapsedTime = 0;
            }
        }

        private void priceUI()
        {
            marketPrice = Random.Range(fish.minPrice,fish.minPrice*maxPriceMultifier);
            marketText.text = $"{marketPrice.ToString("F")} Gold/Kg";
        }

        public void OnClicked(Button button)
        {
            switch (button.name)
            {
                case "SellButton1":
                    sellFish(sellMultifier1);
                    break;
                case "SellButton2":
                    sellFish(sellMultifier2);
                    break;
                case "SellButton3":
                    sellFish(sellMultifier3);
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