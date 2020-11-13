using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherPlacement : MonoBehaviour
{
    // Update is called once per frame
    
    void Update()
    {
        RectTransform CanvasRectTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
        RectTransform FisherManRectTransform = this.GetComponent<RectTransform>();

        var imageScale = 40;


        var leftPosition = new Vector3(-CanvasRectTransform.sizeDelta.x/2 + FisherManRectTransform.sizeDelta.x*imageScale/2,0,0);
        var rightPosition = new Vector3(CanvasRectTransform.sizeDelta.x/2 - FisherManRectTransform.sizeDelta.x*imageScale/2,0,0);
        

        if(Input.mousePosition.x <= CanvasRectTransform.sizeDelta.x/2){
            FisherManRectTransform.localPosition = rightPosition;
        }else{
            FisherManRectTransform.localPosition = leftPosition;
        }
    }
}
