using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class BoatMovement : MonoBehaviour {
    
    public List<Sprite> boatImages;
    public float movementSpeed;
    public float bobAmount;
    public float bobSpeed;
    
    private float _x;
    private float _y;

    private void Awake() {
        var getRandomBoatSprite = boatImages[Random.Range(0, boatImages.Count())];
        this.GetComponent<Image>().sprite = getRandomBoatSprite;
    }

    private void FixedUpdate() {
        _x += 0.001f * movementSpeed;
        _y = Mathf.Lerp(-bobAmount * 0.2f, bobAmount * 0.2f, Mathf.PingPong(Time.time * bobSpeed * 0.4f, 1));
        
        transform.localPosition += new Vector3(_x, _y);
    }
}
