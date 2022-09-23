using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject",menuName = "ScriptableObject/LevelDiff")]
public class LevelDifficulty : ScriptableObject
{
    public float easyColorPercent;
    public float mediumColorPercent;
    public float hardColorPercent;
    public float impossibleColorPercent;

    public float easyPatternPercent;
    public float mediumPatternPercent;
    public float hardPatternPercent;
}
