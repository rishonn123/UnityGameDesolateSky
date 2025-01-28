using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : MonoBehaviour
{
  

    public Transform firePoint;
    public LineRenderer line; 
    public Animator animator;

    [SerializeField] private AudioSource laserSoundEffect;
    
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            laserSoundEffect.Play();
            StartCoroutine(Shoot());
            animator.SetFloat("Pew", 0.1f);

        }
    }

    IEnumerator Shoot(){
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        if(hitInfo){
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if(enemy != null){
                enemy.TakeDamage(20);
            }

            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, hitInfo.point);
        } else{
            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        line.enabled = true;

        yield return new WaitForSeconds(0.02f);

        line.enabled = false;
    }
}
