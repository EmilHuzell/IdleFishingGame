using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscensionUI : MonoBehaviour
{
    void Update()
    {
    }
    public void Ascend() //For button
    {
        Ascension.Ascend();
        gameObject.SetActive(false);
    }
}
