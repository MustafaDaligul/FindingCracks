using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject",menuName = "ScriptableObject/Level")]
public class Level : ScriptableObject
{
    public int largeScaleCount;
    public int bigScaleCount;
    public int mediumScaleCount;
    public int smallScaleCount;
    public LevelDifficulties colorDiff;
    public LevelDifficulties2 patternDiff;
    public Material backgroundImage;
    public int howManyCracks = 1;
}
