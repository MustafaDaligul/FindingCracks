using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float range = 30;
    public GameManager gameManager;
    public TimeManager timeManager;
    public LosePanel losePanel;
    public GameObject _losePanel;
    private bool isPanelActive = false;
    public CountDown countDown;

    void Update()
    {
        if (gameManager.gameStarted && Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo, 100))
            {
                if (hitInfo.transform.CompareTag("crack"))
                {
                    Debug.Log(hitInfo.transform.name);
                    if (timeManager.timeDiff > gameManager.timeInterval && isPanelActive == false)
                    {
                        gameManager.gameStarted = false;
                        isPanelActive = true;
                        losePanel.isTimerActive = true;
                        _losePanel.SetActive(true);
                    }

                    if (gameManager.gameStarted)
                    {
                        Debug.Log("Click Time = " + timeManager.clickTime);
                        timeManager.timeDiff = timeManager.timer - timeManager.clickTime;
                        Debug.Log("TimeDiff = " + timeManager.timeDiff);
                        timeManager.clickTime = timeManager.timer;
                        Debug.Log("Time = " + timeManager.timer);
                        gameManager.crackCount += 1;
                        Destroy(hitInfo.collider.gameObject);
                        countDown.currentTime += 5;

                    }
                }

                if (hitInfo.transform.CompareTag("background"))
                {
                    gameManager.TakeDamage();
                }
            }
        }
    }
}
