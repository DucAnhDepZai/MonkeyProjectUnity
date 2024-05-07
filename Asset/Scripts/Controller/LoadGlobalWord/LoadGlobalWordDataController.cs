using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class LoadGlobalWordDataController : MonoBehaviour, ILoadGlobalWordData
{
    private ILoadWordData loadWordData;   
    private void Awake()
    {
        loadWordData = gameObject.GetComponent<ILoadWordData>();      
    }
    public string LoadData()
    {
        List<Word> globalWord = new List<Word>();
        string path = "E:\\Data\\StaticStory\\word";
        string[] wordDirectory = Directory.GetDirectories(path);
        foreach (var item in wordDirectory)
        {
            string[] listJson = Directory.GetFiles(Path.Combine(path, item), "*.json");
            globalWord.AddRange(loadWordData.LoadData(listJson));
        }
        string data = JsonConvert.SerializeObject(globalWord);
        return data;
    }
   
}
