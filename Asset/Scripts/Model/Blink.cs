using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
public class Blink
{
    [JsonProperty]
    private int word_id;
    [JsonProperty]
    private string position;
    [JsonProperty]
    private string contentsize;
    public Blink() { }
    public Blink(int word_id, string position, string contentsize)
    {
        this.word_id = word_id;
        this.position = position;
        this.contentsize = contentsize;
    }
    public int getWordId() { return word_id; }
    public string getPosition() { return position; }
    public string getContentsize() { return contentsize;}
}
