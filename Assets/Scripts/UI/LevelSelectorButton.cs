using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.UI
{
    using Loading;

    [RequireComponent(typeof(Button))]
    public class LevelSelectorButton : MonoBehaviour
    {
        public int chapterIndex;
        public int levelIndex;
        private Button btn;
        private void Awake()
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(OnButtonPress);
        }
        public void OnButtonPress()
        {
            LevelLoader.SelectLevel(levelIndex);            
        }

        private void OnEnable()
        {
            Chapter chapter = ChapterHandler.GetChapter(chapterIndex);
            if (chapter == null) return;

            if (chapter.GetLevel(levelIndex).locked)
            {
                LockButton(true);
                return;
            }
            LockButton(false);
        }

        private void LockButton(bool value) => btn.interactable = !value;
    }
}
