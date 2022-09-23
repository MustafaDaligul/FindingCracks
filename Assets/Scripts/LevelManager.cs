using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int currentLevelIndex = 0;

    public static LevelManager instance;

    public LevelList levelList;
    public LevelDifficulty beginner;
    public LevelDifficulty easy;
    public LevelDifficulty medium;
    public LevelDifficulty hard;
    public LevelDifficulty impossible;
    public Level currentLevel;

    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("LevelManager").AddComponent<LevelManager>();
            }
            else
            {

            }
            return instance;
        }
    }
    void Start()
    {
        instance = this;
    }
    private void Update()
    {
        currentLevel = levelList.levelList[currentLevelIndex];
    }
}