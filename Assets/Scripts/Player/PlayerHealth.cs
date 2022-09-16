using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private int health = 3;
    [SerializeField] private float invincibleTime = 1f;
    [SerializeField] private GameObject healthbar;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private Animator heartAnimator;
    private float invinc;
    private GameObject[] hearts; 

    private void Start()
    {
        invinc = invincibleTime;
        hearts = new GameObject[healthbar.transform.childCount];

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = healthbar.transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        invinc -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (transform.position.y > 265)
        {
            //Player Wins
            StartCoroutine(LoadWinScene());
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        takePlayerLife(col);
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        takePlayerLife(col);
    }

    private void takePlayerLife(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && (invinc <= 0))
        {
            health--;
            invinc = invincibleTime;
            heartAnimator = hearts[health].GetComponent<Animator>();
            heartAnimator.SetTrigger("Flatter");
            
            hearts[health].GetComponent<Image>().sprite = emptyHeart;

            if (health <= 0)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
    
    IEnumerator LoadWinScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(6); 
    }
}
