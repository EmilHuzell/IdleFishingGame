using UnityEngine;

namespace Fish
{
    public class ShowFishMarket : MonoBehaviour
    {
        public GameObject fishStoreUI;

        private void Start()
        {
            fishStoreUI.SetActive(false);
        }

        public void showFishMarket()
        {
            fishStoreUI.SetActive(!fishStoreUI.activeSelf);
        }
    }
}