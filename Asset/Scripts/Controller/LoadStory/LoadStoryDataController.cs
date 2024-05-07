using SimpleJSON;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class LoadStoryDataController : MonoBehaviour, ILoadStoryData
{
    private string dirPath;
    private ILoadPageData getPageData;
    private void Awake()
    {
        getPageData = gameObject.GetComponent<ILoadPageData>();
        dirPath = "E:\\Data\\StaticStory";
        //
    }
    public string LoadData()
    {
        List<BasePage> listPage = new List<BasePage>();
        string[] listJson = Directory.GetFiles(dirPath, "*.json");
        string path = "E:\\Data\\StaticStory\\4131_page_";
        for (int i = 1; i <= listJson.Length; i++)
        {
            string thisPath = path + i + ".json";
            string jsonText = File.ReadAllText(thisPath);    
            JSONNode node = JSON.Parse(jsonText);
            Page data = getPageData.LoadData(node);
            listPage.Add(data);
        }
        string json = JsonConvert.SerializeObject(listPage);
        return json;       
    }
    
}
