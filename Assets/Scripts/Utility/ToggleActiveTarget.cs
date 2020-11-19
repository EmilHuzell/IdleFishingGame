using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActiveTarget : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject[] reverseTargets;

    public void Toggle(int targetIndex)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targetIndex != i)
            {
                targets[i].SetActive(false);
            }
            else
            {
                targets[i].SetActive(!targets[i].activeSelf);
            }
        }
        for (int i = 0; i < reverseTargets.Length; i++)
        {
            reverseTargets[i].SetActive(!targets[i].activeSelf);
        }
    }
}
