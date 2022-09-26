using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

namespace Puzzle.Loading
{
    public static class LevelLoader
    {
        private static Chapter selectedChapter;
        private static Level selectedLevel;
        public static Chapter SelectedChapter { get { return selectedChapter; } }
        public static Level SelectedLevel { get { return selectedLevel; } }

        public static void SelectChapter(Chapter chapter)
        {
            selectedChapter = chapter;
            if (selectedLevel != null)
            {
                selectedLevel = null;
            }
        }

        public static void SelectLevel(int levelIndex)
        {
            selectedLevel = selectedChapter.GetLevel(levelIndex);
            if (selectedChapter == null) return;

            LoadLevel(selectedChapter, selectedLevel);
        }

        public static void LoadLevel(Chapter chapter, Level level)
        {
            int sceneIndex = chapter.sceneIndex;
            if (sceneIndex < 0 || sceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                Debug.LogWarning($"Não existe uma cena com o indice {sceneIndex}.");
                sceneIndex = Mathf.Clamp(sceneIndex, 0, SceneManager.sceneCountInBuildSettings - 1);
            }

            SceneManager.LoadSceneAsync(sceneIndex).completed += (aOp) => OnSceneLoad();
        }       

        private static void OnSceneLoad()
        {
            Debug.Log("Loading terminou");

            var teste = GameObject.FindGameObjectWithTag("Level");
            foreach(Transform child in teste.transform)
            {
                child.gameObject.SetActive(false);
            }
            teste.transform.GetChild(selectedLevel.levelIndex).gameObject.SetActive(true);
        }
    }
}
