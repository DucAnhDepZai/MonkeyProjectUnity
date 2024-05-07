using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GetStoryDataController : MonoBehaviour, IGetStoryData
{
    public List<Page> Get()
    {
        string json = PlayerPrefs.GetString("Story Data");
        return JsonConvert.DeserializeObject<List<Page>>(json);
    }
}
