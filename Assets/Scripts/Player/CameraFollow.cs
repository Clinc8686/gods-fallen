using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private float followSpeed = 2f;
    [SerializeField] private Transform target;
    [SerializeField] private float yOffset = 1;

    // Update is called once per frame
    void Update()
    {
        if (target != null) //von Mario & Spieler zur Kamera hinzugefgt im Inspector
        {
            Vector3 targetPos = target.position;
            Vector3 newPos = new Vector3(targetPos.x, targetPos.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
    }
}
