using UnityEngine;

public class Gender : MonoBehaviour {
    public Sprite male, female;
    void Start()
    {
        if (PlayerPrefs.GetString("Gender") == "Male") {
            GetComponent<SpriteRenderer>().sprite = male;
        }
        else if (PlayerPrefs.GetString("Gender") == "Female") {
            GetComponent<SpriteRenderer>().sprite = female;
        }
    }
}
