using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DisplayBlinkController : MonoBehaviour
{
    IGetCurPage getCurPage;
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
        globalWord = getGlobalWord.Get();
        listBlink = getCurPage.Get().GetBlinks();
        blinkPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/SpineBlink.prefab");
        
    }
    
    private void OnEnable()
    {
        TouchManager.instance.onObjectClick += DisplayBlink;
    }
    private void OnDisable()
    {
        TouchManager.instance.onObjectClick -= DisplayBlink;
    }
    private void DisplayBlink(string name)
    {
        if (this.name == name)
        {
            for(int i = 0;i < listBlink.Count;i++)
            {
               Word thisWord = globalWord.Find(x => x.getId() == listBlink[i].getWordId());
               string text = thisWord.getText();
                int curBlinkNum = getBlinkCurPage.GetCurBlink();
                if (text == name && i == curBlinkNum)
                {
                    increaseCurNumBlink.Increase();
                    ShowBlink();
                }
            }
            
        }
    }
    private void ShowBlink()
    {     
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
