using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 30;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Bullet Fired");
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2d(Collider2D hitInfo){
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null){
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);

    }
}
