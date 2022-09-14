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
    [SerializeField] private float attackRate = 2f; //per Sek
    [SerializeField] private ParticleSystem shootObject;
    [SerializeField] private float shootTimer = 3;
    [SerializeField] private float maxMultipleShoots = 5f;
    private float grad;
    private int faktor = 1;
    private float timeBtwAttack;
    private float shootDelay;
    private float maxMultShoots;

    private bool downDir = false;
    // Update is called once per frame
    void Update()
    {
        if (downDir)
        {
            grad += faktor * downMoveSpeed * Time.deltaTime;
            grad = Mathf.Clamp(grad, -10, 25);
            DownWeapon();

            if (shootDelay <= 0)
            {
                FollowShoot();
            }

            if (maxMultShoots <= 0)
            {
                EndDownWeapon();
            }
        }
        else
        {
            grad += faktor * upMoveSpeed * Time.deltaTime;
            grad = Mathf.Clamp(grad, -10, 25);
            UpWeapon();
        }

        maxMultShoots -= Time.deltaTime;
        shootDelay -= Time.deltaTime;
    }
    
    
    private void OnAttack(InputValue value)
    {
        if (Time.time >= timeBtwAttack && !downDir && value.isPressed)
        {
            Debug.Log("Attack");
            downDir = true;
            faktor = -1;
            maxMultShoots = maxMultipleShoots;
            shootDelay = shootTimer;
            shootObject.Play();
        }
        else if(downDir)
        {
            Debug.Log("Released");
            timeBtwAttack = Time.time + 1f / attackRate;  
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

    private void FollowShoot()
    {
        shootObject.Play();
        shootDelay = shootTimer;
    }

    private void EndDownWeapon()
    {
        timeBtwAttack = Time.time + 1f / attackRate;  
        downDir = false;
        faktor = 1;
    }

    
    
}
