using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Animation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        anim.SetTrigger("death");
    }
}
