using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 1f;

    private Vector3 target = new Vector3(-503, 0, -1);

    private GameObject player;

 
   
    // Get the player's position



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}
