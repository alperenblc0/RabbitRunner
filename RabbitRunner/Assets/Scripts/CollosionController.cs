using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollosionController : MonoBehaviour
{

    public GameObject patlama;
    public PlayerController movement;
    public Animator anim;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            
             Debug.Log("GAME OVER");

             FindObjectOfType<SoundEffect>().DeathSound();
             movement.enabled = false;
             anim.SetBool("Run", false);
             anim.SetTrigger("collision");
             Instantiate(patlama, this.gameObject.transform.position, this.gameObject.transform.rotation);
        
        }

    }
}
