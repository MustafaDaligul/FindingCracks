using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RandomSpawner : MonoBehaviour
{
    public List<Action<GameObject>> colorGenerateMethods = new List<Action<GameObject>>();
    public List<Action<GameObject>> patternGenerateMethods = new List<Action<GameObject>>();

    public GameManager gameManager;
    public GameObject crack;
    public float zPos;
    public float crackSpawned = 0;

    public CrackDifficulty easyCrackStats, mediumCrackStats, hardCrackStats, impossibleCrackStats;
    public List<CrackDifficulty> crackStats;
    
    public float easyColorSpawned, mediumColorSpawned, hardColorSpawned, impossibleColorSpawned, easyPatternSpawned, mediumPatternSpawned, hardPatternSpawned, largeScaleSpawned, bigScaleSpawned, mediumScaleSpawned, smallScaleSpawned;
    private float easyColorCount, mediumColorCount, hardColorCount, impossibleColorCount, easyPatternCount, mediumPatternCount, hardPatternCount, largeScaleCount, bigScaleCount, mediumScaleCount, smallScaleCount;
    public void Start()
    {
        colorGenerateMethods.Add(GenerateEasyColor);
        colorGenerateMethods.Add(GenerateMediumColor);
        colorGenerateMethods.Add(GenerateHardColor);
        colorGenerateMethods.Add(GenerateImpossibleColor);
        patternGenerateMethods.Add(GenerateEasyPattern);
        patternGenerateMethods.Add(GenerateMediumPattern);
        patternGenerateMethods.Add(GenerateHardPattern);
    }
    void LateUpdate()
    {
        LevelManager.instance.currentLevel.howManyCracks = LevelManager.instance.currentLevel.smallScaleCount + LevelManager.instance.currentLevel.mediumScaleCount + LevelManager.instance.currentLevel.bigScaleCount + LevelManager.instance.currentLevel.largeScaleCount;
        if (crackSpawned < LevelManager.instance.currentLevel.howManyCracks && gameManager.gameStarted == true)
        {
            Vector3 position = Vector3.zero;
            bool validPos = false;
            while (!validPos)
            {
                position = new Vector3(UnityEngine.Random.Range(2.5f, 13.5f), UnityEngine.Random.Range(-3f, 3f), zPos);
                validPos = true;
                Collider[] colliders = Physics.OverlapBox(position, easyCrackStats.scales[0]);
                foreach (Collider col in colliders)
                {
                    if (col.tag == "crack")
                    {
                        validPos = false;
                    }
                }
            }
            if (validPos)
            {
                AddCracks(position);
            }
        }
    }
    private void AddCracks(Vector3 randomPos)
    {
        GenerateCrackColor(crack);
        crackSpawned += 1;
        Instantiate(crack, randomPos, Quaternion.identity);
    }
    private void GenerateCrackColor(GameObject go)
    {
        if (LevelManager.instance.currentLevel.colorDiff == LevelDifficulties.easy)
        {
            CalculateColorCounts(LevelManager.instance.easy.easyColorPercent, LevelManager.instance.easy.mediumColorPercent, LevelManager.instance.easy.hardColorPercent, LevelManager.instance.easy.impossibleColorPercent);
            CalculateColorSpawns();
            colorGenerateMethods[UnityEngine.Random.Range(0, colorGenerateMethods.Count)](go);
        }
        if (LevelManager.instance.currentLevel.colorDiff == LevelDifficulties.medium)
        {
            CalculateColorCounts(LevelManager.instance.medium.easyColorPercent, LevelManager.instance.medium.mediumColorPercent, LevelManager.instance.medium.hardColorPercent, LevelManager.instance.medium.impossibleColorPercent);
            CalculateColorSpawns();
            colorGenerateMethods[UnityEngine.Random.Range(0, colorGenerateMethods.Count)](go);
        }
        if (LevelManager.instance.currentLevel.colorDiff == LevelDifficulties.hard)
        {
            CalculateColorCounts(LevelManager.instance.hard.easyColorPercent, LevelManager.instance.hard.mediumColorPercent, LevelManager.instance.hard.hardColorPercent, LevelManager.instance.hard.impossibleColorPercent);
            CalculateColorSpawns();
            colorGenerateMethods[UnityEngine.Random.Range(0, colorGenerateMethods.Count)](go);
        }
        if (LevelManager.instance.currentLevel.colorDiff == LevelDifficulties.impossible)
        {
            CalculateColorCounts(LevelManager.instance.impossible.easyColorPercent, LevelManager.instance.impossible.mediumColorPercent, LevelManager.instance.impossible.hardColorPercent, LevelManager.instance.impossible.impossibleColorPercent);
            CalculateColorSpawns();
            colorGenerateMethods[UnityEngine.Random.Range(0, colorGenerateMethods.Count)](go);
        }
        if (LevelManager.instance.currentLevel.patternDiff == LevelDifficulties2.beginner)
        {
            CalculatePatternCounts(LevelManager.instance.beginner.easyPatternPercent, LevelManager.instance.beginner.mediumPatternPercent, LevelManager.instance.beginner.hardPatternPercent);
            CalculatePatternSpawns();
            patternGenerateMethods[UnityEngine.Random.Range(0, patternGenerateMethods.Count)](go);
        }
        if (LevelManager.instance.currentLevel.patternDiff == LevelDifficulties2.easy)
        {
            CalculatePatternCounts(LevelManager.instance.easy.easyPatternPercent, LevelManager.instance.easy.mediumPatternPercent, LevelManager.instance.easy.hardPatternPercent);
            CalculatePatternSpawns();
            patternGenerateMethods[UnityEngine.Random.Range(0, patternGenerateMethods.Count)](go);
        }
        if (LevelManager.instance.currentLevel.patternDiff == LevelDifficulties2.medium)
        {
            CalculatePatternCounts(LevelManager.instance.medium.easyPatternPercent, LevelManager.instance.medium.mediumPatternPercent, LevelManager.instance.medium.hardPatternPercent);
            CalculatePatternSpawns();
            patternGenerateMethods[UnityEngine.Random.Range(0, patternGenerateMethods.Count)](go);
        }
        if (LevelManager.instance.currentLevel.patternDiff == LevelDifficulties2.hard)
        {
            CalculatePatternCounts(LevelManager.instance.hard.easyPatternPercent, LevelManager.instance.hard.mediumPatternPercent, LevelManager.instance.hard.hardPatternPercent);
            CalculatePatternSpawns();
            patternGenerateMethods[UnityEngine.Random.Range(0, patternGenerateMethods.Count)](go);
        }
        if (LevelManager.Instance.currentLevel.patternDiff == LevelDifficulties2.impossible)
        {
            CalculatePatternCounts(LevelManager.instance.impossible.easyPatternPercent, LevelManager.instance.impossible.mediumPatternPercent, LevelManager.instance.impossible.hardPatternPercent);
            CalculatePatternSpawns();
            patternGenerateMethods[UnityEngine.Random.Range(0, patternGenerateMethods.Count)](go);
        }
        smallScaleCount = LevelManager.instance.currentLevel.smallScaleCount;
        mediumScaleCount = LevelManager.instance.currentLevel.mediumScaleCount;
        bigScaleCount = LevelManager.instance.currentLevel.bigScaleCount;
        largeScaleCount = LevelManager.instance.currentLevel.largeScaleCount;
        if (largeScaleSpawned < largeScaleCount)
        {
            go.GetComponent<Transform>().localScale = easyCrackStats.scales[UnityEngine.Random.Range(0, easyCrackStats.scales.Count)];
            largeScaleSpawned += 1;
        }
        else if (bigScaleSpawned < bigScaleCount)
        {
            go.GetComponent<Transform>().localScale = mediumCrackStats.scales[UnityEngine.Random.Range(0, mediumCrackStats.scales.Count)];
            bigScaleSpawned += 1;
        }
        else if (mediumScaleSpawned < mediumScaleCount)
        {
            go.GetComponent<Transform>().localScale = hardCrackStats.scales[UnityEngine.Random.Range(0, hardCrackStats.scales.Count)];
            mediumScaleSpawned += 1;
        }
        else if (smallScaleSpawned < smallScaleCount)
        {
            go.GetComponent<Transform>().localScale = impossibleCrackStats.scales[UnityEngine.Random.Range(0, impossibleCrackStats.scales.Count)];
            smallScaleSpawned += 1;
        }
    }
    public void CalculateColorCounts(float easyColorPercent, float mediumColorPercent, float hardColorPercent, float impossibleColorPercent)
    {
        easyColorCount = (easyColorPercent / 100f) * LevelManager.instance.currentLevel.howManyCracks;
        mediumColorCount = (mediumColorPercent / 100f) * LevelManager.instance.currentLevel.howManyCracks;
        hardColorCount = (hardColorPercent / 100f) * LevelManager.instance.currentLevel.howManyCracks;
        impossibleColorCount = (impossibleColorPercent / 100f) * LevelManager.instance.currentLevel.howManyCracks;
    }
    public void CalculatePatternCounts(float easyPatternPercent, float mediumPatternPercent, float hardPatternPercent)
    {
        easyPatternCount = (easyPatternPercent / 100f) * LevelManager.instance.currentLevel.howManyCracks;
        mediumPatternCount = (mediumPatternPercent / 100f) * LevelManager.instance.currentLevel.howManyCracks;
        hardPatternCount = (hardPatternPercent / 100f) * LevelManager.instance.currentLevel.howManyCracks;
    }
    public void CalculateColorSpawns()
    {
        if (easyColorSpawned == easyColorCount)
        {
            colorGenerateMethods.Remove(GenerateEasyColor);
        }
        if (mediumColorSpawned == mediumColorCount)
        {
            colorGenerateMethods.Remove(GenerateMediumColor);
        }
        if (hardColorSpawned == hardColorCount)
        {
            colorGenerateMethods.Remove(GenerateHardColor);
        }
        if (impossibleColorSpawned == impossibleColorCount)
        {
            colorGenerateMethods.Remove(GenerateImpossibleColor);
        }
    }
    public void CalculatePatternSpawns()
    {
        if (easyPatternSpawned == easyPatternCount)
        {
            patternGenerateMethods.Remove(GenerateEasyPattern);
        }
        if (mediumColorSpawned == mediumPatternCount)
        {
            patternGenerateMethods.Remove(GenerateMediumPattern);
        }
        if (hardPatternSpawned == hardPatternCount)
        {
            patternGenerateMethods.Remove(GenerateHardPattern);
        }
    }
    public void GenerateEasyPattern(GameObject go)
    {
        if (easyPatternSpawned < easyPatternCount)
        {
            go.GetComponent<SpriteRenderer>().sprite = easyCrackStats.sprites[UnityEngine.Random.Range(0, easyCrackStats.sprites.Count)];
            easyPatternSpawned += 1;
        }
        if (easyPatternSpawned >= easyPatternCount)
        {
            patternGenerateMethods.Remove(GenerateEasyPattern);
        }
    }
    public void GenerateMediumPattern(GameObject go)
    {
        if (mediumPatternSpawned < mediumPatternCount)
        {
            go.GetComponent<SpriteRenderer>().sprite = mediumCrackStats.sprites[UnityEngine.Random.Range(0, mediumCrackStats.sprites.Count)];
            mediumPatternSpawned += 1;
        }
        if (mediumPatternSpawned >= mediumPatternCount)
        {
            patternGenerateMethods.Remove(GenerateMediumPattern);
        }
    }
    public void GenerateHardPattern(GameObject go)
    {
        if (hardPatternSpawned < hardPatternCount)
        {
            go.GetComponent<SpriteRenderer>().sprite = hardCrackStats.sprites[UnityEngine.Random.Range(0, hardCrackStats.sprites.Count)];
            hardPatternSpawned += 1;
        }
        if (hardPatternSpawned >= hardPatternCount)
        {
            patternGenerateMethods.Remove(GenerateHardPattern);
        }
    }
    public void GenerateEasyColor(GameObject go)
    {
        if (easyColorSpawned < easyColorCount)
        {
            go.GetComponent<SpriteRenderer>().color = easyCrackStats.colors[UnityEngine.Random.Range(0, easyCrackStats.colors.Count)];
            easyColorSpawned += 1;
        }
        if (easyColorSpawned >= easyColorCount)
        {
            colorGenerateMethods.Remove(GenerateEasyColor);
        }

    }
    public void GenerateMediumColor(GameObject go)
    {
        if (mediumColorSpawned < mediumColorCount)
        {
            go.GetComponent<SpriteRenderer>().color = mediumCrackStats.colors[UnityEngine.Random.Range(0, mediumCrackStats.colors.Count)];
            mediumColorSpawned += 1;
        }
        if (mediumColorSpawned >= mediumColorCount)
        {
            colorGenerateMethods.Remove(GenerateMediumColor);
        }
    }
    public void GenerateHardColor(GameObject go)
    {
        if (hardColorSpawned < hardColorCount)
        {
            go.GetComponent<SpriteRenderer>().color = hardCrackStats.colors[UnityEngine.Random.Range(0, hardCrackStats.colors.Count)];
            hardColorSpawned += 1;
        }
        if (hardColorSpawned >= hardColorCount)
        {
            colorGenerateMethods.Remove(GenerateHardColor);
        }
    }
    public void GenerateImpossibleColor(GameObject go)
    {
        if (impossibleColorSpawned < impossibleColorCount)
        {
            go.GetComponent<SpriteRenderer>().color = impossibleCrackStats.colors[UnityEngine.Random.Range(0, impossibleCrackStats.colors.Count)];
            impossibleColorSpawned += 1;
        }
        if (impossibleColorSpawned >= impossibleColorCount)
        {
            colorGenerateMethods.Remove(GenerateImpossibleColor);
        }
    }
}