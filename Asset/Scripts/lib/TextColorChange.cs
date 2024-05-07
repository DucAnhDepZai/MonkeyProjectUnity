using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextColorChange : MonoBehaviour
{
    public float startDelay;
    public float endDelay;
    public string textContent;

    private TextMeshProUGUI textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        StartCoroutine(ChangeTextColor());
    }

    private IEnumerator ChangeTextColor()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            textMesh.color = Color.red;
            textMesh.text = textContent;

            yield return new WaitForSeconds(endDelay - startDelay);

            textMesh.color = Color.black;
            textMesh.text = "";

            yield break;
        }
    }
}
