using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    
    void Update()
    {
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
    }
}
