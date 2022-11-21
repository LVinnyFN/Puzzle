using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuScreen
{
    Main,
    ChapterSelection,
}

public class MainMenu : MonoBehaviour
{
    [Header("Menus")]
    public Menu mainMenu;
    public ChapterSelectionMenu chapterSelectionMenu;
    private Menu[] menus;

    public void Awake()
    {
        menus = new Menu[2]
        {
            mainMenu,
            chapterSelectionMenu,
        };

        foreach(var menu in menus)
        {
            menu.Initialize();
            menu.mainMenu = this;
        }

        ChangeToScreen(MenuScreen.Main);
    }

    public void ChangeToScreen(MenuScreen menu) => ChangeToScreen((int)menu);
    public void ChangeToScreen(int index)
    {
        for(int i = 0; i < menus.Length; i++)
        {
            if(i == index) menus[i].Show();
            else menus[i].Hide();
        }
    }
}
