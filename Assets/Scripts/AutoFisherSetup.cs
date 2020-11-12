using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFisherSetup : MonoBehaviour
{
    public List<AutoFisherType> autoFisherTypes = new List<AutoFisherType>();
    public AutoFisher autoFisherPrefab;

    private void Awake()
    {
        foreach (var autoFisher in autoFisherTypes)
        {
            AutoFisher newAutofisher = Instantiate(autoFisherPrefab);
            newAutofisher.transform.SetParent(transform);
            newAutofisher.Setup(autoFisher);
        }
    }
}
