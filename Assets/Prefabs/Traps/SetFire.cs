using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFire : MonoBehaviour
{
    [SerializeField] private float startTime = 2f;
    [SerializeField] private float duration = 1f;
    private MonoBehaviour fire;
    private float enableTime;
    void Start()
    {
        fire = transform.parent.GetComponent<MonoBehaviour>();
        enableTime = startTime;
    }

    private void Update()
    {
        if (enableTime <= 0)
        {
            enableTime = startTime;
            gameObject.SetActive(false);
            fire.StartCoroutine(disableFire());
        }

        enableTime -= Time.deltaTime;
    }
    
    IEnumerator disableFire()
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(true);
    }
}
