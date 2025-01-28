using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;

    public int maxHealth = 100;
    public int currentHealth;

    public GameObject GameOver, Restart;

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        GameOver.SetActive(false);
        Restart.SetActive(false);
    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.UpArrow)){
            TakeDamage(20);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)){
            AddHealth(20);
        }

    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void AddHealth(int health){
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
    }


    
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("Enemy")){
            TakeDamage(2);
        }

        if(currentHealth <= 0){
            GameOver.SetActive(true);
            Restart.SetActive(true);
            gameObject.SetActive(false); 
        }

    }

            //GameOver.SetActive(true);
            // Restart.SetActive(true);
            // gameObject.SetActive(false);
 
}
