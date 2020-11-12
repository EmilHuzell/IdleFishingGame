using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentGoldToText : MonoBehaviour
{
    private void Update() {
        this.GetComponent<Text>().text = $"Gold: {Gold.CurrentGold}";
    }
}
