using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GetPauseScene : MonoBehaviour
{
    [SerializeField] private GameObject pause;

    private void Start()
    {
        pause.SetActive(false);
    }

    private void OnPause(InputValue val)
    {
        Debug.Log("Pause");
        if (pause.activeSelf)
        {
            pause.SetActive(false);
        }
        else
        {
            pause.SetActive(true);
        }
    }
    
    public void disablePauseMenue()
    {
        pause.SetActive(false);
    }
}
