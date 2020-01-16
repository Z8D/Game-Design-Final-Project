using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    bool paused = false;

    void Update()
    {

    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelOneLoad()
    {
        SceneManager.LoadScene("LevelOne");
        
    }

    public void LevelTwoLoad()
    {
        SceneManager.LoadScene("LevelTwo");
         
    }

    public void LevelThreeLoad()
    {
        SceneManager.LoadScene("LevelThree");
        
    }
    public void Description()
    {
        SceneManager.LoadScene("Description");
    }


    public void pause()
    {
        if (paused == false)
        {
            Time.timeScale = 0;
            paused = true;
        }
        else 
        {

            Time.timeScale = 1;
            paused = false;
        }
    }
}
