using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class IncreaseCurNumBlinkController : MonoBehaviour, IIncreaseCurNumBlink
{
    IGetCurNumPage getCurNumPage = new GetCurNumPageController();
    public void Increase()
    {     
        int pageNum = getCurNumPage.Get();
        string key = "Current Blink " + pageNum;
        PlayerPrefs.SetInt(key,PlayerPrefs.GetInt(key) - 1);
    }
}
