using SimpleJSON;
using UnityEngine;

public class LoadSynceAudioDataController : MonoBehaviour, ILoadSynceAudioData
{
    public SynceAudioData LoadData(JSONNode syncData)
    {
        float start = syncData["s"];
        float end = syncData["e"];
        string word = syncData["w"];
        SynceAudioData tmp = new SynceAudioData(start, end, word);
        return tmp;
    }
}
