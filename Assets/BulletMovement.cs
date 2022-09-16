using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    //[SerializeField] private Transform spawnPlace;
    [SerializeField] private float projectileDmg;
    private Rigidbody2D rB;
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 100f;

    private void Start()
    {
        player = GameObject.Find("Playerfigur").transform;

        rB = GetComponent<Rigidbody2D>();
        Vector3 mousePos = Input.mousePosition;
        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 startDir = (mousePosInWorld - transform.position).normalized;
        Vector2 velo = new Vector2(startDir.x, startDir.y).normalized;
        rB.velocity = velo * moveSpeed ;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy_Life>().takeLife(projectileDmg);
        }

        if (col.gameObject.tag != "Player")
        {
            Destroy(transform.gameObject);
        }
    }
}
