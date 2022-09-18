using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreWinnerScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            int time = (int) PlayerPrefs.GetFloat("Highscore");
            score.SetText(time + " seconds");
        }
    }
}