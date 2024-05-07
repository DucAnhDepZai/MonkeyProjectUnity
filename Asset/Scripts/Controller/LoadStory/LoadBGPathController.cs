using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBGPathController :MonoBehaviour, ILoadBGPathData
{
    public string LoadData(JSONNode pageDatas)
    {
        string res = pageDatas["bg_img"]["path"];
        return res;
    }
}
