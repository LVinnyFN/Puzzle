using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.Loading
{
    public static class ChapterHandler
    {
        [SerializeField] private readonly static string chaptersPath = "Worlds"; 
        [HideInInspector] public static Chapter[] chapters;

        /// <summary>
        /// Returns the Chapter with specified index in chapters list.
        /// </summary>
        /// <returns>Returns null in case no chapters could be found.</returns>
        public static Chapter GetChapter(int chapterIndex)
        {
            if (chapters == null && !LoadChaptersFromFolder()) return null;

            chapterIndex = Mathf.Clamp(chapterIndex, 0, chapters.Length-1);
            return chapters[chapterIndex];
        }

        private static bool LoadChaptersFromFolder()
        {
            chapters = Resources.LoadAll<Chapter>(chaptersPath);

            if (chapters.Length > 0)
            {
                Debug.Log($"<color=green>{chapters.Length} capitulos carregados da pasta Resources/{chaptersPath}.</color>");
                return true;
            }
            Debug.LogWarning($"Nenhum capitulo pode ser carregado da pasta {chaptersPath}.");
            return false;
        }
    }
}
