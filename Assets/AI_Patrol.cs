using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Patrol : MonoBehaviour
{

    public float walkspeed;
    public Rigidbody2D rb;
    public Transform groundCheckPos;


    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;
    public LayerMask Obstacle;

    
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

     void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, Obstacle); 
        }
    }
    void Patrol()
{
        if (mustTurn)
        {
            flip();
        }

        rb.velocity = new Vector2(walkspeed * Time.fixedDeltaTime, rb.velocity.y);
}

    void flip()
    {
       
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkspeed *= -1;
        mustPatrol = true;
    }
}