using BookCurlPro;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeSentenceRedColorController : MonoBehaviour, IChangeSentenceColor
{
    IGetCurPage getCurPage;
    int pageNum;
    List<SynceAudioData> listSync;
    private void Awake()
    {
        getCurPage = new GetCurPageController();
    }
    private void OnEnable()
    {
        BookPro.BookFlip += ChangeWordColor;
    }
    private void OnDisable()
    {

        BookPro.BookFlip -= ChangeWordColor;
    }
   
    public void ChangeWordColor()
    {
        StartCoroutine(ChangeColor());
    }
    private IEnumerator ChangeColor()
    {
         for (int i = 0; i < gameObject.transform.childCount; i++)
         {

            listSync = getCurPage.Get().GetSentences()[i].getAudio().getSynceDatas();
            TextMeshProUGUI[] listText = gameObject.transform.GetChild(i).GetComponentsInChildren<TextMeshProUGUI>();
            float delayTime = 0;
            for (int j = 0; j < listText.Length; j++)
            {
                delayTime = (listSync[j].getEnd() - listSync[j].getStart()) / 1000;
                listText[j].color = Color.red;
                yield return new WaitForSeconds(delayTime);
                listText[j].color = Color.black;
                
            }

         }
    }
}
