using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float life = 2;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            Destroy(col.gameObject);
            if (this.life <= 1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                life -= 1;
            }
        }
    }
}
