using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AddScene : MonoBehaviour
{
    public int sceneNumber;
    public void Awake()
    {
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Additive);
        Destroy(gameObject);
    }
}
