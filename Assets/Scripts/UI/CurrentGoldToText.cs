using UnityEngine;
using UnityEngine.UI;

public class CurrentGoldToText : MonoBehaviour
{
    private void Update() {
        this.GetComponent<Text>().text = $"Gold: {PrettifyText.Format(Gold.CurrentGold)}";
    }
}