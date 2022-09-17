using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private GameObject bottomCollider;
    [SerializeField] private float jumpHigh = 2;
    [SerializeField] private float fallGravity = 2;
    private bool grounded = false;
    private int countJump = 0;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource jumpSource;
    [SerializeField] private AudioSource bottomSource;

    private ParticleSystem pSDust;
    private ParticleSystem pSjumpDust;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pSDust = GameObject.Find("movingDust").GetComponent<ParticleSystem>();
        pSjumpDust = GameObject.Find("jumpDust").GetComponent<ParticleSystem>();
    }

    private void OnJump(InputValue value)
    {
        pSDust.Play();
        
        if (grounded)
        {
            grounded = false;
        }

        if (value.isPressed && (countJump < 2))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHigh);
            countJump++;
            pSjumpDust.Play();

            if (!jumpSource.isPlaying)
            {
                jumpSource.Play();
            }
        }
        else
        {
            pSjumpDust.Stop();
        }
    }

    void Update()
    {
        if (rb.velocity.y < 0f)
        {
            rb.velocity -= new Vector2(0f, -Physics2D.gravity.y) * (Time.deltaTime * fallGravity);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.collider.name == "Bottom" || other.collider.name == "PlayGround") &&
            other.collider.IsTouching(bottomCollider.GetComponent<CapsuleCollider2D>()))
        {
            ResetJumpCounter();
            bottomSource.Play();
        }
    }

    /*private void OnCollisionExit2D(Collision2D other)
    {
        if (grounded)
        {
            countJump = 1;
            grounded = false;
        }
    }*/

    private void OnCollisionStay2D(Collision2D other)
    {
        if ((other.collider.name == "Bottom" || other.collider.name == "PlayGround") && other.collider.IsTouching(bottomCollider.GetComponent<CapsuleCollider2D>()))
        {
            ResetJumpCounter();
        }
    }

    private void ResetJumpCounter() 
    {
        grounded = true;
        countJump = 0;
    }
}
