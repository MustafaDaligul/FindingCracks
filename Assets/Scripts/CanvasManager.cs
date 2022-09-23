using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject _losePanel, restartPanel, levelCompletePanel, chatBubble, skipDialnogueButton, crack, _startPanel, _levelSelectionPanel, countDownText;
    public GameManager gameManager;
    public RandomSpawner randomSpawner
    public TimeManager timeManager;
    public Image worker;
    public LosePanel losePanel;
    public Dialogue dialogue;
    private Vector3 crackPos = new Vector3(5.97f,8.62f,0);
    public CountDown countDown;

    void LateUpdate()
    {
        if (!_losePanel.activeSelf)
        {
            restartPanel.SetActive(true);
            gameManager.gameStarted = false;
        }

        if (gameManager.crackCount == LevelManager.instance.currentLevel.howManyCracks)
        {
            countDownText.SetActive(false);
            gameManager.gameStarted = false;
            levelCompletePanel.SetActive(true);
            countDown.isCountDownActive = false;
        }
    }
    public void Restart()
    {
        gameManager.crackCount = 0;
        randomSpawner.crackSpawned = 0;
        randomSpawner.bigScaleSpawned = 0;
        randomSpawner.mediumScaleSpawned = 0;
        randomSpawner.smallScaleSpawned = 0;
        randomSpawner.easyColorSpawned = 0;
        randomSpawner.mediumColorSpawned = 0;
        randomSpawner.hardColorSpawned = 0;
        randomSpawner.impossibleColorSpawned = 0;
        randomSpawner.easyPatternSpawned = 0;
        randomSpawner.mediumPatternSpawned = 0;
        randomSpawner.hardPatternSpawned = 0;
        restartPanel.SetActive(false);
        gameManager.gameStarted = true;
        _losePanel.SetActive(true);
        chatBubble.SetActive(false);
        skipDialogueButton.SetActive(false);
        timeManager.timeDiff = 0;
        timeManager.clickTime = 0;
        gameManager.playerHealt = 3;
        worker.rectTransform.anchoredPosition = losePanel.startPos;
        losePanel.isTimerActive = false;
        losePanel.timerCounter = 0;
        dialogue.textComponent.text = string.Empty;
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("crack");
        foreach (GameObject var in taggedObjects)
        {
            Destroy(var);
        }
        Instantiate(crack, crackPos, Quaternion.identity);
        randomSpawner.colorGenerateMethods.Add(randomSpawner.GenerateEasyColor);
        randomSpawner.colorGenerateMethods.Add(randomSpawner.GenerateMediumColor);
        randomSpawner.colorGenerateMethods.Add(randomSpawner.GenerateHardColor);
        randomSpawner.colorGenerateMethods.Add(randomSpawner.GenerateImpossibleColor);
        randomSpawner.patternGenerateMethods.Add(randomSpawner.GenerateEasyPattern);
        randomSpawner.patternGenerateMethods.Add(randomSpawner.GenerateMediumPattern);
        randomSpawner.patternGenerateMethods.Add(randomSpawner.GenerateHardPattern);
        countDown.currentTime = countDown.startTime;
        countDownText.SetActive(true);
        countDown.isCountDownActive = true;
    }
    public void NextLevel()
    {
        randomSpawner.crackSpawned = 0;
        gameManager.crackCount = 0;
        LevelManager.currentLevelIndex += 1;
        randomSpawner.bigScaleSpawned = 0;
        randomSpawner.mediumScaleSpawned = 0;
        randomSpawner.smallScaleSpawned = 0;
        randomSpawner.easyColorSpawned = 0;
        randomSpawner.mediumColorSpawned = 0;
        randomSpawner.hardColorSpawned = 0;
        randomSpawner.impossibleColorSpawned = 0;
        randomSpawner.easyPatternSpawned = 0;
        randomSpawner.mediumPatternSpawned = 0;
        randomSpawner.hardPatternSpawned = 0;
        levelCompletePanel.SetActive(false);
        gameManager.gameStarted = true;
        gameManager.playerHealt = 3;
        losePanel.isTimerActive = false;
        losePanel.timerCounter = 0;
        randomSpawner.colorGenerateMethods.Add(randomSpawner.GenerateEasyColor);
        randomSpawner.colorGenerateMethods.Add(randomSpawner.GenerateMediumColor);
        randomSpawner.colorGenerateMethods.Add(randomSpawner.GenerateHardColor);
        randomSpawner.colorGenerateMethods.Add(randomSpawner.GenerateImpossibleColor);
        randomSpawner.patternGenerateMethods.Add(randomSpawner.GenerateEasyPattern);
        randomSpawner.patternGenerateMethods.Add(randomSpawner.GenerateMediumPattern);
        randomSpawner.patternGenerateMethods.Add(randomSpawner.GenerateHardPattern);
        countDown.currentTime = countDown.startTime;
        countDownText.SetActive(true);
        countDown.isCountDownActive = true;
    }

    public void StartGame()
    {
        gameManager.gameStarted = true;
        _startPanel.SetActive(false);
        countDownText.SetActive(true);
        countDown.currentTime = countDown.startTime;
        countDown.isCountDownActive = true;
    }

    public void LevelSelectPanel()
    {
        _startPanel.SetActive(false);
        _levelSelectionPanel.SetActive(true);
    }

    public void SelectLevel(int level)
    {
        LevelManager.currentLevelIndex = level;
        gameManager.gameStarted = true;
        _levelSelectionPanel.SetActive(false);
        countDownText.SetActive(true);
        countDown.currentTime = countDown.startTime;
        countDown.isCountDownActive = true;
    }
}
