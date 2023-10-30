using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//using System.Diagnostics;

public class CountDown : MonoBehaviour
{
    public TextMeshPro Nums;
    public float speedUpDown = 1;
    public float distanceUpDown = 1;
    public float time;
    public float sin;
    Vector3 tranPos;

    float beginTime;
    float endTime;
    public float totalTime;
    public bool startTimer;
    public int count;

    float cycle;

    Vector2 minScale;
	Vector2 maxScale;
    Vector2 startScale;
	public float speed = .05f;
	public float duration = 10f;

    public float dropDelay;
    public GameObject startingPuck;
    public PuckGlow puckGlow;
    
	private Vector2 puckPos;
    private Vector2 goalPos;
     SpriteRenderer _spriteRender;
    public float fadeOutTime = 3f;
    public Color endColor;
    public Color startColor;

    public bool setCDPos;
    public RectTransform countDownRT;

    GameObject AHScriptManager;
    AHScriptManager _AHManager;

    bool stopCO;

    //StackTrace stackTrace;
    
    public int _counting;

    public float delay;

    public Sprite paddle_Neutral;

 void Start () 
    {   
        _counting = 0;

        delay = 3f;

        AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
        _AHManager = AHScriptManager.GetComponent<AHScriptManager>();

        stopCO = _AHManager.restoreMenuRunning;
        beginTime = 0f;
        endTime = 0f;
        totalTime = 0f;
        startTimer = false;
        totalTime = 100;
        time = 0.0f;
        cycle = .75f;

        Nums.outlineWidth = .1f;
        Nums.outlineColor = new Color32(69, 178, 45, 255);

        //puckPos = new Vector2(0f, 0f);

        RectTransform countDownRT = GetComponent<RectTransform>();

        _spriteRender = startingPuck.GetComponent<SpriteRenderer>();
		
        puckPos = new Vector2(0f, -3.5f);
        goalPos = new Vector2(0f, -3.5f);
        

        startingPuck.SetActive(false);
        startingPuck.transform.position = puckPos;
        startingPuck.transform.hasChanged = false;
        
    }


    void Update()
    {   

        countDownRT.anchoredPosition = new Vector2 (goalPos.x, goalPos.y);

    }



    public void SetCDPos(bool setBool, Vector2 newPuck, Vector2 newGoalPos)
    {
        setCDPos = setBool;
        puckPos = newPuck;
        goalPos = newGoalPos;
    }



    public void StartCount(float wfs)
    {   
        if( _AHManager.start_Count)
        {
           //  _AHManager.your_Paddle_SR.sprite = paddle_Neutral;
        //    _AHManager.your_Paddle_SR.sprite = _AHManager.paddle_Lose_Sprites[Random.Range(0, 3)];
        StartCoroutine(MathfSin(wfs));
        }
    }

   
    public IEnumerator MathfSin(float wfs)
    {
       // Debug.Log("stopCo is " + stopCO);
        if(stopCO)
        {
            
            yield break;
        }
        
        yield return new WaitForSeconds(wfs);

        count = 3;
        
        while(count >= 0)
        {
            if(count == 0)
            {
                 startTimer = false;
                 Nums.text = "Go";
                 yield return StartCoroutine(Scaling());  
                 Invoke ("PuckDrop", dropDelay);
                //  _AHManager.your_Paddle_SR.sprite = _AHManager.face_One;
                 yield break;
            } 

            if(count != 0)
            {
             //   Debug.Log("count one is " + count);

                Nums.text = (count.ToString());
        
               // Debug.Log("count two is " + count);

                startTimer = true;
                yield return StartCoroutine(Bouncing());
                startTimer = false;

               // Debug.Log("count three is " + count);

                count--;

              //  Debug.Log("count four is " + count);

                yield return null;
            }
                yield return null;
        
        }            
         yield return null;
    }

	IEnumerator Bouncing()
	{
        beginTime = Time.time;
        tranPos=transform.position;

		while(startTimer)
        {
            time = Time.time;
			endTime = Time.time;
			totalTime = endTime - beginTime;
        

			if(totalTime < cycle)
			{
			sin = Mathf.Sin(speedUpDown * time) * distanceUpDown;
			transform.position = tranPos + new Vector3 (0f, sin, 0f);
			}

			if(totalTime > cycle)
			{
				startTimer = false;
				totalTime = 100f;
			}
				yield return null;
		}
	}

    public IEnumerator Scaling()
    
	{
		minScale = new Vector2(0f, 0f); // sets scale to original setting.
        startScale = new Vector2(1f, 1f);
        maxScale = new Vector2(1.2f, 1.2f);

		{
			yield return ScoringLerp(startScale, maxScale, duration); //lerp up scale
			yield return ScoringLerp(maxScale, minScale, duration); // lerp down scale
			Nums.text = " ";
            yield return null;
		}
        transform.localScale = new Vector2(1f, 1f);
	}

	public IEnumerator ScoringLerp(Vector2 a, Vector2 b, float time)
	{
		float i = 0.0f;
		float rate = (1.0f * time) * speed;

		while (i < 1.0f)
		{
			i += Time.deltaTime * rate;
			transform.localScale = Vector2.Lerp(a, b, i);
			yield return null;
		}
	}

    void PuckDrop()
	{
        startingPuck.transform.position = puckPos;
        startingPuck.SetActive(true);
        startingPuck.transform.hasChanged = false;
        puckGlow.ResetGlow();    
         _AHManager.ActivateReturnMenu(true, true);
         
	}

    IEnumerator GlowPuckDrop()
    {

        for ( float t = 0.01f ; t < fadeOutTime ; t += 0.1f )
			{
				_spriteRender.material.color = Color.Lerp(endColor , startColor , t / fadeOutTime) ;

				yield return null ;
			}	
    }
}
