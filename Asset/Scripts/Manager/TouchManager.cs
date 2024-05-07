using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using Newtonsoft.Json;

public class TouchManager : MonoBehaviour
{
    public static TouchManager instance = new TouchManager();
    public event Action<string> onObjectClick;
    
    private void Awake()
    {
        PlayerPrefs.SetInt("hadLoad",0);
        PlayerPrefs.SetInt("isChange", 0);
    }
    private void Start()
    {      
        
    }
    private void OnMouseDown()
    {
        TouchManager.instance.OnObjectClick(gameObject.name);      
    }
    public void OnObjectClick(string name)
        {
            onObjectClick?.Invoke(name);
            
        }
}
