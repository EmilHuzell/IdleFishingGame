using UnityEngine;
using UnityEngine.SceneManagement;

public class CharCreation : MonoBehaviour {
    
    public void Male() {
        PlayerPrefs.SetString("Gender", "Male");
        SceneManager.LoadScene("MainScene");
    }

    public void Female() {
        PlayerPrefs.SetString("Gender", "Female");
        SceneManager.LoadScene("MainScene");
    }
}
