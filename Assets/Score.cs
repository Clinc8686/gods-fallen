using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;
    public float scoreAmount;
    public float pointIncrease;
    private int enemyAmount;
    private int counter;
    GameObject[] enemies;


    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
        pointIncrease = 1f;
         enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyAmount = enemies.Length;
        counter = enemyAmount;

    }

    // Update is called once per frame
    void Update()
    {
        enemyAmount = enemies.Length;
        if (enemyAmount < counter)
        {
            scoreAmount -= 2;
            counter--;
        } 
        scoreText.text = (int)scoreAmount + " Sec";
        scoreAmount += pointIncrease * Time.deltaTime;

    }

   
   
}
