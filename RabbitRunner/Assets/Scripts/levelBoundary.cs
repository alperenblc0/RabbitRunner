using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelBoundary : MonoBehaviour
{
    public static float leftSide=-1.5f;
    public static float rightSide=1.5f;
    public float internalLeft;
    public float internalRight;

    private void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}
