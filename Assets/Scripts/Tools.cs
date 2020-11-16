using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Tools : ScriptableObject {
    public int sizeMin = 5;
    public int sizeMax = 10;
    public bool unlocked = false;
    public Texture image;
}

