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
        this.center = new Vector2(transform.localPosition.x, transform.localPosition.y);
    }

    void Update()
    {
        //update angle
        if(clockwise == true){
            this.angle -= this.speed;
        }else{
            this.angle += this.speed;
        }
        
        if(this.angle > Mathf.PI*2 || this.angle < -Mathf.PI*2){
            this.angle = 0;
        }

        //update calculate new localPositio
        var x = Mathf.Cos(this.angle) * this.radius + this.center.x;
        var y = Mathf.Sin(this.angle) * this.radius + this.center.y;

        transform.localPosition = new Vector3(x, y, transform.localPosition.z);

    }
    
}