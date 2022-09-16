using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed && (countJump < 2))
        {
            //gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up* jumpHigh, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpHigh);
            countJump++;
            if (!jumpSource.isPlaying)
            {
                jumpSource.Play();
            }
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
            grounded = true;
            countJump = 0;
            bottomSource.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (grounded)
        {
            countJump = 1;
            grounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if ((other.collider.name == "Bottom" || other.collider.name == "PlayGround") && other.collider.IsTouching(bottomCollider.GetComponent<CapsuleCollider2D>()))
        {
            grounded = true;
            countJump = 0;
        } 
    }
}
