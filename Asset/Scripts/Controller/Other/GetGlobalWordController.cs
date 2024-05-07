using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGlobalWordController : MonoBehaviour, IGetGlobalWord
{
   public List<Word> Get()
    {
        string data = PlayerPrefs.GetString("Global Word");
        return JsonConvert.DeserializeObject<List<Word>>(data);
    }
}
