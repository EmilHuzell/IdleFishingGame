using UnityEngine;

public class FishSetup : MonoBehaviour
{
    public FishType[] Fishes;
    public Tools[] Tools;

    //perhaps move to a player script in future
    public int currentTool;
    public FishUI prefab;
    
    public void getFish()
    {
        var fish = Fishes[Random.Range(Tools[this.currentTool].sizeMin, Tools[this.currentTool].sizeMax)];
        var newFish = Instantiate(prefab, transform);
        newFish.transform.position = transform.position;
        newFish.setup(fish);
    }
}
