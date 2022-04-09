using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform bulletSpawnPoint;
    public Transform ShootPoint;
    public float bulletSpeed;
    private GameObject bullet;
    public GameObject gun;
    public bool fire;
    private bool notAssigned;
    public string gunTag;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(!notAssigned)
        {
            notAssigned = true;
            gun = GameObject.FindGameObjectWithTag(gunTag);

            bulletSpawnPoint = gun.transform.Find("BulletSpawn");
            ShootPoint = gun.transform.Find("ShootDirection");
        }
        if (!fire && GetComponent<EnemyPatrol>().InAttackMode)
        {
            fire = true;
            Shoot();
        }
    }
    private void Shoot()
    {
            
               

                bullet = Instantiate(playerBullet, bulletSpawnPoint.transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().velocity = (ShootPoint.position - bulletSpawnPoint.position).normalized * bulletSpeed;
                StartCoroutine(WaitBeforeShooting());

            
        
    }
    IEnumerator WaitBeforeShooting()
    {
        yield return new WaitForSeconds(0.6f);

        fire = false;

    }
}
