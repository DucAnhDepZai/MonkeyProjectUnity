using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBlinkDataController :MonoBehaviour, ILoadBlinkData
{
    public List<Blink> LoadData(JSONNode pageDatas)
    {
        List<Blink> list = new List<Blink>();
        for (int i = 0; i < pageDatas["image"].Count; i++)
        {
            for (int j = 0; j < pageDatas["image"][i]["touch"].Count; j++)
            {

                string[] vertices = pageDatas["image"][i]["touch"][j]["vertices"];
                if (vertices.Length == 0)
                {
                    int wordId = pageDatas["image"][i]["word_id"];
                    string pos = pageDatas["image"][i]["position"];
                    string size = pageDatas["image"][i]["contentsize"];
                    list.Add(new Blink(wordId, pos, size));
                }
            }
        }
        
        return list;
    }
    
}
