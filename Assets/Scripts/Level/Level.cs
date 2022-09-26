using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level/Level")]
public class Level : ScriptableObject
{
    public string levelName;
    public int levelIndex;
    public bool locked = true;
}
