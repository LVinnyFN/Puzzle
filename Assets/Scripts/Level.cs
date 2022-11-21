using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{    
    public void StartLevel()
    {
        gameObject.SetActive(true);
    }

    public void FinishLevel()
    {
        gameObject.SetActive(false);
    }
}
