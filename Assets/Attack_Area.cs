using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Area : MonoBehaviour
{

   
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Playerfigur")
        {
            gameObject.GetComponent<AIPath>().canMove = true;
        }
    }
  
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Playerfigur")
        {
            gameObject.GetComponent<AIPath>().canMove = false;
        }
    }

}
