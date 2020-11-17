﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class FishType : ScriptableObject {
    public int sizeMin = 5;
    public int sizeMax = 10;
    public float goldMultifier = 2;
    public Texture image;
    
    public int Weight
    {
        get => PlayerPrefs.GetInt($"{name}", 0);
        set => PlayerPrefs.SetInt($"{name}", value);
    }
}

