using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public List<GameObject> healthbars;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {

            if (healthbars.Count > 0)
            {
                Destroy(healthbars[healthbars.Count - 1]);
                GetComponent<Animator>().SetTrigger("TakeDamage");
                healthbars.RemoveAt(healthbars.Count - 1);


            }
           
            
        }
    }
    private void Update()
    {
        if (healthbars.Count <= 0)
        {
            
            GetComponent<Animator>().SetBool("Die", true);
        }
    }
}
