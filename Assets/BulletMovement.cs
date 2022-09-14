using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    //[SerializeField] private Transform spawnPlace;
    void Update()
    {
        transform.position += new Vector3(1, 0, 0) * (moveSpeed * Time.deltaTime);
    }
}
