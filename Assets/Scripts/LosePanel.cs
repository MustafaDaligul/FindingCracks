using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    public Image Worker;
    //float timer;
    public GameManager gameManager;
    public Vector3 startPos = new Vector3(-350f, 350f, 0f);
    Vector3 endPos = new Vector3(350f, 350f, 0f);
    public Dialogue dialogue;
 
    public float timerCounter;
    public float timerDuration = 3;
    public bool isTimerActive;
    public GameObject chatBubble;
    public TextMeshProUGUI loseText;
    public GameObject losePanel;
    public GameObject button;

    void Update()
    {
        if (isTimerActive)
        {
            if (timerCounter < timerDuration)
            {
                timerCounter += Time.deltaTime;
                Worker.rectTransform.anchoredPosition = Vector3.Lerp(startPos, endPos, timerCounter / timerDuration);
            }
            else
            {
                Worker.rectTransform.anchoredPosition = endPos;
                chatBubble.SetActive(true);
                button.SetActive(true);
                isTimerActive = false;
                //timerCounter = 0;
                dialogue.StartDialogue();
            }
        }
    }
}
