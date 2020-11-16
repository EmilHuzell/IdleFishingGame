using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsUI : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentTool = 0;

    

    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;   
    }
   

    // Update is called once per frame
    void Update()
    {
        //visible when holding tab, check!
        if (Input.GetKey(KeyCode.Tab))
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }else{
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        


        float x = Input.mousePosition.x - GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.x/2;
        float y = Input.mousePosition.y - GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.y/2;

        float fullCircle = Mathf.PI*2;

        var angle = Mathf.Atan2(y,x);

        if(angle < 0){
            angle = fullCircle + angle;
        }
        

        if(angle > 0 && angle < fullCircle/3){
            
            Debug.Log("spear");
        }
        if(angle > fullCircle/3 && angle < fullCircle*2/3){
            Debug.Log("rod");
        }
        if(angle > fullCircle*2/3 && angle < fullCircle){
            Debug.Log("net");
        }



    }
}
