using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenController : MonoBehaviour
{
    public GameObject[] OxygenBars;
    public float time;
    private int index ;
    public int alreadyChecked = 0;
   // public GameObject gameOverPanel;
    private void Start()
    {
        time = 360;
        index = OxygenBars.Length - 1;
    }
    void Update()
    {
        if (time > 1)
        {
            time -= Time.deltaTime;
            if (((int)time % 18) ==0 && (int)time !=alreadyChecked)
            {
                alreadyChecked = (int)time;
                Destroy(OxygenBars[index]);
                index--;
            }
            else
            {

                
            }
        }
        else
        {

          
            //  gameOverPanel.SetActive(true);
        }
      
    }
}
