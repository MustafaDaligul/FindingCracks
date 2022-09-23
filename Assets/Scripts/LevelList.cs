using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ScriptableObject", menuName = ("ScriptableObject/LevelList"))]
public class LevelList : ScriptableObject
{
    public List<Level> levelList;
}
