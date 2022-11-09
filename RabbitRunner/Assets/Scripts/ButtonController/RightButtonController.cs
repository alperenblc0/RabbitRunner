using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class RightButtonController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    bool isPressed = false;
    public GameObject player;
    public float leftrightSpeed = 4;

    private void Update()
    {
        if (isPressed)
        {

            if (player.gameObject.transform.position.x < levelBoundary.rightSide)
            {
               player.transform.Translate(leftrightSpeed*Time.deltaTime,0,0);
            }

        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
