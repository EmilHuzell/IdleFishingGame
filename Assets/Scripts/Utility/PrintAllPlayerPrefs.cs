using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;

[EditorTool("Log all playerprefs")]
class PrintAllPlayerPrefs : EditorTool
{
    public override void OnToolGUI(EditorWindow window) {
        
        Debug.Log($"Current name: {PlayerPrefs.GetString("Name")}");
        Debug.Log($"Current gender: {PlayerPrefs.GetString("Gender")}");
        Debug.Log($"Current gold: {PlayerPrefs.GetString("Gold")}");
        Debug.Log($"Current fisherkidamount: {PlayerPrefs.GetString("FisherKid_Amount")}");
        Debug.Log($"Current fisherkidcost: {PlayerPrefs.GetString("FisherKid_Cost")}");
        Debug.Log($"Current savedtime: {PlayerPrefs.GetString("savedTime")}");
        
        DestroyImmediate(this);
    }
}