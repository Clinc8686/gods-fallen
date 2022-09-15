using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;
    public float scoreAmount;
    public float pointIncrease;
    private int x;


    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
        pointIncrease = 1f;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        x = enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //if()
        scoreText.text = (int)scoreAmount + " Sec";
        scoreAmount += pointIncrease * Time.deltaTime;

    }

   
   
}
