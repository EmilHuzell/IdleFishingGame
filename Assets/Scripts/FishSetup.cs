using UnityEngine;

public class FishSetup : MonoBehaviour
{
    public FishType[] Fishes;
    public FishUI prefab;

    public void getFish()
    {
        var fish = Fishes[Random.Range(0, Fishes.Length)];
        var newFish = Instantiate(prefab, transform);
        newFish.transform.position = transform.position;
        newFish.setup(fish);
    }
}
