using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject player;
    public Vector2[] spawnPoints;
    private int contador = 0;   
    public int batDeaths = 0;
    
    void Start()
    {
        InvokeRepeating("spawnDeezNuts", 0.1f, 2f);
        player = GameObject.FindGameObjectWithTag("Player");
;    }

    // Update is called once per frame
    void Update()
    { 
        if (batDeaths == 10 || player == null)
        {
            gameReset();
        }
    }


    private void spawnDeezNuts()
    {
       
     GameObject spawn = Instantiate(enemyPrefab, spawnPoints[contador], Quaternion.identity);
        contador++;

        if (contador == spawnPoints.Length) {
            contador = 0;
        }
      }

   private void gameReset()
    {
        
        SceneManager.LoadScene(0);
       
    }
  

    }

    


