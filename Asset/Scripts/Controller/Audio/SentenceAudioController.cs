using BookCurlPro;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SentenceAudioController : MonoBehaviour
{
   
    private void OnEnable()
    {      
        BookPro.BookFlip += PlaySentencesAudio;
    }
    private void OnDisable()
    {
 
        BookPro.BookFlip -= PlaySentencesAudio;
    }
    public void PlaySentencesAudio()
    {
        float delayTime = 0;
        //Debug.Log("Child :"+gameObject.transform.childCount);
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {           
            AudioSource sentencesAudio = gameObject.transform.GetChild(i).GetComponent<AudioSource>();
            StartCoroutine(PlayAudio(sentencesAudio,delayTime));
            delayTime = sentencesAudio.clip.length;
        }
    }

    private IEnumerator PlayAudio(AudioSource audio, float delayTime)
    {     
        yield return new WaitForSeconds(delayTime);
        audio.Play();
       
        
    }

   
}
