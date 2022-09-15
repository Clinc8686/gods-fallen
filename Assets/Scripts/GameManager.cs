using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playGround;
    [SerializeField] private GameObject bottomCollider;
    private bool _playGroundEnabled;

    [SerializeField] private GameObject playerFigur;
    [SerializeField] private GameObject sky;
    
    [SerializeField] private Image speechBubble;
    private bool speechBubbleEnabled;
    
    public LayerMask groundLayer;

    //Finish
    public void CompleteLevel()
    {
        Debug.Log("Level WoW!");
    }
    
    void Start()
    {
        ChangePlayGround(false);
        spawnPlayerOnTop();
        setSpeechBubbleText("Es war ein mal vor langer, langer Zeit...blablabla");
        showSpeechBubble(true);
    }
    
    void Update()
    {
    }
    
    void FixedUpdate()
    {
        if (IsGrounded() && _playGroundEnabled == false) {
            ChangePlayGround(true);
            showSpeechBubble(false);
        }
    }

    private void ChangePlayGround(bool status)
    {
        _playGroundEnabled = status;
        if (status)
        {
            playGround.SetActive(true);
        }
        else
        {
            playGround.SetActive(false);
        }
    }

    public void setSpeechBubbleText(String text)
    {
        TextMeshPro speechBubbleText = speechBubble.GetComponentInChildren<TextMeshPro>();
        speechBubbleText.text = text;
    }
    
    public void showSpeechBubble(bool status)
    {
        speechBubbleEnabled = status;
        if (status)
        {
            speechBubble.enabled = true;
        }
        else
        {
            speechBubble.enabled = false;
        }
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
