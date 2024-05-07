using SimpleJSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LoadWordDataController : MonoBehaviour, ILoadWordData
{
    private ILoadAudioData loadAudioData;
    
    private void Awake()
    {
        loadAudioData = gameObject.GetComponent<ILoadAudioData>();
        
    }
    public List<Word> LoadData(string[] jsonPaths)
    {
        List<Word> globalWord = new List<Word>();
        foreach (string jsonPath in jsonPaths)
        {
            string json = File.ReadAllText(jsonPath);
            JSONNode wordDatas = JSON.Parse(json);
            int wordId = wordDatas["word_id"];
            string text = wordDatas["text"];
            string path = Path.Combine("Assets\\word", wordDatas["path_word"]);
            path = path.Substring(0, path.Length - 4);
            //temporary solution for 1 page
            Audio audio = loadAudioData.LoadData(wordDatas["audio"][0], path);
            Word newWord = new Word(wordId, text, path, audio);
            globalWord.Add(newWord);
        }

        return globalWord;

    }
}
