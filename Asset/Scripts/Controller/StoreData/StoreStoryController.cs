using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StoreStoryController : IStoreStory
{
    public void Save(string data)
    {
        PlayerPrefs.SetString("Story Data", data);
    }
}
