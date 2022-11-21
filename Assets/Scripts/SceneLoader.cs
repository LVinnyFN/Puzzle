using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static int currentChapter { get; private set; }
    public static int currentLevel { get; private set; }

    public static void LoadLevel(int chapter, int level)
    {
        currentChapter = chapter;
        currentLevel = level;

        int sceneIndex = chapter + level + 1;
        if (sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(chapter + level + 1);
        }
        else LoadMainMenu();
    }
    public static void ReloadLevel() => LoadLevel(currentChapter, currentLevel);

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
