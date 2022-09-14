using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playGround;
    private bool playGroundEnabled;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject sky;
    void Start()
    {
        playGroundEnabled = false;
        changePlayGround();

        spawnPlayerOnTop();

        playGroundEnabled = true;
        changePlayGround();
    }
    
    void Update()
    {
        
    }

    private void changePlayGround()
    {
        if (playGroundEnabled)
        {
            playGround.SetActive(true);
        }
        else
        {
            playGround.SetActive(false);
        }
    }

    private void spawnPlayerOnTop()
    {
        SpriteRenderer sr = sky.GetComponent<SpriteRenderer>();
        float skyHeightForPlayer = 2 * (sr.bounds.extents.y / 3);
        float playerSpawnHeight = sr.bounds.center.y + skyHeightForPlayer;

        player.transform.position = new Vector3(sr.bounds.center.x, playerSpawnHeight, 0);
        Debug.Log(player.transform.position.x + " " + player.transform.position.y + " " + player.transform.position.z);
        //player.transform.position = new Vector3()
    }
}
