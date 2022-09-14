using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private GameObject leere;
    [SerializeField] private GameObject hell;
    [SerializeField] private GameObject earth;
    [SerializeField] private GameObject sky;
    [SerializeField] private GameObject player;
    [SerializeField] private AnimatorController red;
    [SerializeField] private AnimatorController green;
    [SerializeField] private AnimatorController blue;
    
    private float leereHeight;
    private float hellHeight;
    private float earthHeight;
    private float skyHeight;
    void Start()
    {
        SpriteRenderer srSky = sky.GetComponent<SpriteRenderer>();
        skyHeight = srSky.bounds.center.y - srSky.bounds.extents.y;
        
        SpriteRenderer srEarth = earth.GetComponent<SpriteRenderer>();
        earthHeight = srEarth.bounds.center.y - srEarth.bounds.extents.y;
        
        SpriteRenderer srHell = hell.GetComponent<SpriteRenderer>();
        hellHeight = srHell.bounds.center.y - srHell.bounds.extents.y;
        
        SpriteRenderer srLeere = leere.GetComponent<SpriteRenderer>();
        leereHeight = srLeere.bounds.center.y - srLeere.bounds.extents.y;
    }
    
    void Update()
    {
        float playerHeight = player.transform.position.y;
        if (playerHeight >= skyHeight)
        {
            player.GetComponent<Animator>().runtimeAnimatorController = blue;
        } else if (playerHeight >= earthHeight)
        {
            player.GetComponent<Animator>().runtimeAnimatorController = green;
        } else if (playerHeight >= hellHeight)
        {
            player.GetComponent<Animator>().runtimeAnimatorController = red;
        } else if (playerHeight >= leereHeight)
        {
            player.GetComponent<Animator>().runtimeAnimatorController = red;
        }
    }
}
