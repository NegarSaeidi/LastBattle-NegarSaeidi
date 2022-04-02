using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private bool collided;
    private void OnTriggerEnter(Collider other)
    {
        if (!collided)
        {
            collided = true;
            Destroy(gameObject);
        }
    }
}
