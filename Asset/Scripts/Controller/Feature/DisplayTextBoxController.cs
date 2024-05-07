using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class DisplayTextBoxController : MonoBehaviour, IDisplayTextBox
{
    GameObject textBoxPrefab;
    List<Word> globalWord;
    private void Awake()
    {
        textBoxPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/TextBox.prefab");
        globalWord = JsonConvert.DeserializeObject<List<Word>>(PlayerPrefs.GetString("Global Word"));
    }
    private void OnEnable()
    {
        TouchManager.instance.onObjectClick += DisplayTextBox;
    }
    private void OnDisable()
    {
        TouchManager.instance.onObjectClick -= DisplayTextBox;
    }
    public void DisplayTextBox(string name)
    {      
        if(this.name == name)
        StartCoroutine(RunDisplay());
    }
    private IEnumerator RunDisplay()
    {
        GameObject textBox = Instantiate(textBoxPrefab, Input.mousePosition, Quaternion.identity);
        PlayerPrefs.SetInt("isTextBoxDisplay", 1);
        textBox.name = "TextBox";
        TextMeshProUGUI text = textBox.GetComponentInChildren<TextMeshProUGUI>();

        Word thisWord = globalWord.Find(x => x.getText() == this.gameObject.name);

        text.text = thisWord.getText();
        textBox.transform.SetParent(this.gameObject.transform);
        textBox.transform.localPosition = Input.mousePosition;
        textBox.transform.localScale = Vector3.zero;
        while (textBox.transform.localScale != Vector3.one)
        {
            textBox.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            yield return new WaitForSeconds(0.027f);
        }
        float delayTime = (float)thisWord.getAudio().getDuration() / 1000 + 1f;
        yield return new WaitForSeconds(delayTime);
        DestroyTextBox();
        PlayerPrefs.SetInt("isTextBoxDisplay", 0);
    }

    private void DestroyTextBox()
    {
        PlayerPrefs.SetInt("isTextBoxDisplay", 0);
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
    }
}
