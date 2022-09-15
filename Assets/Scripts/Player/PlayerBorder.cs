using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBorder : MonoBehaviour
{
    public LayerMask backgroundLayer;
    private void FixedUpdate()
    {
        if (!IsOnBackground())
        {
            Debug.Log("player hat verloren!");
            //hier Game Over Screen aufrufen oder Spieler neu Spawnen
        }
    }

    bool IsOnBackground() {
        Vector2 position = transform.position;
        Vector3 direction = Vector3.back;
        float distance = 2.0f;
    
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, backgroundLayer);
        if (hit.collider != null) {
            Debug.Log(hit.collider.name);
            return true;
        }
        return false;
    }
}
