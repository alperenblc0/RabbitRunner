using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectebleControl : MonoBehaviour
{
    public static int coincount;
    public GameObject coinDisplay;

    private void Update()
    {
        coinDisplay.GetComponent<TextMeshProUGUI>().text = "" + coincount;
    }

}
