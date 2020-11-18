using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyEvolution : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector4 nightColor;
    public Vector4 dayColor;
    private Vector4 difference;

    private Vector4 currentColor;
    
     
    void Start()
    {
        this.currentColor = this.nightColor;
        this.difference = this.dayColor - this.nightColor;
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.GetComponent<Camera>().backgroundColor = this.currentColor;
        this.currentColor += Time.deltaTime*this.difference/1000;
        Debug.Log(gameObject.GetComponent<Camera>().backgroundColor);
        
    }
}
