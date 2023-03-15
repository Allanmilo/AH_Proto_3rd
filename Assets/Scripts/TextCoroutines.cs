using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextCoroutines : MonoBehaviour
{
    // Setting text fields.
    [SerializeField] protected TextMeshPro girlTalk;
    [SerializeField] protected TextMeshPro boyTalk;
                     protected TextMeshPro allTalk;

                     public TextMeshPro allTalk_Public;


    // used by OpenText.
    [SerializeField]protected RectTransform girlsTextBox;
    [SerializeField]protected RectTransform boysTextBox;
    protected RectTransform maskingTextBox;
    public Vector2 width01;
    public Vector2 width02;

    protected string trashTalk01;
    protected string trashTalk02;
    private string sayStuff;

    protected bool fade;
    protected bool type;
    protected bool slide;
    protected bool CR;

    public bool no_Fade;

    public float showAlpha;
    GameObject _textCountDown;
    CountDown countDown;

    protected bool first_Font;

    protected bool second_Font;

    
    [SerializeField] protected TMP_FontAsset _second_Font;

    [SerializeField] protected TMP_FontAsset _first_Font;


    public GameObject AHScriptManager;
    public AHManager _AHManager;


    void Awake()
    {
        AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
        _AHManager = AHScriptManager.GetComponent<AHManager>();

         _textCountDown = GameObject.FindGameObjectWithTag("TextCountDown");
        countDown = _textCountDown.GetComponent<CountDown>();

        // countDown.Testing();

        width01 = new Vector2(0, 1);
        width02 = new Vector2(10, 1);
       
        fade = false;
        type = false;
        slide = false;

        no_Fade = false;
        
    }

   

    protected void TT1() // Sets text to trashTalk01.
    {
        allTalk.text = trashTalk01;
        sayStuff = allTalk.text;
    }


    protected void TT2() // Sets text to trashTalk02.
    {
        allTalk.text = trashTalk02;
        sayStuff = allTalk.text;
    }


protected IEnumerator StartAnimation()
  {
      string[] array = sayStuff.Split(' ');
      allTalk.text = array[0]; 
      for( int i = 1 ; i < array.Length ; ++ i)
      {     
          allTalk.alpha = 1;
          yield return new WaitForSeconds(.3f);
          allTalk.text += " " + array[i]; 
      }
  }


      protected IEnumerator FadeInCR() // Fades text in from zero alpha to full alpha.
{
    Debug.Log("Six");

    float duration01 = 1f;
    float currentTime01 = 0f;

    while(currentTime01 < duration01)
    { 
        allTalk.text = sayStuff;
        float alpha = Mathf.Lerp(0f, 1f, currentTime01/duration01);
        Debug.Log("Alpha = " + alpha);
        allTalk.color = new Color(allTalk.color.r, allTalk.color.g, allTalk.color.b, alpha);
        Debug.Log("Color = " + allTalk.color );
        Debug.Log("Text is " + allTalk.text);
        currentTime01 += Time.deltaTime;
        yield return null;
         
    }
}

protected IEnumerator FadeOutCR() // Fades text out from full alpha to zero alpha.
{
    if(fade)
    {
        Debug.Log("Five");

        fade = false;
        yield return StartCoroutine(FadeInCR());
    }

    if(type)
    {
        type = false;
        yield return StartCoroutine(StartAnimation());
    }

    if(slide)
    {
        slide = false;
        yield return StartCoroutine(OpenText());
    }
    
         Debug.Log("Fade out here.");
    float duration = 1f; 
    float currentTime = 0f;


                if(!no_Fade)
                {
                        while(currentTime < duration)
                        {
                            float alpha = Mathf.Lerp(1f, 0f, currentTime/duration);
                            allTalk.color = new Color(allTalk.color.r, allTalk.color.g, allTalk.color.b, alpha);
                            currentTime += Time.deltaTime;
                            yield return null;
                        }
                
                }

}

    protected IEnumerator OpenText() // Sliding text reveal using the width of recttransform.
    {
    float duration01 = 2f;
    float currentTime01 = 0f;
    allTalk.alpha = 1f;
    
        while(currentTime01 < duration01)
        { 
        Vector2 newWidth = Vector2.Lerp(width01, width02, currentTime01/duration01);
            maskingTextBox.sizeDelta = newWidth;
            currentTime01 += Time.deltaTime;
            yield return null;
        }    
    }
    
    
    protected IEnumerator Talk02Wait(float wait, char effect, bool fader) // Runs second line of text (trashTalk02).
				{
                    Debug.Log("Talk 2 wait NOW");
                

					yield return new WaitForSeconds(wait);
					TT2();

					if(effect == 't')
					{
						type = true;
					}

					if(effect == 'f')
					{
						fade = true;
					}

					if(effect == 's')
					{
						slide = true;
					}
						
                    CR = true;

                    no_Fade = fader;
                     Debug.Log("Before");
					StartCoroutine(FadeOutCR());
                    //yield return new WaitForSeconds(1);
                    Debug.Log("after");

                  // _AHManager.Start_The_Count();
                   // if(!no_Fade)
                   // {
                  //     Debug.Log("Two");

                   // countDown.StartCount();
                    //StartCoroutine(countDown.MathfSin(3));
                 //   }
                  //  Debug.Log("Three");
				}

}
