using UnityEngine;

namespace Fish
{
    public class ShowFishMarket : MonoBehaviour
    {
        public GameObject fishMarket;

        private void Start()
        {
            fishMarket.SetActive(false);
        }

        public void showFishMarket()
        {
            fishMarket.SetActive(!fishMarket.activeSelf);
        }
    }
}