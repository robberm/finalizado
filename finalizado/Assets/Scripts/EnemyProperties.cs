using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    public int bathealth = 20;
    public int damageDealt = 10;
    private Controller gameController;
    private double cooldownBatDamage = 0;
    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
    }
    public void TakeDamage(int damagetaken) {
        bathealth -= damagetaken;
        if (bathealth <= 0)
        {
            KillEnemy();
        }

        }
    void KillEnemy()
    {

        Destroy(gameObject);
        gameController.batDeaths++;

    }

        void OnCollisionEnter2D(Collision2D collision)
    {
        cooldownBatDamage += Time.deltaTime;
        
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerProperties>().playerHealth -= damageDealt;
            
        }
    }

}
