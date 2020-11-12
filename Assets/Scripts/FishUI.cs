using UnityEngine;

public class FishUI : MonoBehaviour
{
    private FishType fishType;

    private int fishSize;

    private void Update()
    {

    }
    
    public void setup(FishType fishType)
    {
        this.fishType = fishType;
        gameObject.name = fishType.name;
        this.fishSize = Random.Range(fishType.sizeMin, fishType.sizeMax);
    }
}