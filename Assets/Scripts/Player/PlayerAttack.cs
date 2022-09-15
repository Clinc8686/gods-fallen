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
    [SerializeField] private float attackRate = 5f; //per Sek
    [SerializeField] private ParticleSystem shootObject;
    [SerializeField] private float timeBtwShoot = 0.5f;
    [SerializeField] private float maxShootTime = 1.5f;
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
            grad = Mathf.Clamp(grad, -25, 0);
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
            grad = Mathf.Clamp(grad, -25, 0);
            UpWeapon();
        }

        maxMultShoots -= Time.deltaTime;
        shootDelay -= Time.deltaTime;
    }
    
    
    private void OnAttack(InputValue value)
    {
        if (Time.time >= timeBtwAttack && !downDir && value.isPressed)
        {
            downDir = true;
            faktor = -1;
            maxMultShoots = maxShootTime;
            shootDelay = timeBtwShoot;
            shootObject.Play();
        }
        else if(downDir)
        {
            timeBtwAttack = Time.time + 1f / attackRate;  
            downDir = false;
            faktor = 1;
        }
        
    }

    private void DownWeapon()
    {
        weaponHolder.localEulerAngles = new Vector3(0, 0, grad);
    }

    private void UpWeapon()
    {
        weaponHolder.localEulerAngles = new Vector3(0,0, grad);
    }

    private void FollowShoot()
    {
        shootObject.Play();
        shootDelay = timeBtwShoot;
    }

    private void EndDownWeapon()
    {
        timeBtwAttack = Time.time + 1f / attackRate;  
        downDir = false;
        faktor = 1;
    }

    
    
}
