using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Sprite sideFace;
    [SerializeField] private Sprite frontFace;
    [SerializeField] private float changeTime = 0.5f;
    private float changeFace;
    private Vector2 moveDirection;

    private void OnMove(InputValue value)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sideFace;
        moveDirection = value.Get<Vector2>();

        if (moveDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0,-180,0);
        }
        else if(moveDirection.x > 0) 
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        
        if(moveDirection.x != 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sideFace;
            changeFace = changeTime;
        }
    }

    private void Update()
    {
        Vector3 dirVec = new Vector3(moveDirection.x, 0, 0);
        transform.position += dirVec * (moveSpeed * Time.deltaTime);
        if (moveDirection.x == 0 && (changeFace <= 0)) 
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = frontFace;
        }
        changeFace -= Time.deltaTime;
    }
}
