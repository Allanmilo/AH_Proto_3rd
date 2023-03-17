using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScene: MonoBehaviour
{
	
	
	public GameObject _pan;
  	[SerializeField] private Image _progress_Circle_Image;
   
	[SerializeField] TextMeshProUGUI progressText;

    public AsyncOperation operation;
	
	GameObject _splashLoad02;
	GameObject _progress_Circle;

	// Start_Button _start_Button_script;

	SpriteRenderer _splashLoad_Color; 

	GameObject _start_Button_Canvas;

    bool buttonPressed = true;      
	float newAlpha;
	int sceneName;

	Color startColor;
	Color endColor;

    float progress;

	void Awake()
	{
		newAlpha = 1;
		_progress_Circle = GameObject.FindGameObjectWithTag("Progress_Circle");
		// _start_Button_script = _progress_Circle.GetComponent<Start_Button>();

		_splashLoad02 = GameObject.FindGameObjectWithTag("SplashLoad");
      	_splashLoad_Color = _splashLoad02.GetComponent<SpriteRenderer>();

     	 _start_Button_Canvas = GameObject.FindGameObjectWithTag("Start_Button_Canvas");

		startColor = new Color32(8, 154, 14, 255);
		endColor = new Color32(106, 251, 16, 255);

		_pan.transform.localScale = new Vector3(1.2f, 1f, 0);
    	DontDestroyOnLoad(_pan);
		DontDestroyOnLoad( _splashLoad02);
	    sceneName = 1;
		LoadScene();
	}



	void LoadScene()
	{	
		StartCoroutine(BeginLoad());
		
	}



	private IEnumerator BeginLoad()
	{
		
		yield return null;
		
		 operation = SceneManager.LoadSceneAsync(sceneName);
		 operation.allowSceneActivation = false;  // was off originally.
		
		while (!operation.isDone)
		{
			
			progress = Mathf.Clamp01(operation.progress / .9f); // allows progress to go to 1 instead of stopping AT .9.
			
			_progress_Circle_Image.fillAmount = progress;

            operation.allowSceneActivation = true;

            yield return null;	
		}

        Change_Circle(); // was an action item.
		// action();
		
	}



		void Change_Circle()
		{
			_progress_Circle_Image.color = new Color32(8, 154, 14, 255);
			progressText.fontSize = 60;
			progressText.text = "Lets go!";
			//progressText.color = new Color32(8, 154, 14, 255);
			StartCoroutine(Glow_Text());
		}



	private IEnumerator Glow_Text()
	{
		float speed = 3;

		while(true)
		{
			float t = (Mathf.Sin(Time.unscaledTime * speed) + 1) /2;

			progressText.color = Color.Lerp(startColor, endColor, t);

			yield return null;

		}
	}



	public void Switch()
  {   
	StartCoroutine(FadeFromTo(1f, 0f));
  }



    IEnumerator FadeFromTo( float from, float to)
    {
		 _start_Button_Canvas.SetActive(false);
		
		newAlpha = 1;
		 
        AnimationCurve curve = new AnimationCurve(new Keyframe[ ]
                                                    { 
                                                      new Keyframe(0f, from),
                                                      new Keyframe(1f, to) 
                                                    });
           float time = 0f;
        
           while (time < 1f)
           {
             _splashLoad_Color.color = new Color(1, 1, 1, newAlpha);
			//Debug.Log("Color is " + _splashLoad_Color.color);
			//Debug.Log("time is " + curve.Evaluate(time));

             newAlpha = curve.Evaluate(time);
             time += Time.unscaledDeltaTime;   
              yield return null;          
           }     

        Destroy(_splashLoad02);

    }
}


