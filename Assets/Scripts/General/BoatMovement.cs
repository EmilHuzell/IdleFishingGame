using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoatMovement : MonoBehaviour {
    
    public List<Sprite> boatImages;
    public float rotationAmount;
    public float movementSpeed;
    public float bobAmount;
    public float bobSpeed;

    private void Awake() {
        var getRandomBoatSprite = boatImages[Random.Range(0, boatImages.Count())];
        GetComponent<SpriteRenderer>().sprite = getRandomBoatSprite;

        movementSpeed *= 0.01f;
        bobAmount *= 0.01f;
    }

    private void FixedUpdate() {
        Rotate(true);
        Move();
    }
    
    private void Move() {
        var _y = Mathf.Lerp(-bobAmount * 0.1f, bobAmount * 0.1f, Mathf.PingPong(Time.time * bobSpeed * 0.1f, 1));
        transform.localPosition += new Vector3(movementSpeed, _y);
        
        if (!IsVisible()) {
            DestroyImmediate(gameObject);
        }
    }

    private void Rotate(bool b) {
        if (!b) return;
        var rot = Mathf.Lerp(-rotationAmount * 0.2f, rotationAmount * 0.2f, Mathf.PingPong(Time.time * bobSpeed * 0.1f, 1));
        transform.localRotation = new Quaternion(0, 0, rot, 2);
    }

    private bool IsVisible() {
        return !(transform.localPosition.x > Camera.main.rect.width + 15);
    }
}
