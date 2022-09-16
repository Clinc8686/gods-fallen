using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColor : MonoBehaviour
{
    [SerializeField] private Sprite earth;
    [SerializeField] private Sprite emptiness;
    [SerializeField] private Sprite sky;
    [SerializeField] private Sprite hell;



    public Transform Light;


    private void Start()
    {
        
        
    }
    void Update()
    {
        
        float playerHeight = transform.position.y;
        if (playerHeight > PlayerAnimations.skyDepth && playerHeight < PlayerAnimations.skyHeigth)
        {
            GetComponent<SpriteRenderer>().sprite = sky;
            Light = transform.FindChild("LightLeere");
            Light.gameObject.SetActive(true);
        } else if (playerHeight > PlayerAnimations.earthDepth && playerHeight < PlayerAnimations.earthHeigth)
        {
            GetComponent<SpriteRenderer>().sprite = earth;
            
            Light.gameObject.SetActive(false);
            Light = transform.FindChild("LightHell");
            Light.gameObject.SetActive(true);

        } else if (playerHeight > PlayerAnimations.hellDepth && playerHeight < PlayerAnimations.hellHeight)
        {
            GetComponent<SpriteRenderer>().sprite = hell;
            Light.gameObject.SetActive(false);
            Light = transform.FindChild("LightEarth");
            Light.gameObject.SetActive(true);

        } else if (playerHeight > PlayerAnimations.emptinessDepth && playerHeight < PlayerAnimations.emptinessHeight)
        {
            GetComponent<SpriteRenderer>().sprite = emptiness;
            Light.gameObject.SetActive(false);
            Light = transform.FindChild("LightHeaven");
            Light.gameObject.SetActive(true);

        }
    }
}
