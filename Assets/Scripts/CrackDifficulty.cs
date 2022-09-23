using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ScriptableObject", menuName = "ScriptableObject/Difficulty")]
public class CrackDifficulty : ScriptableObject
{
    public List<Color> colors;
    public List<Sprite> sprites;
    public List<Vector3> scales;
}
