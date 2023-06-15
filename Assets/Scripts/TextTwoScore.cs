using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTwoScore : MonoBehaviour
{
    TextMeshPro textMeshPro;
    private float smallText;
    private float largeText;
    private float t;
    public float speedResize;

    float r_C;
    float b_C;
    float g_C;

    public float a_C0 = 0f;
    public float a_C255 = 255f;

    void Awake()
    {
        textMeshPro = gameObject.GetComponent<TextMeshPro>();
        
        largeText = textMeshPro.fontSize;
        smallText = textMeshPro.fontSize;

        r_C = textMeshPro.color.r;
        b_C = textMeshPro.color.b;
        g_C = textMeshPro.color.g;
        textMeshPro.color = new Color(r_C, g_C, b_C, a_C0);

    }
    
    public void StartText02()
    {
        Debug.Log("StartText02");
        
        textMeshPro.color = new Color(r_C, g_C, b_C, a_C255);
        StartCoroutine(Text02Resize(6f, 12f));
    }

protected IEnumerator Text02Resize(float smallText, float largeText)
    {
        t = 0;
        
        while (t < 1)
        {
            textMeshPro.fontSize = Mathf.Lerp(smallText, largeText, t);
            t += Time.deltaTime / speedResize;
            
            yield return null;
        }

            StartCoroutine(Text02Resize02(largeText, smallText));
    }

        protected IEnumerator Text02Resize02(float largeText, float smallText)
    {
        t = 0;
        
        while (t < 1)
        {
            textMeshPro.fontSize = Mathf.Lerp(largeText, smallText, t);
            t += Time.deltaTime / speedResize;
            
            yield return null;
        }
    }

        public void FadeTextScore02()
    {
        textMeshPro.alpha = 0;
    }

}

