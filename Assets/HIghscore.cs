using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIghscore : MonoBehaviour
{
    private static bool isDeath = false;
    // Start is called before the first frame update
    private void OnDestroy()
    {
        //EnemyDeath();
        Debug.Log("DES");
        isDeath = true;
    }

    public static bool EnemyDeath()
    {
        if(isDeath)
        {
            isDeath = false;
            return true;
            
        }
        return false;

    }

}
