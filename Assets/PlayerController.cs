using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public CharacterController controller;
    public GameObject Player;
    public float speed = 3f;
    public float gravity = -9.81f;
    private Animator playerAnim;
    Rigidbody playerRb;
    public Camera cam;
    
    Vector3 velocity;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        PlayerAnimations();

        MouseMovement();
    }

    void MouseMovement()
    {
        Vector3 mous_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.LookAt(mous_pos);
    }    

   void PlayerAnimations()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
        {
            playerAnim.Play("Walk_Static");
        }

        // If the Shift key and W key are pressed simultaneously make the player walk fast
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            playerAnim.Play("Walk_Static");
            playerAnim.speed = 2;
        }
    }

    void PlayerMovement()
    {
        float x_direction = Input.GetAxis("Horizontal");
        float z_direction = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            playerRb.AddForce(new Vector3(-2f, 0.0f, 0.0f), ForceMode.VelocityChange);
        }

        if(Input.GetKey(KeyCode.A))
        {
            playerRb.AddForce(new Vector3(0.0f, 0.0f, -2f), ForceMode.VelocityChange); 
        }

        if(Input.GetKey(KeyCode.D))
        {
            playerRb.AddForce(new Vector3(0.0f, 0.0f, 2f), ForceMode.VelocityChange);
        }

        if(Input.GetKey(KeyCode.S))
        {
            playerRb.AddForce(new Vector3(2f, 0.0f, 0.0f), ForceMode.VelocityChange);
        }

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            playerRb.AddForce(new Vector3(-2f, 0.0f, 0.0f) * speed, ForceMode.VelocityChange);
        }

        Vector3 movement = new Vector3(x_direction, 0.0f, z_direction);

        playerRb.AddForce(movement * speed * Time.deltaTime);

   
}
}
