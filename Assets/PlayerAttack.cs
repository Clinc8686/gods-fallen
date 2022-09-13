using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackMoveSpeed = 100;
    private bool attack = false;
    private float attackRotGrad = 0;
    private int attackRotFaktor = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void OnAttack(InputValue value)
    {
        Debug.Log("OnAttack, " + transform.rotation);
        if (value.isPressed)
        {
            Debug.Log("OnClick");
        }
        else
        {
            Debug.Log("Off");
        }
    }
    
    private void RotateWeapon()
    {
        Transform weapon = transform.GetChild(0);
        Debug.Log(attackRotGrad);

        if (attackRotGrad == 22)
        {
            attack = false;
        }
        
        if (attackRotGrad == -10)
        {
            attackRotFaktor = -1;
        }
            
        attackRotGrad += attackRotFaktor * Time.deltaTime * attackMoveSpeed;
        attackRotGrad = Mathf.Clamp(attackRotGrad, -10, 22);
            
        weapon.rotation = Quaternion.Euler(0,0,attackRotGrad);
    }
}
