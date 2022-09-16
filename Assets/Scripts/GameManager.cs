using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playGround;
    [SerializeField] private GameObject bottomCollider;
    private bool _playGroundEnabled;

    [SerializeField] private GameObject playerFigur;
    [SerializeField] private GameObject sky;
    [SerializeField] private GameObject speechBubble;
    public LayerMask groundLayer;
    private GameObject[] enemies;
    public static bool isBeginning = true;

    //Finish
    public void CompleteLevel()
    {
        SceneManager.LoadScene(6);
    }
    
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        spawnPlayerOnTop();
        setSpeechBubbleText("Es war ein mal vor langer, langer Zeit... blablabla");
        showSpeechBubble(true);
        showPlayGround(false);
        showEnemies(false);
    }

    void FixedUpdate()
    {
        if (IsGrounded() && _playGroundEnabled == false) {
            showPlayGround(true);
            showSpeechBubble(false);
            showEnemies(true);
            isBeginning = false;
        }
    }

    private void showPlayGround(bool status)
    {
        _playGroundEnabled = status;
        playGround.SetActive(status);
    }

    private void showEnemies(bool status)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(status);
        }
    }
    
    public void setSpeechBubbleText(String text)
    {
        TextMeshProUGUI speechBubbleText = speechBubble.GetComponentInChildren<TextMeshProUGUI>();
        speechBubbleText.text = text;
    }

    public void showSpeechBubble(bool status)
    {
        speechBubble.SetActive(status);
    }

    private void spawnPlayerOnTop()
    {
        SpriteRenderer sr = sky.GetComponent<SpriteRenderer>();
        float skyHeightForPlayer = 2 * (sr.bounds.extents.y / 3);
        float playerSpawnHeight = sr.bounds.center.y + skyHeightForPlayer;
        playerFigur.transform.position = new Vector3(sr.bounds.center.x, playerSpawnHeight, 0);
    }
    
    bool IsGrounded() {
        Vector2 position = playerFigur.transform.position;
        Vector2 direction = Vector2.down;
        float distance = 2.0f;
    
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null) {
            return true;
        }
        return false;
    }
}
