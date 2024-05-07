using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCurNumPageController : MonoBehaviour, ISetCurNumPage
{
    public void Set(int curNum)
    {
        PlayerPrefs.SetInt("Current Page", curNum);
    }
}
