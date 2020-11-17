using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class CharCreation : MonoBehaviour {

    public InputField nameInput;

    public GameObject nameStage;
    public GameObject genderStage;

    public Object whatSceneToGoToWhenCharacterIsDone;

    private void Start() {
        genderStage.gameObject.SetActive(false);
    }

    public void SubmitName() {
        PlayerPrefs.SetString("Name", nameInput.text);
        Debug.Log(PlayerPrefs.GetString("Name"));
        nameStage.gameObject.SetActive(false);
        genderStage.gameObject.SetActive(true);
    }
    
    public void Male() {
        PlayerPrefs.SetString("Gender", "Male");
        SceneManager.LoadScene("MainScene");
    }

    public void Female() {
        PlayerPrefs.SetString("Gender", "Female");
        SceneManager.LoadScene("MainScene");
    }
}
