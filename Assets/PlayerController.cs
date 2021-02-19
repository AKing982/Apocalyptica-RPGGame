using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public GameObject Player;
    public float speed = 12f;
    public float gravity = -9.81f;
    private Animator playerAnim;
    private float x_direction = Input.GetAxis("Horizontal");
    private float z_direction = Input.GetAxis("Vertical");
    
    Vector3 velocity;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
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
        Vector3 mouse_pos = new Vector3(Input.mousePosition.x, Input.mousePosition.z, 10);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mouse_pos);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.z, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
        Vector3 move = transform.right * x_direction + transform.forward * z_direction;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
