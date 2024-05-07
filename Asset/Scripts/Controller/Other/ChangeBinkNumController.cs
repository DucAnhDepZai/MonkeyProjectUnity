using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ChangeBinkNumController : IChangeBlinkNum
{
    
    public void ChangeBlinkNum(int n, int pageNum)
    {
        string key = "Current Blink " + pageNum;
        PlayerPrefs.SetInt(key,GetCurBlinkNum(pageNum) + n);
    }
    private int GetCurBlinkNum(int pageNum)
    {
        string key = "Current Blink " + pageNum;
        return PlayerPrefs.GetInt(key);
    }
}
