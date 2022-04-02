using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Shooting : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform bulletSpawnPoint;
    public Transform ShootPoint;
    public int bulletSpeed;
    private GameObject bullet;
    public bool fire;
    private int TotalBulletCount;
    private int RemainingBullets;
    public TextMeshProUGUI RemaingingAmmoText, TotalAmmoText;
    private void Start()
    {
        RemainingBullets = 10;
        TotalBulletCount = 10;
        GameObject gun = GameObject.FindGameObjectWithTag("Gun");
     
        bulletSpawnPoint = gun.transform.Find("BulletSpawn");
        ShootPoint = gun.transform.Find("ShootDirection");
        TotalAmmoText.text = TotalBulletCount.ToString();
    }
    void Update()
    {


        
        if(Vector3.Magnitude(GetComponent<CharacterController>().velocity) == 0)
        {
            if (Input.GetMouseButton(0))
            {
                GetComponent<Animator>().SetBool("ShootingIdle", true);
                Shoot();
               
            }
            else
            {
                GetComponent<Animator>().SetBool("ShootingIdle", false);
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                GetComponent<Animator>().SetBool("ShootingInMove", true);
                Shoot();
            }
            else
            {
                GetComponent<Animator>().SetBool("ShootingInMove", false);
            }
        }
       

    }

    private void Shoot()
    {
        if (!fire)
        {
            if (RemainingBullets < 1)
            {
                RemainingBullets = TotalBulletCount;
                fire = true;
              
                GetComponent<Animator>().SetTrigger("Reloading");
                StartCoroutine(Reloading());
            }
            else
            {
                RemainingBullets--;
                RemaingingAmmoText.text = RemainingBullets.ToString();
                bullet = Instantiate(playerBullet, bulletSpawnPoint.transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().velocity = (ShootPoint.position - bulletSpawnPoint.position).normalized * bulletSpeed;
               
            }
          
        }
    }
    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(1.5f);
        RemaingingAmmoText.text = RemainingBullets.ToString();
        fire = false;
        
    }
}
