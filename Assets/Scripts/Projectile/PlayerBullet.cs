using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private bool collided;
    private void Start()
    {
        StartCoroutine(causeDelay());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!collided)
        {
            collided = true;
            Destroy(gameObject);
        }
    }
   IEnumerator causeDelay()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
