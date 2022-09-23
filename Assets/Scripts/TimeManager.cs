using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float timer;
    public float clickTime;
    public float timeDiff;
    public GameObject _losePanel;
    public LosePanel losePanel;
    private bool isLosePanelActive = false;
    public GameManager gameManager;

    void Start()
    {
        clickTime = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timeDiff > gameManager.timeInterval && isLosePanelActive == false)
        {
            isLosePanelActive = true;
            losePanel.isTimerActive = true;
            _losePanel.SetActive(true);
            gameManager.gameStarted = false;
        }
    }
}
