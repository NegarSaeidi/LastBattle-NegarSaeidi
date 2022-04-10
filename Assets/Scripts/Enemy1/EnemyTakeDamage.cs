using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    public int health;
    public GameObject Elixir;
    private bool ELixirGenerated;
    private void Start()
    {
        health = 20;
    }
    private void OnTriggerEnter(Collider other)
    {
      
        if(other.gameObject.tag=="PlayerBullet")
        {
            print("damage");
            if (health > 0)
                health--;
            else
            {
                GetComponent<Animator>().SetBool("Death", true);
                StartCoroutine(delayBeforeDeath( other));
            }
        }
    }

    IEnumerator delayBeforeDeath(Collider other)
    {
        yield return new WaitForSeconds(4.0f);
        Vector3 EnemyPosition = gameObject.transform.position;
        EnemyPosition.y += 0.5f;
        Destroy(gameObject);
        if (!ELixirGenerated)
        {
            ELixirGenerated = true;
            var pickup = Instantiate(Elixir, EnemyPosition, Quaternion.identity);
           

        }
    }
}
