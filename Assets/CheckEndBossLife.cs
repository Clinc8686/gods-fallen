using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CheckEndBossLife : MonoBehaviour
{
    [SerializeField] private GameObject endboss;
    private void FixedUpdate()
    {
        if (endboss == null)
        {
            SceneManager.LoadScene(6);
        }
    }
}
