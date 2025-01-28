using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
   public int health = 100;
   //public GameObject deathEffect;

   public void TakeDamage(int damage){
        health -= damage;
        //Debug.Log("Health = " + health + " , Damage = " + damage);
        
        if(health <= 0){
            Die();
        }
   }

    void Die(){
        ScoreScript.scoreValue +=10;
        //Instantiate(deathEffect , transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

}
