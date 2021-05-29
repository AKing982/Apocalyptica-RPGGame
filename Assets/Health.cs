using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public  Animator playerAnim;

    public Slider slider;

    public void Start()
    {
        currentHealth = maxHealth;
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealth(int health)
    {
        slider.value = health;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "SA_Zombie_AirportWorker")
        {
            currentHealth -= 20;

            slider.value = currentHealth;
        }

        else if(collision.gameObject.name == "SA_Zombie_Businessman")
        {
            currentHealth -= 75;
            slider.value = currentHealth;
        }

        // If the player collides with a health pack 
        // boost the player's health by 25 points
        else if(collision.gameObject.name == "SA_Item_MedicBag")
        {
            currentHealth += 25;
            slider.value = currentHealth;
           
        }

        if(currentHealth <= 0)
        {
            playerAnim.Play("Death_01");
            currentHealth = 0;
        }
    }









}
