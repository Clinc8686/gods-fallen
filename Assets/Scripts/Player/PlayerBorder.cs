using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBorder : MonoBehaviour
{
    public LayerMask groundLayer;
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
        Vector2 direction = Vector2.down;
        float distance = 2.0f;
    
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null) {
            return true;
        }
        return false;
    }
}
