using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public bool goUp;
    private void Update()
    {
        if (goUp == true)
        {
            transform.Rotate(0, 0.1f, 0);
            transform.Translate(0, 0.04f, 0.1f);
        }
        else
        {
            transform.Rotate(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            goUp = true;
        }
    }
}
