using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public void OnStartClicked()
    {
        SceneManager.LoadScene("GameWorld");
    }
    public void OnCreditsClicked()
    {
        SceneManager.LoadScene("Credits");
    }
    public void OnStoryClicked()
    {
        SceneManager.LoadScene("Story");
    }
    public void OnHomeClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnOptionsClicked()
    {
        SceneManager.LoadScene("Options");
    }
    public void OnScoresClicked()
    {
        SceneManager.LoadScene("Scores");
    }
    public void OnExitClicked()
    {
        Application.Quit();
    }

}
