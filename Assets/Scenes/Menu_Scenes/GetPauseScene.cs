using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GetPauseScene : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    private bool isPaused = false;

    private void OnPause(InputValue val)
    {
        if (isPaused)
        {
            isPaused = false;
            pause.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            pause.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Continue()
    {
        isPaused = false;
        pause.SetActive(false);
        Time.timeScale = 1f;
    }
}
