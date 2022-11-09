using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{

    [SerializeField] private float JumpHeight;
    [SerializeField] private CapsuleCollider mycol;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;

    Vector3 playerstartpos;
    Vector3 playerendpos = new Vector3(0, 0, 0);

    public float moveSpeed = 3;
    public float leftrightSpeed = 4;


    public bool isGrounded = false;
    public float distoground = 1f;


    private void Start()
    {

        FindObjectOfType<SoundEffect>().LevelMusic();
        playerstartpos = this.transform.position;
        mycol = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Coin")
        {

            Destroy(col.gameObject, 0.3f);
            CollectebleControl.coincount += 5;

        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("ground") && isGrounded == false)
        {
            isGrounded = true;
        }

    }
    void Update()
    {

        rb.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.A))
        {
            if (this.gameObject.transform.position.x > levelBoundary.leftSide)
            {
                rb.transform.Translate(Vector3.left * Time.deltaTime * leftrightSpeed);
            }

        }
        if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.D))
        {
            if (this.gameObject.transform.position.x < levelBoundary.rightSide)
            {
                rb.transform.Translate(Vector3.left * Time.deltaTime * leftrightSpeed * -1);
            }
        }


        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            animator.SetTrigger("jump");
            rb.transform.Translate(0, JumpHeight * Time.deltaTime, 0);
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("slide");
            transform.Translate(0, 0, 0);
            mycol.height = 1.08f;
            CancelInvoke("myCol");
        }




        if (transform.position.z != 0)
        {
            animator.SetBool("Run", true);

        }
        else
        {
            animator.SetBool("Run", false);

        }

    }
    void groundcheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distoground + 0.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void myCol()
    {
        mycol.height = 1.30f;
    }
    private void FixedUpdate()
    {

        Invoke("myCol", 1);
        groundcheck();
    }
}
