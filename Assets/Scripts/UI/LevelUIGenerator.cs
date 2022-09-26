using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIGenerator : MonoBehaviour
{
    //[Header("References")]
    //public WorldsHandler worldsHandler;

    //[Header("Prefabs")]
    //public GameObject levelMenuPrefab;
    //public GameObject levelButtonPrefab;
    //public GameObject worldButtonPrefab;

    //[Header("Transforms")]
    //public Transform levelMenuTransform;
    //public Transform worldButtonTransform;

    //[ContextMenu("Generate Interface")]
    //public void GenerateInterface()
    //{
    //    for (int i = 0; i < worldsHandler.WorldCount; i++)
    //    {
    //        World world = worldsHandler.GetWorld(i);
    //        CreateWorldMenu(world);
    //        CreateWorldButton(world, i);
    //    }
    //}

    //private void CreateWorldMenu(World world)
    //{
    //    GameObject menuObj = Instantiate(levelMenuPrefab, levelMenuTransform);
    //    for (int i = 0; i < world.levels.Count; i++)
    //    {
    //        CreateLevelButton(menuObj.transform.GetChild(0), world, i);
    //    }
    //    menuObj.name = world.worldName.Replace(" ", "") + "Menu";
    //}

    //private void CreateWorldButton(World world, int index)
    //{
    //    GameObject worldButtonObj = Instantiate(worldButtonPrefab, worldButtonTransform);
    //    if (worldButtonObj.TryGetComponent(out WorldSelectorButton worldButton))
    //    {
    //        worldButton.SetButton(world.worldName, index);
    //    }
    //    worldButtonObj.name = world.worldName.Replace(" ", "") + "Button";
    //}

    //private void CreateLevelButton(Transform parent, World world, int index)
    //{
    //    GameObject levelButtonObj = Instantiate(levelButtonPrefab, parent);
    //    if (levelButtonObj.TryGetComponent(out LevelSelectorButton levelButton))
    //    {
    //        levelButton.SetButton(world.levels[index].levelName, index);
    //    }
    //    levelButtonObj.name = world.levels[index].levelName.Replace(" ", "") + "Button";
    //}

    //[ContextMenu("Clear Interface")]
    //public void ClearInterface()
    //{
    //    int menuChilds = levelMenuTransform.transform.childCount;
    //    int buttonChilds = worldButtonTransform.transform.childCount;

    //    for (int i = 0; i < menuChilds; i++)
    //    {
    //        DestroyImmediate(levelMenuTransform.GetChild(0).gameObject);
    //    }
    //    for (int i = 0; i < buttonChilds; i++)
    //    {
    //        DestroyImmediate(worldButtonTransform.GetChild(0).gameObject);
    //    }
    //}
}

