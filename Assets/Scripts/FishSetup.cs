using UnityEngine;

    public class FishSetup : MonoBehaviour
    {
        public FishType[] Fishes;
        public FishUI prefab;

            private void Start()
            {
                foreach (var fish in Fishes)
                {
                    var newproduct = Instantiate(prefab, transform);
                    newproduct.setup(Fishes);
                }
            }
    }
