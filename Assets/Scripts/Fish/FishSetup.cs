using UnityEngine;

public class FishSetup : MonoBehaviour
{
    public FishType[] Fishes;
    public Tools[] Tools;

    //perhaps move to a player script in future
    public int currentTool;
    public FishPopup prefab;
    
    public void getFish()
    {
        var fish = Fishes[Random.Range(Tools[currentTool].sizeMin, Tools[currentTool].sizeMax)];
        var newFish = Instantiate(prefab, transform);
        newFish.transform.position = transform.position;
        var size = Random.Range(fish.sizeMin, fish.sizeMax);
        newFish.setup(fish, size);
        fish.Weight += newFish.size;
    }
}
