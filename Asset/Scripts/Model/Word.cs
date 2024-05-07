
using Newtonsoft.Json;
using System;
[JsonObject(MemberSerialization.OptIn)]
public class Word 
{
    [JsonProperty]
    private int id;
    [JsonProperty]
    private string text;
    [JsonProperty]
    private string path;
    [JsonProperty]
    private Audio audio;
    public Word(int id, string text, string path, Audio audio)
    {
        this.id = id;
        this.text = text;
        this.path = path;
        this.audio = audio;
    }
    public Word()
    {
        
    }
    public int getId() { return id; }
    public string getText() { return text; }
    public string getPath() { return path; }
    public Audio getAudio() { return audio; }
    public void setId(int id) { this.id = id;}
    public void setText(string text) { this.text = text; }
    public void setAudio(Audio audio) {  this.audio = audio; }
    public void setPath(string path) {  this.path = path; }


}
