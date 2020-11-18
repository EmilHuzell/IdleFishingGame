using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Vector2 center;

    public bool clockwise;
    public float radius;
    public float angle;
    public float speed;
    void Start()
    {
        Transform start = this.GetComponent<Transform>();
        this.center = new Vector2(start.localPosition.x,start.localPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        Transform WaveTransform = this.GetComponent<Transform>();

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

        WaveTransform.localPosition = new Vector3(x, y, WaveTransform.localPosition.z);

    }
    
}