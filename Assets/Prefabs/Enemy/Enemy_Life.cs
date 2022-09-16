using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Enemy_Life : MonoBehaviour
{
    [SerializeField] private float life = 2;

    public void takeLife(float dmg)
    {
        life -= dmg;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
