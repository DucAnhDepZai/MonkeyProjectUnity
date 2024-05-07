using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class WordPopUpController : MonoBehaviour, IWordPopUp
{
    string text;
    TextMeshProUGUI textMeshPro;
    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        text = ClearText(gameObject.name);
    }
    private void OnEnable()
    {
        TouchManager.instance.onObjectClick += PopUp;
    }
    private void OnDisable()
    {
        TouchManager.instance.onObjectClick -= PopUp;
    }
    public void PopUp(string text)
    {       
        if (PlayerPrefs.GetInt("isChange") == 0)
        {
            if (this.text == text)StartCoroutine(ChangeTextColor());
        }
            

    }
    private IEnumerator ChangeTextColor()
    {
        PlayerPrefs.SetInt("isChange", 1);
        textMeshPro.color = Color.red;
        int n = 3;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                textMeshPro.transform.localPosition += new Vector3(0, 2, 0);
                yield return new WaitForSeconds(0.025f);
            }
            for (int j = 0; j < 10; j++)
            {
                textMeshPro.transform.localPosition += new Vector3(0, -2f, 0);
                yield return new WaitForSeconds(0.025f);
            }
        }
        //LayoutRebuilder.ForceRebuildLayoutImmediate(textPanel.GetComponent<RectTransform>());
        textMeshPro.color = Color.black;
        PlayerPrefs.SetInt("isChange", 0);
    }
    private string ClearText(string s)
    {

        return Regex.Replace(s, "[.!?:]", "");
    }
}
