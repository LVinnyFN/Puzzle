using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionMenu : Menu
{
    private static string levelBaseName = "Level";

    public LayoutGroup levelButtonsLayout;
    public TextMeshButton levelButtonPrefab;
    private List<TextMeshButton> levelButtonsList = new List<TextMeshButton>();

    public int chapter;

    #region EDITOR
    public override void Initialize()
    {
        levelButtonsList.Clear();
        levelButtonsList.AddRange(levelButtonsLayout.GetComponentsInChildren<TextMeshButton>());
        for (int i = 0; i < levelButtonsList.Count; i++)
        {
            int level = i;
            levelButtonsList[i].AddClickListener(() => SceneLoader.LoadLevel(chapter, level));
        }
    }

    public void AddButton()
    {
        TextMeshButton button = Instantiate(levelButtonPrefab, levelButtonsLayout.transform);
        levelButtonsList.Add(button);
        button.SetText($"{levelBaseName} {levelButtonsList.Count}");
    }
    #endregion
}
