using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadBlinkData 
{
    List<Blink> LoadData(JSONNode pageDatas);
}
