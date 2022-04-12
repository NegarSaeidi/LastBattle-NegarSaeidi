using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TakeDamage : MonoBehaviour
{
    public GameObject barParent,bar;
    public List<GameObject> healthbars;
    public static bool BoostHealth, addHealth;
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
        if(BoostHealth)
        {
            if (healthbars.Count != 31)
            {
                var barTemp = Instantiate(bar, barParent.transform);
                var barTemp2 = Instantiate(bar, barParent.transform);
                // 
                healthbars.Add(barTemp);
                healthbars.Add(barTemp2);
                BoostHealth = false;
            }
          
          
        }
        if(addHealth)
        {
            if (healthbars.Count != 31)
            {
                var barTemp = Instantiate(bar, barParent.transform);
                // 
                healthbars.Add(barTemp);
                addHealth = false;
            }
           
        }
        if (healthbars.Count <= 0)
        {
          
            GetComponent<Animator>().SetBool("Die", true);
            StartCoroutine(delayBeforeDeath());
        }
    }

    IEnumerator delayBeforeDeath()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("GameOver");
    }
}
