using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

namespace Fish
{
    public class FishStore : MonoBehaviour, IAscend
    {
        private FishType fish;
        public RawImage fishImage;
        public Text fishWeight;
      
        private void Update()
        {
            fishWeight.text = PrettifyText.Format(fish.Weight);
        }

        public void Ascend()
        {
            if(fish != null)
                fish.Reset();
        }

        public void setup(FishType fishType)
        {
            gameObject.name = fishType.name;
            fish = fishType;
            fishImage.texture = fishType.image;
        }
    }
}