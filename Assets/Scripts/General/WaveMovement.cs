using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    
    private Vector2 center;

    public bool clockwise;
    public float radius;
    public float angle;
    public float speed;
    void Start()
    {
        this.center = new Vector3(transform.localPosition.x, transform.localPosition.y);
    }

    void FixedUpdate()
    {
        //update angle
        if (clockwise == true)
        {
            this.angle -= this.speed;
        }
        else
        {
            this.angle += this.speed;
        }

        if (this.angle > Mathf.PI * 2 || this.angle < -Mathf.PI * 2)
        {
            this.angle = 0;
        }

        //update calculate new localPosition
        var x = Mathf.Cos(this.angle) * this.radius + this.center.x;
        var y = Mathf.Sin(this.angle) * this.radius + this.center.y;

        transform.localPosition = new Vector3(x, y, transform.localPosition.z);
    }
}