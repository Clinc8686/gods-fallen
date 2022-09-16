using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColor : MonoBehaviour
{
    [SerializeField] private Sprite earth;
    [SerializeField] private Sprite emptiness;
    [SerializeField] private Sprite sky;
    [SerializeField] private Sprite hell;

    void Update()
    {
        float playerHeight = transform.position.y;
        if (playerHeight > PlayerAnimations.skyDepth && playerHeight < PlayerAnimations.skyHeigth)
        {
            GetComponent<SpriteRenderer>().sprite = sky;
        } else if (playerHeight > PlayerAnimations.earthDepth && playerHeight < PlayerAnimations.earthHeigth)
        {
            GetComponent<SpriteRenderer>().sprite = earth;
        } else if (playerHeight > PlayerAnimations.hellDepth && playerHeight < PlayerAnimations.hellHeight)
        {
            GetComponent<SpriteRenderer>().sprite = hell;
        } else if (playerHeight > PlayerAnimations.emptinessDepth && playerHeight < PlayerAnimations.emptinessHeight)
        {
            GetComponent<SpriteRenderer>().sprite = emptiness;
        }
    }
}
