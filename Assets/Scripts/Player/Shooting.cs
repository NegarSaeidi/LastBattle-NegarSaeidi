using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject playerBullet;
    public GameObject bulletSpawnPoint;
    public GameObject ShootPoint;
    public int bulletSpeed;
   
    void Update()
    {

        

        if(Vector3.Magnitude(GetComponent<CharacterController>().velocity) == 0)
        {
            if (Input.GetMouseButton(0))
            {
                GetComponent<Animator>().SetBool("ShootingIdle", true);
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
            }
            else
            {
                GetComponent<Animator>().SetBool("ShootingInMove", false);
            }
        }
       

    }
}
