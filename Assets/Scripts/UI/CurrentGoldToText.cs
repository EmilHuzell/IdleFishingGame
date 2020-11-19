using UnityEngine;
using UnityEngine.UI;

public class CurrentGoldToText : MonoBehaviour
{
    private void Update() {
        this.GetComponent<Text>().text = $"{PrettifyText.Format(Gold.CurrentGold)}";
    }
}