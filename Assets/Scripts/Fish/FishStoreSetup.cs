using UnityEngine;

namespace Fish
{
    public class FishStoreSetup : MonoBehaviour
    {
        public FishType[] fishes;

        public FishStore prefab;

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