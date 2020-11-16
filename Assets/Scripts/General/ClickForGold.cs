using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ClickForGold : MonoBehaviour {
    public string goldToAddOnClick;
    public void Click() {
        Gold.AddGold(Converters.StringToBigInt(goldToAddOnClick));
    }
}