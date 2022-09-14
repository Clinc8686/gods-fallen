using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem pS;
    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

    private void OnParticleCollision(GameObject other)
    {
        
    }
}
