using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowHighscore : MonoBehaviour
{
    void Start()
    {
        int amount = (int) PlayerPrefs.GetFloat("Highscore", 0);
        transform.GetComponent<TextMeshProUGUI>().text = amount + " Sekunden";
    }
}
