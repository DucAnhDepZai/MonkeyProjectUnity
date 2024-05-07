using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
public class PageObject
{
    [JsonProperty]
    private int wordID { get; set; }
    [JsonProperty]
    private string[] vertices { get; set; }

    public PageObject() { }
    public PageObject(int wordID, string[] vertices)
    {
        this.wordID = wordID;
        this.vertices = vertices;
    }
    public int getWordID { get { return wordID; } }
    public string[] getVertices { get {  return vertices; } }

}
