using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GetCurNumPageController : MonoBehaviour, IGetCurNumPage
{
    public int Get()
    {
        return PlayerPrefs.GetInt("Current Page");
    }    
}

