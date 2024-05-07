using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
public class SynceAudioData 
{
    [JsonProperty]
    private float start;
    [JsonProperty]
    private float end;
    [JsonProperty]
    private string word;
    public SynceAudioData(float start, float end, string word)
    {
        this.start = start;
        this.end = end;
        this.word = word;
    }
    public SynceAudioData() { }
    public float getStart() { return start; }
    public float getEnd() { return end; }
    public string getWord() { return word; }

}
