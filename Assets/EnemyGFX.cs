using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.LowLevel;
using UnityEngine;
using Random = UnityEngine.Random;



public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    [SerializeField] private AudioSource enemySource;

    private void Start()
    { 
        PlayLoop();
    }

    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f) {
            transform.localScale = new Vector3(1f,1f,1f);
        }
    }

    void PlayLoop()
    {
        int r = Random.Range(15, 100);
        //StartCoroutine(WaitSeconds(r));
    }

    /*IEnumerator WaitSeconds(int r)
    {
        while (true)
        {
            enemySource.Play();
            yield return new WaitForSeconds(r);
        }
    }*/
}

