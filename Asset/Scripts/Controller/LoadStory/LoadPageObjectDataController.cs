using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPageObjectDataController :MonoBehaviour, ILoadPageObjectData
{
    public List<PageObject> LoadData(JSONNode pageDatas)
    {     
        List<PageObject> list = new List<PageObject>();
        
        for (int i = 0; i < pageDatas["image"].Count; i++)
        {
            for (int j = 0; j < pageDatas["image"][i]["touch"].Count; j++)
            {

                string[] vertices = pageDatas["image"][i]["touch"][j]["vertices"];
                if (vertices.Length > 0)
                {
                    int word = pageDatas["image"][i]["word_id"];                   
                    list.Add(new PageObject(word, vertices));
                }
            }
        }

        return list;
    }
}
