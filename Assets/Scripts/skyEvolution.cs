
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyEvolution : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector4 nightColor;
    public Vector4 dayColor;
    public Vector4 morningColor;

    public float dayStart;
    public float nightStart;

    public float timeInDay;

    private Vector4 currentColor;
    private float currentTime = 0;
    
     
    void Start()
    {
       
        //this.difference = this.dayColor - this.nightColor;
    }

    // Update is called once per frame
    void Update()
    {
        this.currentTime += Time.deltaTime;

        //morning to day
        if(this.currentTime < this.timeInDay*this.dayStart){
            //calculate point between 
            Debug.Log(this.currentTime/this.timeInDay/this.dayStart);

            this.currentColor = Vector4.Lerp(this.morningColor,this.dayColor,this.currentTime/this.timeInDay/this.dayStart);
        }else if(this.currentTime < this.timeInDay*this.nightStart){
            this.currentColor = Vector4.Lerp(this.dayColor,this.nightColor,(this.currentTime/this.timeInDay-this.dayStart)/(this.nightStart-this.dayStart));
        }else if(this.currentTime < this.timeInDay){
            this.currentColor = Vector4.Lerp(this.nightColor,this.morningColor,(this.currentTime/this.timeInDay-this.nightStart)/(1-this.nightStart));
        }else{

            this.currentTime = 0;
        }
        
        //this.currentColor += Time.deltaTime*this.difference/1000;
        gameObject.GetComponent<Camera>().backgroundColor = this.currentColor;
        Debug.Log(this.currentTime);
        
    }
}
