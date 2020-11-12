using UnityEngine;
using UnityEngine.UI;

public class FishUI : MonoBehaviour
{
    public Text type;
    public Text size;
    private FishType fishType;
    private int fishSize;

    private void Update()
    {
        //
    }
    
    public void setup(FishType fishType)
    {
        this.fishType = fishType;
        gameObject.name = fishType.name;
        this.fishSize = Random.Range(fishType.sizeMin, fishType.sizeMax);
        this.type.text = $"I'm a {fishType.name}";
        this.size.text = $"{fishSize}";
    }
}