using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAnimation : MonoBehaviour
{
    private void Start()
    {
        setInactive();
    }

    void Update()
    {
        float playerHeight = transform.position.y;
        if (playerHeight >= PlayerAnimations.skyHeight)
        {
            setInactive();
            transform.GetChild(3).gameObject.SetActive(true);
        } else if (playerHeight >= PlayerAnimations.earthHeight)
        {
            setInactive();
            transform.GetChild(1).gameObject.SetActive(true);
        } else if (playerHeight >= PlayerAnimations.hellHeight)
        {
            setInactive();
            transform.GetChild(2).gameObject.SetActive(true);
        } else if (playerHeight >= PlayerAnimations.leereHeight)
        {
            setInactive();
            transform.GetChild(0).gameObject.SetActive(true);
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
