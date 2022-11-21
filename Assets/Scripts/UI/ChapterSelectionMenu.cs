using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterSelectionMenu : Menu
{
    [Header("Configs")]
    public ChapterConfig[] chapterConfigs;
    public int chapters => chapterConfigs.Length;

    [Header("Buttons")]
    public LayoutGroup chapterButtonsLayout;
    public TextMeshButton chapterButtonPrefab;
    private List<TextMeshButton> chapterButtonList = new List<TextMeshButton>();

    [Header("Level Menu")]
    public RectTransform levelMenusParent;
    public LevelSelectionMenu levelSelectionMenuPrefab;
    public List<LevelSelectionMenu> levelSelectionMenuList = new List<LevelSelectionMenu>();

    #region EDITOR
    [ContextMenu("Regenerate Interface")]
    public void RegenerateInterface()
    {
        {
            foreach (LevelSelectionMenu levelSelectionMenu in levelSelectionMenuList)
            {
                if(levelSelectionMenu) DestroyImmediate(levelSelectionMenu.gameObject);
            }
            foreach (TextMeshButton button in chapterButtonList)
            {
                if(button) DestroyImmediate(button.gameObject);
            }
            levelSelectionMenuList.Clear();
            chapterButtonList.Clear();
        }

        {
            for(int i = 0; i < chapters; i++)
            {
                AddButton();
                LevelSelectionMenu levelSelectionMenu = AddLevelSelectionMenu();
                for (int j = 0; j < chapterConfigs[i].levels; j++)
                {
                    int chapter = i, level = j;
                    levelSelectionMenu.chapter = chapter;
                    levelSelectionMenu.AddButton();
                }
            }
        }
    }

    private void AddButton()
    {
        TextMeshButton button = Instantiate(chapterButtonPrefab, chapterButtonsLayout.transform);
        int menuIndex = chapterButtonList.Count;
        button.SetText($"{chapterConfigs[menuIndex].name}");
        button.AddClickListener(() => ActivateLevelSelectionMenu(menuIndex));

        chapterButtonList.Add(button);
    }
    private LevelSelectionMenu AddLevelSelectionMenu()
    {
        LevelSelectionMenu levelSelectionMenu = Instantiate(levelSelectionMenuPrefab, levelMenusParent);
        levelSelectionMenuList.Add(levelSelectionMenu);
        return levelSelectionMenu;
    }

    #endregion

    public override void Initialize()
    {
        chapterButtonList.Clear();
        chapterButtonList.AddRange(chapterButtonsLayout.GetComponentsInChildren<TextMeshButton>());
        for (int i = 0; i < chapterButtonList.Count; i++)
        {
            int index = i;
            chapterButtonList[i].AddClickListener(() => ActivateLevelSelectionMenu(index));
        }

        levelSelectionMenuList.Clear();
        levelSelectionMenuList.AddRange(GetComponentsInChildren<LevelSelectionMenu>(true));
        for (int i = 0; i < levelSelectionMenuList.Count; i++)
        {   
            levelSelectionMenuList[i].Initialize();
        }      
    }

    public void OnBackButtonPressed()
    {
        mainMenu.ChangeToScreen(0);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
        SetChapterSelectionActive(true);

        for (int i = 0; i < levelSelectionMenuList.Count; i++)
        {
            levelSelectionMenuList[i].gameObject.SetActive(false);
        }
    }
    public override void Hide()
    {
        gameObject.SetActive(false);

        for (int i = 0; i < levelSelectionMenuList.Count; i++)
        {
            levelSelectionMenuList[i].gameObject.SetActive(false);
        }
    }
    private void ActivateLevelSelectionMenu(int index)
    {
        SetChapterSelectionActive(false);
        for(int i = 0; i < levelSelectionMenuList.Count; i++)
        {
            levelSelectionMenuList[i].gameObject.SetActive(i == index);
        }
    }

    public void SetChapterSelectionActive(bool state) => chapterButtonsLayout.gameObject.SetActive(state);
}

[System.Serializable]
public struct ChapterConfig
{
    public string name;
    public int levels;
}
