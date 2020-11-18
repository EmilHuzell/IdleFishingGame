using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscensionUIHideShow : MonoBehaviour
{
    public GameObject target;
    void Update()
    {
        if (Ascension.Requirement < Gold.CurrentGold)
        {
            target.SetActive(true);
        }
    }
}
