using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthbar;
    private float currenthealth;
    private float maxhealth = 100f;
    PlayerProperties Player;

     void Start()
    {
        healthbar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerProperties>();
    }

     void Update()
    {
        currenthealth = Player.playerHealth;
        healthbar.fillAmount = currenthealth / maxhealth;   
    }
}