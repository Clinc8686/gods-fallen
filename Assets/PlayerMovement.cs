using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    private Vector2 moveDirection;

    private void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    private void Update()
    {
        Vector3 dirVec = new Vector3(moveDirection.x, 0, 0);
        transform.position += dirVec * (moveSpeed * Time.deltaTime);
    }
}
