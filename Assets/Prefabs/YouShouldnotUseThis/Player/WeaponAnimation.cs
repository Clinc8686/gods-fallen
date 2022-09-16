using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAnimation : MonoBehaviour
{
    private GameObject skyWeapon;
    private GameObject earthWeapon;
    private GameObject hellWeapon;
    private GameObject leereWeapon;
    private void Start()
    {
        setInactive();
        skyWeapon = transform.GetChild(3).gameObject;
        earthWeapon = transform.GetChild(1).gameObject;
        hellWeapon = transform.GetChild(2).gameObject;
        leereWeapon = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        float playerHeight = transform.position.y;
        if (playerHeight > PlayerAnimations.skyDepth && playerHeight < PlayerAnimations.skyHeigth && !skyWeapon.gameObject.activeSelf)
        {
            setInactive();
            skyWeapon.SetActive(true);
        } else if (playerHeight > PlayerAnimations.earthDepth && playerHeight < PlayerAnimations.earthHeigth && !earthWeapon.gameObject.activeSelf)
        {
            setInactive();
            earthWeapon.SetActive(true);
        } else if (playerHeight > PlayerAnimations.hellDepth && playerHeight < PlayerAnimations.hellHeight && !hellWeapon.gameObject.activeSelf)
        {
            setInactive();
            hellWeapon.SetActive(true);
        } else if (playerHeight > PlayerAnimations.emptinessDepth && playerHeight < PlayerAnimations.emptinessHeight && !leereWeapon.gameObject.activeSelf)
        {
            setInactive();
            leereWeapon.SetActive(true);
        }
    }

    void setInactive()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
    }
    
}
