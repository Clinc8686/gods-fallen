using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BulletColor : MonoBehaviour
{
    [SerializeField] private Sprite earth;
    [SerializeField] private Sprite emptiness;
    [SerializeField] private Sprite sky;
    [SerializeField] private Sprite hell;

    [SerializeField] private GameObject leere;
    [SerializeField] private GameObject himmel;
    [SerializeField] private GameObject hoelle;
    [SerializeField] private GameObject erde;


   

    private void Start()
    {
        
        
    }
    void Update()
    {
        
        float playerHeight = transform.position.y;
        if (playerHeight > PlayerAnimations.skyDepth && playerHeight < PlayerAnimations.skyHeigth)
        {
            GetComponent<SpriteRenderer>().sprite = sky;
            setfalse();
            himmel.SetActive(true);
           
        } else if (playerHeight > PlayerAnimations.earthDepth && playerHeight < PlayerAnimations.earthHeigth)
        {

            setfalse();
            erde.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = earth;
            
           

        } else if (playerHeight > PlayerAnimations.hellDepth && playerHeight < PlayerAnimations.hellHeight)
        {
            setfalse();
            hoelle.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = hell;
         

        } else if (playerHeight > PlayerAnimations.emptinessDepth && playerHeight < PlayerAnimations.emptinessHeight)
        {
            setfalse();
            leere.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = emptiness;
            
        }
    }
    void setfalse()
    {
        himmel.SetActive(false);
        erde.SetActive(false);
        hoelle.SetActive(false);
        leere.SetActive(false);
    }
}
