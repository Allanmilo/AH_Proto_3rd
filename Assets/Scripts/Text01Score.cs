using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text01Score : MonoBehaviour
{
    TextMeshPro textMeshPro;
    private float smallText;
    private float largeText;
    private float t;
    public float speedResize;

    void Awake()
    {
        
        textMeshPro = gameObject.GetComponent<TextMeshPro>();

        largeText = textMeshPro.fontSize;
        smallText = textMeshPro.fontSize;

         textMeshPro.alpha = 0;

    }
    
    public void StartText01()
    {
        textMeshPro.alpha = 1;
        StartCoroutine(Text01Resize(6f, 12f));
    }



protected IEnumerator Text01Resize(float smallText, float largeText)
    {
        t = 0;
        
        while (t < 1)
        {
            textMeshPro.fontSize = Mathf.Lerp(smallText, largeText, t);
            t += Time.deltaTime / speedResize;
            
            yield return null;
        }

            StartCoroutine(Text01Resize02(largeText, smallText));
    }



        protected IEnumerator Text01Resize02(float largeText, float smallText)
    {
        t = 0;
        
        while (t < 1)
        {
            textMeshPro.fontSize = Mathf.Lerp(largeText, smallText, t);
            t += Time.deltaTime / speedResize;
            
            yield return null;
        }
    }

    public void FadeTextScore01()
    {
        textMeshPro.alpha = 0;
    }

}
