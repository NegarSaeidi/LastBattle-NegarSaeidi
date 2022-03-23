using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoBullet : MonoBehaviour
{
    private bool collided;
   
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag =="Enemy" && other.gameObject.tag=="Bullet" && !collided)
        {
            collided = true;
           Destroy(gameObject);
        }
    }
}
