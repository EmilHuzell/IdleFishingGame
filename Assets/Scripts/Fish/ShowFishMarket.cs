using UnityEngine;

namespace Fish
{
    public class ShowFishMarket : MonoBehaviour
    {
        public GameObject fishStoreUI;

        private void Start()
        {
            fishStoreUI.active = false;
        }

        public void showFishMarket()
        {
            fishStoreUI.active = !fishStoreUI.active;
        }
    }
}