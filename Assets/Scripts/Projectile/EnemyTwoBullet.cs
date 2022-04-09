using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoBullet : MonoBehaviour
{
    private bool collided;

    private void Start()
    {
        StartCoroutine(delayBeforeDeath());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Enemy" && other.gameObject.tag=="Bullet" && !collided)
        {
            collided = true;
            Destroy(gameObject);
        }
    }
    IEnumerator delayBeforeDeath()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
