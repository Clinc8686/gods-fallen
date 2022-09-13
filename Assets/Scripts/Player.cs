using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Background")
        {
            //Debug.Log("enter");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Background")
        {
            //Debug.Log("stay");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        //Destroy(this.gameObject);
        //Debug.Log("verloren!");
    }
}
