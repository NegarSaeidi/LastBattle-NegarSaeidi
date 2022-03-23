using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Pickup");
            GetComponent<Animator>().SetBool("Collected", true);
            StartCoroutine(causeDelay());

        }
    }
    IEnumerator causeDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
      
    }
}
