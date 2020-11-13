using UnityEngine;
using UnityEngine.UI;

public class FishUI : MonoBehaviour
{
    public Text type;
    public Text size;
    public RawImage rawImage;
    private int fishSize;
    public Vector3 moveDirection = Vector3.up * 20f;
    public float alphaFadeSpeed = 0.2f;
    public float variation = 20f;
    
    private void Start()
    {
        variation = Random.Range(-variation, variation);
        transform.position += new Vector3(Random.Range(-variation, variation), 0f, 0f);
        moveDirection.x += variation;
    }
    
    private void Update()
    {
        transform.position += moveDirection * Time.deltaTime;
        var color_Image = rawImage.color;
        var color_Text = type.color;
        color_Image.a -= alphaFadeSpeed * Time.deltaTime;
        color_Text.a -= alphaFadeSpeed * Time.deltaTime;
        rawImage.color = color_Image;
        type.color = color_Text;
        size.color = color_Text;
        if (color_Image.a < 0f) Destroy(gameObject);
    }
    public void setup(FishType fishType)
    {
        gameObject.name = fishType.name;
        this.fishSize = Random.Range(fishType.sizeMin, fishType.sizeMax);
        this.type.text = $"{fishType.name}";
        this.size.text = $"{fishSize}";
        this.rawImage.texture = fishType.image;
    }
}