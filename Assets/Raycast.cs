using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Transform startRay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(startRay.position, startRay.forward, out var hit,2f))
        {
            Debug.Log("HIT!");
        }
        else
        {
            Debug.Log("Nothing!");
        }
    }
}
