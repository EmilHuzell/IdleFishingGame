using UnityEngine;

namespace Fish
{
    public class FishMarketSetup : MonoBehaviour
    {
        public FishType[] fishes;

        public FishMarket prefab;

        private void Start()
        {
            foreach (var fish in fishes)
            {
                var newfish = Instantiate(prefab, transform);
                newfish.setup(fish);
            }
        }
        
    }
}