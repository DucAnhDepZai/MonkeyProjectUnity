using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadPageObjectData 
{
    public List<PageObject> LoadData(JSONNode pageDatas);
    
}
