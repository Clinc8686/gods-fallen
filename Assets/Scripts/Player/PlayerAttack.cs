using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private float attackRate = 5f; //per Sek
    [SerializeField] private GameObject shootObject;
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private float timeBtwShoot = 0.5f;
    [SerializeField] private float maxShootTime = 1.5f;
    [SerializeField] private Animator weaponAnimator;
    [SerializeField] private AudioSource shootSource;
    private float timeBtwAttack;
    private float shootDelay;
    private float maxMultShoots;

    private bool downDir = false;
    // Update is called once per frame
    void Update()
    {
        MoveWeapon();
        
        if (downDir)
        {
            if (shootDelay <= 0)
            {
                Shoot();
            }

            if (maxMultShoots <= 0)
            {
                EndDownWeapon();
            }
        }

        maxMultShoots -= Time.deltaTime;
        shootDelay -= Time.deltaTime;
    }
    
    
    private void OnAttack(InputValue value)
    {
        if (Time.time >= timeBtwAttack && !downDir && value.isPressed)
        {
            downDir = true;
            maxMultShoots = maxShootTime;
            Shoot();
        }
        else if(downDir)
        {
            timeBtwAttack = Time.time + 1f / attackRate;  
            downDir = false;
        }
        
    }

    private void MoveWeapon()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 startDir = (mousePosInWorld - weaponHolder.position);
        Vector2 aimDir = new Vector2(startDir.x, startDir.y).normalized;

        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        weaponHolder.eulerAngles = new Vector3(0, 0, angle-40);
    }

    private void Shoot()
    {
        Instantiate(shootObject, spawnLocation.position, Quaternion.identity);
        shootDelay = timeBtwShoot;
        weaponAnimator.SetTrigger("Attack");
        shootSource.Play();
    }

    private void EndDownWeapon()
    {
        timeBtwAttack = Time.time + 1f / attackRate;  
        downDir = false;
    }

    
    
}
