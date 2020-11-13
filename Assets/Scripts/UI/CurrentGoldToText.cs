using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CurrentGoldToText : MonoBehaviour
{
    private void Update() {
        this.GetComponent<Text>().text = $"Gold: {PrettifyText.Format(Gold.CurrentGold)}";
        if (SceneManager.GetActiveScene().name == "MScene") {
            Debug.Log(Gold.CurrentGold.ToString());
        }
    }

    // private string PrettifyCurrentGold() {
    //     var currentGoldString = Converters.BigIntToString(Gold.CurrentGold);
    //     var suffix = "";
    //     var endString = "";
    //
    //     if (currentGoldString.Length < 4) {
    //         endString = currentGoldString;
    //     }
    //     
    //     if (currentGoldString.Length == 4) {
    //         string b = Converters.BigIntToString(Converters.TakeAmountOfNumbers(Gold.CurrentGold, 2));
    //         suffix = "K";
    //         endString = b[0] + "." + b[1] + suffix;
    //     }
    //
    //     if (currentGoldString.Length == 5) {
    //         string b = Converters.BigIntToString(Converters.TakeAmountOfNumbers(Gold.CurrentGold, 2));
    //         suffix = "K";
    //         endString = b + suffix;
    //     }
    //     
    //     if (currentGoldString.Length == 6) {
    //         string b = Converters.BigIntToString(Converters.TakeAmountOfNumbers(Gold.CurrentGold, 3));
    //         suffix = "K";
    //         endString = b + suffix;
    //     }
    //     
    //     if (currentGoldString.Length == 7) {
    //         string b = Converters.BigIntToString(Converters.TakeAmountOfNumbers(Gold.CurrentGold, 2));
    //         suffix = "M";
    //         endString = b[0] + "." + b[1] + suffix;
    //     }
    //     
    //     if (currentGoldString.Length == 8) {
    //         string b = Converters.BigIntToString(Converters.TakeAmountOfNumbers(Gold.CurrentGold, 2));
    //         suffix = "M";
    //         endString = b + suffix;
    //     }
    //
    //     return endString;
    // }
}
