using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMode : MonoBehaviour
{
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") { 
        anim.SetTrigger("active");
        StartCoroutine(ChangeScene());
        }

    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(7);
    }

}
