using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateMenu : MonoBehaviour
{
    public void SwitchScene(String sceneName)
    {
        if (sceneName.Equals("Exit"))
        {
            Application.Quit();
        }
        else
        {
           SceneManager.LoadScene(sceneName); 
        }
    }
}
