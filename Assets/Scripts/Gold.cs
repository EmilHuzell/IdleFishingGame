using System;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public static int CurrentGold => PlayerPrefs.GetInt("Gold");    
    
    public void AddGold(float goldToAdd) {
        PlayerPrefs.SetInt("Gold", CurrentGold + Mathf.RoundToInt(goldToAdd));
    }

    public bool RemoveGold(float goldToRemove) {
        if (goldToRemove >= 0f) {
            PlayerPrefs.SetInt("Gold", CurrentGold - Mathf.RoundToInt(goldToRemove));
            return true;
        }else return false;
    }
    // private void Update() {
    //     if (Input.GetKeyUp(KeyCode.Q)) {
    //         AddGold(10);
    //     }
    //
    //     if (Input.GetKeyUp(KeyCode.A)) {
    //         RemoveGold(1);
    //     }
    // }
}
