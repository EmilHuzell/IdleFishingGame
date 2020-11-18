using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BoatMovement : MonoBehaviour {
    
    public List<Sprite> boatImages;
    public bool shouldTilt;
    public float rotationAmount;
    public float movementSpeed;
    public float bobAmount;
    public float bobSpeed;

    private void Awake() {
        //Random start tilt doesn't work
        // if (shouldTilt) {
        //     var getRandomRot = Random.Range(-10, 10);
        //     transform.localRotation = new Quaternion(0, 0, getRandomRot, 2);
        // }
        
        var getRandomBoatSprite = boatImages[Random.Range(0, boatImages.Count())];
        GetComponent<Image>().sprite = getRandomBoatSprite;
    }

    private void Start() {
        transform.localPosition = new Vector3(-Screen.width, transform.localPosition.y);
    }

    private void FixedUpdate() {
        Rotate(shouldTilt);
        Move();
    }
    
    private void Move() {
        var _y = Mathf.Lerp(-bobAmount * 0.2f, bobAmount * 0.2f, Mathf.PingPong(Time.time * bobSpeed * 0.4f, 1));
        transform.localPosition += new Vector3(movementSpeed, _y);
        
        if (!IsVisible()) {
            DestroyImmediate(gameObject);
        }
    }

    private void Rotate(bool b) {
        if (!b) return;
        var rot = Mathf.Lerp(-rotationAmount * 0.2f, rotationAmount * 0.2f, Mathf.PingPong(Time.time * bobSpeed * 0.4f, 1));
        transform.localRotation = new Quaternion(0, 0, rot, 2);
    }

    private bool IsVisible() {
        return !(transform.localPosition.x > Screen.width);
    }
}
