using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpeechBoxes : MonoBehaviour
{
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private GameObject endboss;
    // Start is called before the first frame update
    void Start()
    {
        endboss.SetActive(false);
        setSpeechBubbleText("The last Boss... This Time I won't get defeated...");
        Invoke("disableSpeechBubble", 2.5f);
    }

    private void disableSpeechBubble()
    {
        showSpeechBubble(false);
        endboss.SetActive(true);
    }
    private void setSpeechBubbleText(string text)
    {
        TextMeshProUGUI speechBubbleText = speechBubble.GetComponentInChildren<TextMeshProUGUI>();
        speechBubbleText.text = text;
    }

    private void showSpeechBubble(bool status)
    {
        speechBubble.SetActive(status);
    }
}
