using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GetBlinkCurPageController :MonoBehaviour, IGetBlinkCurPage
{
    IGetCurNumPage getCurNumPage = new GetCurNumPageController();
   
    public int GetCurBlink()
    {
        int pageNum = getCurNumPage.Get();
        string key = "Current Blink " + pageNum;
        return PlayerPrefs.GetInt(key);
    }
}
