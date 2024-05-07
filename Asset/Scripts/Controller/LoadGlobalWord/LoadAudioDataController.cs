using SimpleJSON;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadAudioDataController : MonoBehaviour,ILoadAudioData
{
    private ILoadSynceAudioData loadSynceAudioData;
    private void Awake()
    {
        loadSynceAudioData = gameObject.GetComponent<ILoadSynceAudioData>();
    }

    public Audio LoadData(JSONNode audioDatas, string prePath)
    {

        int id = audioDatas["id"];
        float duration = audioDatas["duration"];
        string path = Path.Combine(prePath, audioDatas["link"]);
        List<SynceAudioData> syncDatas = new List<SynceAudioData>();
        for (int i = 0; i < audioDatas["sync_data"].Count; i++)
        {
            syncDatas.Add(loadSynceAudioData.LoadData(audioDatas["sync_data"][i]));
        }
        Audio audio = new Audio(id, duration, path, syncDatas);
        return audio;
    }
}
