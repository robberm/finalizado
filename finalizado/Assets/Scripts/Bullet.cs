using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    public int bulletDamage = 20;

    void OnTriggerEnter2D(Collider2D collision)
    {
        
       
        EnemyProperties enemy = collision.GetComponent<EnemyProperties>();
            if (enemy != null) {
            enemy.TakeDamage(bulletDamage);
        }
           
        
        //IF enemy tag deal 10 health
        Destroy(gameObject);
    }
  
    }


