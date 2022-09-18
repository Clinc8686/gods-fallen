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
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Animator heartAnimator;
    
    private float invinc;
    private GameObject[] hearts;
    private ParticleSystem pSBleeding;
    private ParticleSystem pSHealing;

    private void Start()
    {
        invinc = invincibleTime;
        hearts = new GameObject[healthbar.transform.childCount];

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = healthbar.transform.GetChild(i).gameObject;
        }

        pSBleeding = transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
        pSHealing = transform.GetChild(0).GetChild(1).GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        invinc -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        changePlayerLife(col);
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        changePlayerLife(col);
    }

    private void changePlayerLife(Collision2D col)
    {
        
        if (col.gameObject.tag == "Enemy" || col.collider.tag == "Enemy")
        {
            transform.GetComponent<KnockbackBehaviour>().StartKnockback(col);

            if (invinc <= 0)
            {
                health--;
                invinc = invincibleTime;
                heartAnimator = hearts[health].GetComponent<Animator>();
                heartAnimator.SetTrigger("Flatter");

                pSBleeding.Play();
                if (health <= 0)
                {
                    SceneManager.LoadScene(3);
                }
            }
        }

        if (col.gameObject.tag == "Health")
        {
            if (health < 3)
            {
                heartAnimator = hearts[health].GetComponent<Animator>();
                heartAnimator.SetTrigger("Back");
                health++;
            }
            pSHealing.Play();
            Destroy(col.gameObject);
        }
    }

}
