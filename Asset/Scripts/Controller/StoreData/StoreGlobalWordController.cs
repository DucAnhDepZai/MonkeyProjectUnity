using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StoreGlobalWordController : MonoBehaviour, IStoreGlobalWord
{
    public void Save(string data)
    {
        PlayerPrefs.SetString("Global Word", data);
    }
}
