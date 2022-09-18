using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using Pathfinding;


public class Enemy_Life : MonoBehaviour
{
    [SerializeField] private float life = 2;
    [SerializeField] private Animator anim;

    public void takeLife(float dmg)
    {
        life -= dmg;

        if (life <= 0)
        {
            die();
        }
    }
    private void die()
    {
        anim.SetTrigger("death");
     
        foreach(Collider2D col in GetComponents<Collider2D>())
        {
            col.enabled = false;
        }
        Destroy(gameObject, 0.5f);
        if (TryGetComponent<Rigidbody2D>(out var exists))
        {
            GetComponent<Enemy_Movement>().enabled = false;
          
        }
        else
        {
            gameObject.GetComponent<AIPath>().canMove = false;
        }
        
    }

} 
