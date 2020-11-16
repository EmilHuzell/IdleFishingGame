using UnityEngine;

public class FishSetup : MonoBehaviour
{
    public FishType[] Fishes;
    public FishUI prefab;

    public string currentTool = "spear";
    
    public void getFish(string tool)
    {
        int maxSize;
        switch (tool)
        {
            case "spear":
                maxSize = 1;
                break;
            case "rod":
                maxSize = 2;
                break;
            default:
                maxSize = 0;
                break;
        }
        var fish = Fishes[Random.Range(0, maxSize)];
        var newFish = Instantiate(prefab, transform);
        newFish.transform.position = transform.position;
        newFish.setup(fish);
    }
}
