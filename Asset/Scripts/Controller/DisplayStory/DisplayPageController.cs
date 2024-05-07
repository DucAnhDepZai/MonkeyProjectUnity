using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPageController : MonoBehaviour, IDisplayPage
{
    IGetStoryData getStoryData;
    IDisplayObject displayObject;
    IDisplayBackground displayBackground;
    IDisplayTextContent displayTextContent;
    IDisplayPanelContent displayPanelContent;
    IDisplayWordOnSentence displayWordOnSentence;
    List<Page> listPage;
    private void Awake()
    {
        getStoryData = new GetStoryDataController();
        listPage = getStoryData.Get();
        displayBackground = GetComponent<IDisplayBackground>();
        displayObject = GetComponent<IDisplayObject>();
        displayTextContent = GetComponent<IDisplayTextContent>();
        displayPanelContent = GetComponent<IDisplayPanelContent>();
        displayWordOnSentence = GetComponent<IDisplayWordOnSentence>();
    }
    void Start()
    {      
        
    }      
    public void Display()
    {
        for(int  i = 0; i < listPage.Count; i++)
        {
            Page page = listPage[i];
            displayBackground.Display(i,page.GetBgPath());
            displayPanelContent.Display(i);
            displayTextContent.Display(i,page.GetSentences());
            displayWordOnSentence.Display(i,page.GetSentences());
            displayObject.Display(i,page.GetPageObjects());
        }       
    }

}
