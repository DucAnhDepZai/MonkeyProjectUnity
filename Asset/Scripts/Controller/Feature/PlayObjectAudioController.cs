using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayObjectAudioController : MonoBehaviour, IPlayObjectAudio
{
    IGetGlobalWord getGlobalWord;
    List<Word> globalWord;  
    
    private void Awake()
    {
        getGlobalWord = new GetGlobalWordController();
    }
    private void Start()
    {
        globalWord = getGlobalWord.Get();
       
    }
    private void OnEnable()
    {
        TouchManager.instance.onObjectClick += PlayAudio;
    }
    private void OnDisable()
    {
        TouchManager.instance.onObjectClick -= PlayAudio;
    }
    public void PlayAudio(string name)
    {
       
        if(this.name == name)
        {
            Word thisWord = globalWord.Find(x => x.getText() == gameObject.name);
            AudioSource thisAudio = this.gameObject.GetComponent<AudioSource>();
            thisAudio.clip = AssetDatabase.LoadAssetAtPath<AudioClip>(thisWord.getAudio().getPath());
            thisAudio.Play();
        }
       
    }
}
