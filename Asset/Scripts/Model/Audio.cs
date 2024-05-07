
using Newtonsoft.Json;
using System.Collections.Generic;

[JsonObject(MemberSerialization.OptIn)]
public class Audio 
{
    [JsonProperty]
    private int id;
    [JsonProperty]
    private float duration;
    [JsonProperty]
    private string path;
    [JsonProperty]
    private List<SynceAudioData> syncDatas;
    public Audio(int id,float duration, string path,List<SynceAudioData> audioData)
    {
        this.id = id;
        this.duration = duration;
        this.path = path;        
        this.syncDatas = audioData;
    }
    public Audio() { }
    public int getId() { return id; }
    public float getDuration() { return duration; }
    public string getPath() { return path; } 
    public List<SynceAudioData> getSynceDatas() {  return syncDatas; }
}
