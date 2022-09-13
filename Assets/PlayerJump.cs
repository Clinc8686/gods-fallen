using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpHigh = 2;
    private bool grounded = false;
    private int countJump = 0;
    
    private void OnJump(InputValue value)
    {
        if (value.isPressed && grounded && (countJump < 2))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up* jumpHigh, ForceMode2D.Impulse);
            countJump++;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        grounded = true;
        countJump = 0;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (grounded && countJump > 1)
        {
            grounded = false;
        }
    }
}
