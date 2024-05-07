using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LoadGlobalWordManager : MonoBehaviour
{
    private ILoadGlobalWordData loadStory;
    private IStoreGlobalWord storeGlobalWord;
    private void Awake()
    {
        loadStory = gameObject.GetComponent<ILoadGlobalWordData>();
        storeGlobalWord = new StoreGlobalWordController();
    }
    void Start()
    {
        string data = loadStory.LoadData();
        storeGlobalWord.Save(data);
    }
}
