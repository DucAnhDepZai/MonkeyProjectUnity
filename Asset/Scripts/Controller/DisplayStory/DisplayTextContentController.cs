using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DisplayTextContentController : MonoBehaviour, IDisplayTextContent
{
    GameObject panel;
    private void Awake()
    {
        panel = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/PanelTextPage.prefab");
    }
    public void Display(int pageNum, List<Word> sentences)
    {
        for (int i = 0; i < sentences.Count; i++)
        {
            
            GameObject contentPagePanel = GameObject.Find("ContentPanel" + pageNum);
            if (contentPagePanel != null)
            {
                GameObject textPagePanel = Instantiate(panel, contentPagePanel.transform);
                textPagePanel.name = "TextPanel p" + pageNum + "s" + i;
                string audioPath = sentences[i].getAudio().getPath();
                AudioSource audioSource = textPagePanel.GetComponent<AudioSource>();
                audioSource.clip = AssetDatabase.LoadAssetAtPath<AudioClip>(audioPath);

            }
        }
    }
}
