using UnityEngine;

public class Gold : MonoBehaviour
{
    public int CurrentGold => PlayerPrefs.GetInt("Gold");    
    
    public void AddGold(float goldToAdd) {
        PlayerPrefs.SetInt("Gold", CurrentGold + Mathf.RoundToInt(goldToAdd));
    }

    public bool RemoveGold(float goldToRemove) {
        if (goldToRemove >= 0f) {
            PlayerPrefs.SetInt("Gold", CurrentGold - Mathf.RoundToInt(goldToRemove));
            return true;
        }else return false;
    }
}
