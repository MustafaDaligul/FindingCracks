using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    public float currentTime = 0, startTime = 30;
    public bool isCountDownActive = false;
    public GameManager gameManager;

    public LosePanel losePanel;

    public TextMeshProUGUI countDownText;

    private void Start()
    {
        currentTime = startTime;
        isCountDownActive = false;
    }
    private void Update()
    {
        if (isCountDownActive == false)
        {
            return;
        }

        currentTime -= Time.deltaTime;
        countDownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            isCountDownActive = false;

            losePanel.isTimerActive = true;
            gameManager.gameStarted = false;
        }
    }
}
