using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Colorchange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float playerHeight = transform.position.y;
        if (playerHeight > PlayerAnimations.skyDepth && playerHeight < PlayerAnimations.skyHeigth)
        {
            Light2D lt = this.GetComponent<Light2D>();
            Debug.Log("Hakko ich funktiniere! 11 " + lt.color);

            lt.color = new Color(40, 255, 40);
            Debug.Log("Hakko ich funktiniere! 12 " + lt.color);


        }
        else if (playerHeight > PlayerAnimations.earthDepth && playerHeight < PlayerAnimations.earthHeigth)
        {
            Debug.Log("2");
            this.GetComponent<Light2D>().color = Color.green;




        }
        else if (playerHeight > PlayerAnimations.hellDepth && playerHeight < PlayerAnimations.hellHeight)
        {
            Debug.Log("1");
            this.GetComponent<Light2D>().color = new Color(255f, 255f, 255f);

        }
        else if (playerHeight > PlayerAnimations.emptinessDepth && playerHeight < PlayerAnimations.emptinessHeight)
        {
            Debug.Log("Hakko ich funktiniere!");
            this.GetComponent<Light2D>().color = new Color(40f, 255f, 40f);

        }
    }
}
