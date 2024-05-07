using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPageDataController : MonoBehaviour, ILoadPageData
{
    private ILoadPageObjectData getPageObjectData;
    private ILoadBlinkData getBlinkData;
    private ILoadSentenceData getSentenceData;
    private ILoadBGPathData getBGPathData;

    private void Awake()
    {          
        getPageObjectData = gameObject.GetComponent<ILoadPageObjectData>();
        getBlinkData = gameObject.GetComponent<ILoadBlinkData>();
        getSentenceData = gameObject.GetComponent<ILoadSentenceData>();
        getBGPathData = gameObject.GetComponent<ILoadBGPathData>();
    }
    public Page LoadData(JSONNode pageDatas)
    {
        List<PageObject> pageObjets = getPageObjectData.LoadData(pageDatas);
        List<Blink> blinks = getBlinkData.LoadData(pageDatas);
        List<Word> sentences = getSentenceData.LoadData(pageDatas);
        string bgPath = getBGPathData.LoadData(pageDatas);
        Page page = new Page();
        page.SetPageObjects(pageObjets);
        page.SetBlinks(blinks);
        page.SetSentences(sentences);
        page.SetBgPath(bgPath);
        return page;
    }
}
