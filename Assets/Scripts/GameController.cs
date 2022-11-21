using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance { get { if (!instance) instance = new GameObject("GameController").AddComponent<GameController>(); return instance; } }


    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }


    private void Update()
    {
        CheckInputs();
    }
    public void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.R)) SceneLoader.ReloadLevel();
        if (Input.GetKeyDown(KeyCode.Escape)) SceneLoader.LoadMainMenu();
    }

    public void OnPlayerReachGoal() => StartCoroutine(OnPlayerReachGoalCoroutine());

    private IEnumerator OnPlayerReachGoalCoroutine()
    {
        Debug.Log("Player won! I will do something about it soon.");

        yield return new WaitForSeconds(2f);

        int chapter = SceneLoader.currentChapter;
        int level = SceneLoader.currentLevel + 1;

        SceneLoader.LoadLevel(chapter, level);
    }
}
