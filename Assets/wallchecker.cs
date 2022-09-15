using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wallchecker : MonoBehaviour
{
    public Collider2D body;
    [SerializeField] float movementSpeed = 1f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();



    }
    void Update()
    {
        if (IsfacingRight())
        {

            rb.velocity = new Vector2(movementSpeed, 0f);
        }
        else
        {

            rb.velocity = new Vector2(-movementSpeed, 0f);
        }
    }
    private bool IsfacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Player")
        {
            transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
        }

    }
}
