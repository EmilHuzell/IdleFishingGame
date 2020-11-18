using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

namespace Fish
{
    public class FishMarket : MonoBehaviour, IAscend
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
        private readonly BigInteger[] sellAmount = {10, 100, 1000};

        private void Start()
        {
            CalculatePrice();
            ButtonUI();
        }

        private void Update()
        {
            fishWeight.text = PrettifyText.Format(fish.Weight);
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
        public void Ascend()
        {
            fish.Reset();
        }
        private void ButtonUI()
        {
            for (var i = 0; i < 4; i++)
                if (i != 3)
                {
                    buttons[i].GetComponentInChildren<Text>().text = $"Sell\nX{sellAmount[i]}";
                    // buttons[i].gameObject.active = fish.Weight >= sellAmount[i];
                    buttons[i].gameObject.SetActive(fish.Weight >= sellAmount[i]);
                }
                else
                {
                    // buttons[i].GetComponentInChildren<Text>().text = "Sell\nAll";
                    buttons[i].gameObject.SetActive(fish.Weight != 0);
                }
        }

        private void CalculatePrice()
        {
            marketPrice = Random.Range(fish.minPrice, fish.minPrice * maxPriceMultifier);
            marketText.text = $"{marketPrice.ToString()}";
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

        public void sellFish(BigInteger amount)
        {
            if (fish.Weight >= amount)
            {
                fish.Weight -= amount;
                var dAmount = (double) amount;
                var result = dAmount * marketPrice;
                Gold.AddGold(new BigInteger(result));
            }
        }

        public void setup(FishType fishType)
        {
            gameObject.name = fishType.name;
            fish = fishType;
            fishImage.texture = fishType.image;
        }
    }
}