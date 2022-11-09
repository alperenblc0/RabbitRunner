using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UpButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   

    bool isPressed = false;
    public GameObject player;
 
    [SerializeField] private float JumpHeight;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    public bool isGrounded=false;
    public float distoground = 1f;

    private void FixedUpdate()
    {
        groundcheck();
    }
    private void Update()
    {
        if (isPressed && isGrounded)
        {

            animator.SetTrigger("jump");
            player.transform.Translate(0,JumpHeight*Time.deltaTime,0);
            
        }
        
    }
    void groundcheck()
    {
        if (Physics.Raycast(player.transform.position, Vector3.down, distoground + 0.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
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
