using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class RespawnBalls : MonoBehaviour
{
    [SerializeField] private GameObject balls;
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        balls.GetComponent<AIDestinationSetter>().target = player;
        InvokeRepeating("Respawn", 6, 10);
    }
    
    private void Respawn()
    {
        Instantiate(balls, transform.position, Quaternion.identity);
    }
}
