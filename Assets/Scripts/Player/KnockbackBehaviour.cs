using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackBehaviour : MonoBehaviour
{
    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackTime;
    [SerializeField] private float knockbackHigh;
    private Rigidbody2D rB;
    public void StartKnockback(Collision2D col)
    {
        rB = transform.GetComponent<Rigidbody2D>();
        Knockback(col);
    }

    private void Knockback(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Vector2 dif = (transform.position - col.transform.position).normalized;
            Vector2 dir = new Vector2(dif.x, dif.y+ knockbackHigh);
            rB.AddForce(dir * knockbackForce, ForceMode2D.Impulse);
            StartCoroutine(UnKnockback());
        }
    }

    public IEnumerator UnKnockback()
    {
        yield return new WaitForSeconds(knockbackTime);
        rB.velocity = Vector2.zero;
        
    }
}
