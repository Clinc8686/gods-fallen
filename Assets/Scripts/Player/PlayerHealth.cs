using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
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

    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackTime;
    private float invinc;
    private GameObject[] hearts;
    private ParticleSystem pSBleeding;

    private void Start()
    {
        invinc = invincibleTime;
        hearts = new GameObject[healthbar.transform.childCount];

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = healthbar.transform.GetChild(i).gameObject;
        }

        pSBleeding = transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
        Debug.Log(pSBleeding + " " + transform.GetChild(0).GetChild(0));
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
        if (col.gameObject.tag == "Enemy")
        {
            Knockback(col);

            if (invinc <= 0)
            {
                health--;
                invinc = invincibleTime;
                heartAnimator = hearts[health].GetComponent<Animator>();
                heartAnimator.SetTrigger("Flatter");
                hearts[health].GetComponent<Image>().sprite = emptyHeart;

                pSBleeding.Play();
                if (health <= 0)
                {
                    SceneManager.LoadScene(3);
                }
            }
        }
    }
    
    IEnumerator LoadWinScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(6); 
    }

    private void Knockback(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Vector2 dif = (transform.position - col.transform.position).normalized;
            Vector2 dir = new Vector2(dif.x, dif.y + 1f);
            transform.GetComponent<Rigidbody2D>().AddForce(dir * knockbackForce, ForceMode2D.Impulse);
            StartCoroutine(UnKnockback());
        }
    }

    private IEnumerator UnKnockback()
    {
        yield return new WaitForSeconds(knockbackTime);
        transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        
    }
}
