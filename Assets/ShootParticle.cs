using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem pS;
    [SerializeField] private float damage = 1;

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy_Life>().takeLife(damage);
        }
    }
}
