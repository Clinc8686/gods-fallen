using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private GameObject leere;
    [SerializeField] private GameObject hell;
    [SerializeField] private GameObject earth;
    [SerializeField] private GameObject sky;
    [SerializeField] private GameObject player;
    [SerializeField] private AnimatorOverrideController  red;
    [SerializeField] private AnimatorOverrideController  green;
    [SerializeField] private AnimatorOverrideController  blue;

    public static float emptinessDepth;
    public static float hellDepth;
    public static float earthDepth;
    public static float skyDepth;
    public static float emptinessHeight;
    public static float hellHeight;
    public static float earthHeigth;
    public static float skyHeigth;

    void Start()
    {
        SpriteRenderer srSky = sky.GetComponent<SpriteRenderer>();
        skyDepth = srSky.bounds.center.y - srSky.bounds.extents.y;
        skyHeigth = srSky.bounds.center.y + srSky.bounds.extents.y;
        
        SpriteRenderer srEarth = earth.GetComponent<SpriteRenderer>();
        earthDepth = srEarth.bounds.center.y - srEarth.bounds.extents.y;
        earthHeigth = srEarth.bounds.center.y + srEarth.bounds.extents.y;
        
        SpriteRenderer srHell = hell.GetComponent<SpriteRenderer>();
        hellDepth = srHell.bounds.center.y - srHell.bounds.extents.y;
        hellHeight = srHell.bounds.center.y + srHell.bounds.extents.y;
        
        SpriteRenderer srLeere = leere.GetComponent<SpriteRenderer>();
        emptinessDepth = srLeere.bounds.center.y - srLeere.bounds.extents.y;
        emptinessHeight = srLeere.bounds.center.y + srLeere.bounds.extents.y;
    }
    
    
    void Update()
    {
        float playerHeight = player.transform.position.y;
        if (playerHeight > skyDepth && playerHeight < skyHeigth)
        {
            player.GetComponent<Animator>().runtimeAnimatorController = blue;
        } else if (playerHeight > earthDepth && playerHeight < earthHeigth)
        {
            player.GetComponent<Animator>().runtimeAnimatorController = green;
        } else if (playerHeight > hellDepth && playerHeight < hellHeight)
        {
            player.GetComponent<Animator>().runtimeAnimatorController = red;
        } else if (playerHeight > emptinessDepth && playerHeight < emptinessHeight)
        {
            player.GetComponent<Animator>().runtimeAnimatorController = red;
        }
        
    }
}
