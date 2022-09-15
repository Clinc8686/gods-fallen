using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAnimation : MonoBehaviour
{
    [SerializeField] private AnimatorController leere_Weapon;
    [SerializeField] private AnimatorController hell_Weapon;
    [SerializeField] private Sprite sky_Weapon;
    [SerializeField] private Sprite earth_Weapon;
    [SerializeField] private Sprite leere_Weapon_Sprite;
    [SerializeField] private Sprite hell_Weapon_Sprite;

    void Update()
    {
        float playerHeight = this.transform.position.y;
        if (playerHeight >= PlayerAnimations.skyHeight)
        {
            setSpriteRenderer(sky_Weapon);
        } else if (playerHeight >= PlayerAnimations.earthHeight)
        {
            setSpriteRenderer(earth_Weapon);
        } else if (playerHeight >= PlayerAnimations.hellHeight)
        {
            setSpriteRenderer(leere_Weapon_Sprite);
            setAnimator(hell_Weapon);
        } else if (playerHeight >= PlayerAnimations.leereHeight)
        {
            setSpriteRenderer(hell_Weapon_Sprite);
            setAnimator(leere_Weapon);
        }
    }

    void setAnimator(AnimatorController ac)
    {
        this.GetComponent<Animator>().enabled = true;
        this.GetComponent<Animator>().runtimeAnimatorController = ac;
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

    void setSpriteRenderer(Sprite s)
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<SpriteRenderer>().sprite = s;
        this.GetComponent<Animator>().enabled = false;
    }
}
