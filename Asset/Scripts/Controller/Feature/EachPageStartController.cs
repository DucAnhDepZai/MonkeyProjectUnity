using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EachPageStartController : MonoBehaviour
{
    Page curPage;
    int curPageNum;
    IGetCurPage getCurPage;
    IGetCurNumPage getCurNumPage = new GetCurNumPageController();
    IGetGlobalWord getGlobalWord;
    IGetBlinkCurPage getBlinkCurPage;
    IIncreaseCurNumBlink increaseCurNumBlink;
    List<Blink> listBlink;
    List<Word> globalWord;
    GameObject blinkPrefab;
   
    private void Awake()
    {     
        getCurPage = new GetCurPageController();
        getGlobalWord = new GetGlobalWordController();
        getBlinkCurPage = new GetBlinkCurPageController();
        increaseCurNumBlink = new IncreaseCurNumBlinkController();
    }
    private void OnEnable()
    {
        globalWord = getGlobalWord.Get();
        listBlink = getCurPage.Get().GetBlinks();
        curPage = getCurPage.Get();
        curPageNum = getCurNumPage.Get();
        listBlink = curPage.GetBlinks();
        PlayerPrefs.SetInt("Current Blink " + curPageNum, listBlink.Count - 1);
        blinkPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/SpineBlink.prefab");
        StartCoroutine(WaitForSentences(getCurPage.Get().GetSentences()));
    }

    private void OnDisable()
    {
        
    }


    private IEnumerator WaitForSentences(List<Word> listSentence)
    {
        for (int i = 0; i < listSentence.Count; i++)
        {
            Word cur = listSentence[i];
            yield return new WaitForSeconds(cur.getAudio().getDuration() / 1000);
        }

        Blink thisBlink = new Blink();
        int curBlinkNum = getBlinkCurPage.GetCurBlink();
        thisBlink = listBlink[curBlinkNum];
        string pos = thisBlink.getPosition();
        string size = thisBlink.getContentsize();
        string coords = pos.Trim(' ', '{', '}');
        string[] splitCoords = coords.Split(',');

        float x = float.Parse(splitCoords[0]);
        float y = float.Parse(splitCoords[1]);

        Word thisWord = globalWord.Find(x => x.getId() == thisBlink.getWordId());
        string text = thisWord.getText();
        GameObject blink = Instantiate(blinkPrefab, GameObject.Find(text).transform);
        blink.transform.localPosition = new Vector3(x, y, 0);
        blink.name = "Blink";

        coords = size.Trim(' ', '{', '}');
        splitCoords = coords.Split(',');

        x = float.Parse(splitCoords[0]);
        y = float.Parse(splitCoords[1]);

        RectTransform blinkRectTransform = blink.GetComponent<RectTransform>();
        x = x / blinkRectTransform.rect.width;
        y = y / blinkRectTransform.rect.height;
        blink.transform.localScale = new Vector3(x, y, 0);
    }
}
