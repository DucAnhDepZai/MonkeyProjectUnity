using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class LoadStoryManager : MonoBehaviour
{
    private ILoadStoryData loadStory;
    private IStoreStory storeStory;
    private void Awake()
    {
        loadStory = gameObject.GetComponent<ILoadStoryData>();
        storeStory = new StoreStoryController();
    }
    void Start()
    {      
        string data = loadStory.LoadData();    
        storeStory.Save(data);
    }

}
