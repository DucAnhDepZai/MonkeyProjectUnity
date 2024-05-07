using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBackGroundController : MonoBehaviour, IDisplayBackground
{
    public void Display(int i, string path)
    {
        GameObject page = GameObject.Find("Page" + i);
        GameObject background = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Background.prefab");
        GameObject thisBg = Instantiate(background, page.transform);
        thisBg.name = "PageBackground";
        Image pageImg = thisBg.GetComponent<Image>();
        string bgpath = "Assets/" + path;
        pageImg.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(bgpath);
    }
}
