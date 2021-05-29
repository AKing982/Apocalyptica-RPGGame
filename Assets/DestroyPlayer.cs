using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    public Animator playerAnim;


    private void Start()
    {
        playerAnim = GetComponent<Animator>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "SA_Zombie_AirportWorker")
        {
            playerAnim.Play("Death_01");
        }

        

    }
}
