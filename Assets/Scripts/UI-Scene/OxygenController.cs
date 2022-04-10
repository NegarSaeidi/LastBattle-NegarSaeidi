using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OxygenController : MonoBehaviour
{
    public GameObject[] OxygenBars;
    public static float time, totalTime;
    private int index ;
    public int alreadyChecked = 0;
   // public GameObject gameOverPanel;
    private void Start()
    {
        time = 360;
        totalTime = 360;
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

           
            SceneManager.LoadScene("GameOver");
            //  gameOverPanel.SetActive(true);
        }
      
    }
}
