using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Camera cam;
    public Rigidbody2D rbplayer;



    public float bulletSpeed = 40f;
    public Transform firePoint;
    public float offset;
    




    //Rigidbody2D CircunferenciaRB = GameObject.Find("CircunfRot").GetComponent<Rigidbody2D>();

    // Purpose is to develop all characteristics of bullet here





    void Update()
    {
        Vector3 CircunferenciaTr = GameObject.Find("CircunfRot").transform.position;
        CircunferenciaTr = GameObject.Find("Player").transform.position;
        GameObject.Find("CircunfRot").transform.position = CircunferenciaTr;
        if (Time.timeScale != 0) { 
        ProjectileShoot();
        }


    }
    public void ProjectileShoot()
    {


        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        rbplayer = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        Vector2 shootDir = mousePos - rbplayer.position;

        // RECORDAR, QUIERES QUE CARGE UNA BALA CON UN SPRITE PERSONALIZADO Y QUE TENGA EFVECTO DE SONIDO, COOLDOWN
        float anguloZ = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
        GameObject.Find("CircunfRot").transform.rotation = Quaternion.Euler(0f, 0f, anguloZ + offset);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            {
                GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //Quaternion.Euler(new Vector3(0f, 0f, anguloZ))
                Rigidbody2D rbullet = Bullet.GetComponent<Rigidbody2D>();
                //rbullet.velocity = new Vector2(bulletSpeed * (shootDir.x / (shootDir.x + shootDir.y)), bulletSpeed * (shootDir.y / (shootDir.x + shootDir.y)));
                rbullet.AddForce(shootDir * bulletSpeed, ForceMode2D.Impulse);
               
            }







        }
    }
}
