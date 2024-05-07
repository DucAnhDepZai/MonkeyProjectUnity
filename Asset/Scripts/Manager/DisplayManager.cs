using UnityEditor;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Collections;
using Newtonsoft.Json;

public class DisplayManager : MonoBehaviour
{    
    IDisplayPage displayPage;
    ISetCurNumPage setCurNumPage;
    private void Awake()
    {            
        displayPage = GetComponent<IDisplayPage>();
        setCurNumPage = new SetCurNumPageController();
    }
    private void Start()
    {
        setCurNumPage.Set(0);
        displayPage.Display();

    }    
     
}
