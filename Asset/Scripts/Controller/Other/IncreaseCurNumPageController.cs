using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class IncreaseCurNumPageController : MonoBehaviour, IIncreaseCurNumPage
{
    private IGetCurNumPage getCurPageNum;

    private void Awake()
    {
        getCurPageNum = new GetCurNumPageController();
    }

    public void Increase()
    {
        getCurPageNum = new GetCurNumPageController();      
        PlayerPrefs.SetInt("Current Page", getCurPageNum.Get() - 1);
    }
    private int GetCurPageNum()
    {
        return PlayerPrefs.GetInt("Current Page");
    }
}
