using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[JsonObject(MemberSerialization.OptIn)]
public abstract class BasePage
    {
    [JsonProperty]
    protected int order;
    [JsonProperty]
    protected List<PageObject> pageObjets;
    [JsonProperty]
    protected List<Blink> blinks;
    [JsonProperty]
    protected List<Word> sentences;
    [JsonProperty]
    protected string bgPath;

    public abstract void SetOrder(int order);
    public abstract int GetOrder();
    public abstract List<PageObject> GetPageObjects();
    public abstract void SetPageObjects(List<PageObject> pageObjects);
    public abstract List<Word> GetSentences();
    public abstract void SetSentences(List<Word> sentences);
    public abstract List<Blink> GetBlinks();
    public abstract void SetBlinks(List<Blink> blinks);      
    public abstract string GetBgPath();
    public abstract void SetBgPath(string bgPath);

}

