using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwitcherOnOffButton : OnOffButton
{
    public GameObject[] OnObjects;
    public GameObject[] OffObjects;

    public override void OnButtonPress()
    {
        base.OnButtonPress();
        foreach (GameObject obj in OnObjects)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in OffObjects)
        {
            obj.SetActive(false);
        }
    }

}

public class OnOffButton : MonoBehaviour
{
    private void Awake()
    {
        if (TryGetComponent(out Button btn))
        {
            btn.onClick.AddListener(OnButtonPress);
        }
    }
    public virtual void OnButtonPress() { }
}
