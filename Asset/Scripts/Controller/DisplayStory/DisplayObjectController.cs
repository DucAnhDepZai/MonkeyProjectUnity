using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DisplayObjectController : MonoBehaviour, IDisplayObject
{
    GameObject objectPrefab;
    IGetGlobalWord getGlobalWord;
    List<Word> globalWord;
    private void Awake()
    {
        objectPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/ObjectPrefabs.prefab");
        getGlobalWord = new GetGlobalWordController();
        globalWord = getGlobalWord.Get();
    }

    public void Display(int pageNum, List<PageObject> pageObjects)
    {        
        for (int i = 0; i < pageObjects.Count; i++)
        {
            PageObject item = pageObjects[i];
            Vector2[] touchPoints = CreateTouchPoints(item.getVertices);
            CreateEdgeCollider(touchPoints, objectPrefab);
            GameObject page = GameObject.Find("Page" + pageNum);
            if(page != null)
            {
                GameObject prefab = Instantiate(objectPrefab, page.transform);                
                Word thisWord = globalWord.Find(x => x.getId() == item.getWordID);
                prefab.name = thisWord.getText();
            }
           
        }
    }
    private Vector2[] CreateTouchPoints(string[] verticesData)
    {
        Vector2[] touchPoints = new Vector2[verticesData.Length];

        for (int i = 0; i < verticesData.Length; i++)
        {
            string coords = verticesData[i].Trim(' ', '{', '}');
            string[] splitCoords = coords.Split(',');
            float x = float.Parse(splitCoords[0]);
            float y = float.Parse(splitCoords[1]);
            touchPoints[i] = new Vector2(x, y);
        }

        return touchPoints;
    }
    private void CreateEdgeCollider(Vector2[] touchPoints, GameObject colliderObject)
    {
        PolygonCollider2D polyCollider = colliderObject.GetComponent<PolygonCollider2D>();
        polyCollider.points = touchPoints;
    }
}
