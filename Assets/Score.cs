using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;
    public float scoreAmount;
    public float pointIncrease;
  
    private int counter;


    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
        pointIncrease = 1f;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int enemyAmount = enemies.Length;
        counter = enemyAmount;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("alt" + counter);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int enemyAmount = enemies.Length;
        if (enemyAmount < counter && GameManager.isBeginning == false)
        {
            
            scoreAmount -= 1;
            counter--;
            Debug.Log("neu" + counter);
        } 
        scoreText.text = (int)scoreAmount-1 + " Sec";
        scoreAmount += pointIncrease * Time.deltaTime;

    }

   
   
}
