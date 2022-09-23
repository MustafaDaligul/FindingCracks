using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //internal static object t;
    public int playerHealt;
    //public GameObject worker;
    public LosePanel losePanel;
    //public GameObject _losePanel;
    //public TimeManager timeManager;
    public int crackCount = 0;
    public bool gameStarted = false;
    public float timeInterval;
    public GameObject countDownObject;
    public CountDown countDown;
    public Dialogue dialogue;

    public void TakeDamage()
    {
        playerHealt = playerHealt - 1;
        if (playerHealt == 0)
        {
            LoseGame();
        }
    }

    private void LoseGame()
    {
        losePanel.isTimerActive = true;
        gameStarted = false;
        countDownObject.SetActive(false);
    }

    void Start()
    {
        playerHealt = 3;
        //gameStarted = true;
    }
}
