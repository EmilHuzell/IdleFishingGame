using UnityEngine;
using UnityEngine.UI;

public class FishUI : MonoBehaviour
{
    public Text type;
    public Text size;
    public RawImage rawImage;
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
        // Sprite sprite = Sprite.Create(fishType.image, new Rect(0, 0, fishType.image.width, fishType.image.height), new Vector2(fishType.image.width / 2, fishType.image.height / 2));
        this.rawImage.texture = fishType.image;
    }
}