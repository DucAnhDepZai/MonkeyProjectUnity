using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWordOnSentenceController : MonoBehaviour, IDisplayWordOnSentence
{
    GameObject textPrefab;
    private void Awake()
    {
        textPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/TextPage.prefab");
    }
    public void Display(int pageNum, List<Word> sentences)
    {     
        for (int i = 0; i < sentences.Count; i++)
        {
            Word pageWord = sentences[i];
            GameObject textPagePanel = GameObject.Find("TextPanel p" + pageNum + "s" + i);
            if (textPagePanel != null)
            {
                List<SynceAudioData> golSyncDatas = pageWord.getAudio().getSynceDatas();
                foreach (var item in golSyncDatas)
                {
                    GameObject text = Instantiate(textPrefab, textPagePanel.transform);
                    text.name = item.getWord();
                    TextMeshProUGUI textComp = text.GetComponent<TextMeshProUGUI>();
                    textComp.text = item.getWord();
                }
                LayoutRebuilder.ForceRebuildLayoutImmediate(textPagePanel.GetComponent<RectTransform>());
            }

        }
    }
}
