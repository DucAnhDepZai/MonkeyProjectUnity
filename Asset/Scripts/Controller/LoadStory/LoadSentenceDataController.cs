using Newtonsoft.Json;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSentenceDataController : MonoBehaviour, ILoadSentenceData
{
    private List<Word> globalWord;

    private void Start()
    {                 
        
    }
    public List<Word> LoadData(JSONNode pageDatas)
    {
        globalWord = JsonConvert.DeserializeObject<List<Word>>(PlayerPrefs.GetString("Global Word"));
        List<Word> list = new List<Word>();
        for (int i = 0; i < pageDatas["text"].Count; i++)
        {
            int wordId = pageDatas["text"][i]["word_id"];           
            Word thisWord = globalWord.Find(x => x.getId() == wordId);
            list.Add(thisWord);
        }
        return list;
    }
}
