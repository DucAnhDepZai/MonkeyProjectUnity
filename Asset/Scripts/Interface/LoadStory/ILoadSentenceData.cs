using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadSentenceData 
{
    List<Word> LoadData(JSONNode pageDatas);
}
