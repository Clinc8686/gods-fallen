using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBorder : MonoBehaviour
{
    public LayerMask backgroundLayer;
    private void FixedUpdate()
    {
        if (!IsOnBackground())
        {
            StartCoroutine(LoadGameOver());
        }
    }

    bool IsOnBackground() {
        Vector2 position = transform.position;
        Vector3 direction = Vector3.back;
        float distance = 2.0f;
    
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, backgroundLayer);
        if (hit.collider != null) {
            return true;
        }
        return false;
    }
    
    IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3); 
    }
}
