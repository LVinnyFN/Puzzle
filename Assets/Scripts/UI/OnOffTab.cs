using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffTab : MonoBehaviour
{
    public void ActivateChild(int index)
    {
        DeactivateAllChild();
        transform.GetChild(index).gameObject.SetActive(true);
    }
    public void DeactivateAllChild()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
