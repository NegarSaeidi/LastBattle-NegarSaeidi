using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoBullet : MonoBehaviour
{
    private bool collided;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Enemy" && other.gameObject.tag=="Bullet" && !collided)
        {
            collided = true;
           Destroy(gameObject);
        }
    }
}
