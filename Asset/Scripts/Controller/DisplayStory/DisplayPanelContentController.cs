using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class DisplayPanelContentController : MonoBehaviour, IDisplayPanelContent
{
    public void Display(int i)
    {
        GameObject page = GameObject.Find("Page" + i);
        if (page != null)
        {
            GameObject panel = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/PanelContent.prefab");
            GameObject contentPagePanel = Instantiate(panel, page.transform);
            contentPagePanel.name = "ContentPanel" + i;
        }

    }
}
