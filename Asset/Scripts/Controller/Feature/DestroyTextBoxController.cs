using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DestroyTextBoxController : MonoBehaviour, IDestroyTextBox
{
    private void OnEnable()
    {
        TouchManager.instance.onObjectClick += DestroyTextBox;       
    }
    private void OnDisable()
    {
        TouchManager.instance.onObjectClick -= DestroyTextBox;
    }
    public void DestroyTextBox(string name)
    {
        PlayerPrefs.SetInt("isTextBoxDisplay", 0);
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }  
    }
}
