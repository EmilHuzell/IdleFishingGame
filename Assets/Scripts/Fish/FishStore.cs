using System;
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
        public Text button1;
        public Text button2;
        public Text button3;
        public Text marketText;
        private float marketPrice;
        public float maxPriceMultifier;
        public float updateInterval = 5;
        private float elapsedTime;

        private void Start()
        {
            priceUI();
        }

        private void Update()
        {
            fishWeight.text = $"{fish.Weight}";
            button1.text = $"X1";
            button2.text = $"X10";
            button3.text = $"100";
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

        public void setup(FishType fishType)
        {
            gameObject.name = fishType.name;
            fish = fishType;
            this.fishImage.texture = fishType.image;
        }
    }
}