using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float upMoveSpeed = 100;
    [SerializeField] private float downMoveSpeed = 200;
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private float waitingTime = 1;
    private float grad;
    private int faktor = 1;
    private float timeBtwAttack;

    private bool downDir = false;
    // Update is called once per frame
    void Update()
    {
        if (downDir)
        {
            grad += faktor * downMoveSpeed * Time.deltaTime;
            grad = Mathf.Clamp(grad, -10, 25);
            DownWeapon();
        }
        else
        {
            grad += faktor * upMoveSpeed * Time.deltaTime;
            grad = Mathf.Clamp(grad, -10, 25);
            UpWeapon();
        }

        timeBtwAttack -= Time.deltaTime;
    }
    
    
    private void OnAttack(InputValue value)
    {
        if (timeBtwAttack <= 0 && !downDir && value.isPressed)
        {
            downDir = true;
            faktor = -1;
        }
        else if(downDir)
        {
            timeBtwAttack = waitingTime;
            downDir = false;
            faktor = 1;
        }
        
    }

    private void DownWeapon()
    {
        weaponHolder.rotation = Quaternion.Euler(0,transform.localEulerAngles.y,grad);
    }

    private void UpWeapon()
    {
        weaponHolder.rotation = Quaternion.Euler(0,transform.localEulerAngles.y,grad);
    }
}
