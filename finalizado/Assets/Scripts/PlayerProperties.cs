using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public int playerHealth = 100;
    
    void Update()
    {
        if (playerHealth <= 0)
        {
            PlayerDeath();
        }
        void PlayerDeath()
        {

            Destroy(gameObject);

        }



       
    }
}
