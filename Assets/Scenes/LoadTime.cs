using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LoadTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    private float time;
    private float pointIncrease = 1f;
    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            time = PlayerPrefs.GetFloat("Highscore");
        }
    }

    private void Update()
    {
        score.text = "Time " + (int)time;
        time += pointIncrease * Time.deltaTime; 
        SetHighscore();
    }

    private void SetHighscore()
    {
        PlayerPrefs.SetFloat("Highscore", time);
    }
}
