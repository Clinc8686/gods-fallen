using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI minusText;
    public float scoreAmount;
    public float pointIncrease;
    private float dauer = 0;
    private float dauerReset = 5f;
  
    void Start()
    {
        scoreAmount = 0f;
        pointIncrease = 1f;
    }

    void Update()
    {
        
        if (HIghscore.EnemyDeath() == true)
        {
            scoreAmount -= 2;
            minusText.text =  "HIT -2" ;
        }
        
        scoreText.text = "Time " + (int)scoreAmount;
        scoreAmount += pointIncrease * Time.deltaTime; 
        
        if(dauer > 0)
        {
            dauer -= Time.deltaTime;
        }
        
        if(dauer <= 0)
        {
            minusText.text = "";
            dauer = dauerReset;
        }
        
        SetHighscore();
    }

    private void SetHighscore()
    {
        PlayerPrefs.SetFloat("Highscore", scoreAmount);
    }


}
