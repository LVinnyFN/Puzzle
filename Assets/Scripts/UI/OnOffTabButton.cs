using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffTabButton : OnOffButton
{
    [SerializeField] private OnOffTab tabsParent;

    public override void OnButtonPress()
    {
        tabsParent.ActivateChild(transform.GetSiblingIndex());
    }
}
