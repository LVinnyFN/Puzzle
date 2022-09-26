using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chapter", menuName = "Level/Chapter")]
public class Chapter : ScriptableObject
{
    public int sceneIndex;
    public string chapterName = "Chapter";
    public bool locked => IsLocked();
    [SerializeField]private List<Level> levels = new List<Level>();

    public Level GetLevel(int index)
    {
        index = Mathf.Clamp(index, 0, levels.Count-1);
        return levels[index];
    }

    private bool IsLocked()
    {
        foreach(Level level in levels)
        {
            if (!level.locked)
            {
                return false;
            }
        }
        return true;
    }
}
