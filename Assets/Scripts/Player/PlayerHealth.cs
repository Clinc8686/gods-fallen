using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private int health = 3;
    [SerializeField] private float invincibleTime = 1f;
    private float invinc;

    private void Start()
    {
        invinc = invincibleTime;
    }

    private void Update()
    {
        invinc -= Time.deltaTime;
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
            Debug.Log("Hit Enemy");
            health--;
            invinc = invincibleTime;

            if (health <= 0)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
