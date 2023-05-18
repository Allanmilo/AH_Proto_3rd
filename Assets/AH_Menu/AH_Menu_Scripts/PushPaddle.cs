using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.Audio;
using UnityEngine.Experimental.Rendering.Universal;


public class PushPaddle : MonoBehaviour
{
    Rigidbody2D menu_Paddle_RB;

    GameObject AHScriptManager;
    AHScriptManager _AHManager;

    GameObject splashLoad02;

    TextMeshPro tmpText;

    Color tmProColor_1; 
    Color tmProColor_0;

    bool stopTalk;

    [SerializeField] float exitSpeed;

    Vector3 viewPos; // Variable for storing the current transform position.

    int speed;



 GameObject theBalls;

    GameObject thisBall;

  Control_Script_01 _control_Script;

  [SerializeField] int pad_Num;

    //bool onOff = false;

// light variables.
    Light2D myLight;

    AudioSource audio_Source;
	
	public AudioClip[] audioClips;

    bool sine_Bool;
    bool skip_Collision;

    int x;

    [System.Serializable] // Needed to see in Inspector.
    public class Row
        {   
            public float[] rowdata; // Array(s) containing flash timings.
        }

    public Row[] speech_Times; // Array containing rowdata arrays.
     
    //  To get a value from arrays:
    //  speech_Times[x].rowdata[y] 
    // Were x is an array 
    // y is the value in the array.
   



    void Start()
    {
        
        AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
        _AHManager = AHScriptManager.GetComponent<AHScriptManager>();

        splashLoad02 = GameObject.FindGameObjectWithTag("SplashLoad");

       // tmpText = transform.GetChild(0).GetComponent<TextMeshPro>();

        menu_Paddle_RB = this.gameObject.GetComponent<Rigidbody2D>();

        menu_Paddle_RB.AddForce( RandomVector(10, 5), ForceMode2D.Impulse);

        // tmProColor_1 =  new Color(1, 1, 1, 1);
       // tmProColor_0 =  new Color(1, 1, 1, 0);

        speed = (Random.Range(0, 2) * 2 - 1) * 15;   // Sets int speed to either15 or -15.

       // stopTalk = false;

        theBalls = GameObject.FindGameObjectWithTag("TheBalls");
        _control_Script = theBalls.GetComponent<Control_Script_01>();

        thisBall = this.gameObject;

        // light settings.
        myLight = GetComponent<Light2D>();

        audio_Source = GetComponent<AudioSource>();
        sine_Bool = false;
        skip_Collision = false;
		
		x = 0;
    }



    void Update()
    {
        if(_AHManager.speedUp == true)
        {
            transform.position += transform.position * 1f * Time.deltaTime; // makes paddles move a little faster.
            transform.Rotate(0, 0, speed, Space.Self); // gives paddles a spin as menu blows apart
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
      if(splashLoad02 == null)
      {
        if(_control_Script.stop_Col == false && collision.gameObject.tag == "MenuPucks")
        {
            _control_Script.onOff = true;
            // _control_Script.stop_Col = true;
                                            
                _control_Script.paddle.Add(thisBall);

                StartCoroutine(Start_Talk());                  
        }
      }
    }
        


IEnumerator Start_Talk()
{
    yield return new WaitForSeconds(.001f);

    if(_control_Script.ball_Ran == thisBall)
            {
               // _control_Script.ball_Ran = null;
                StartCoroutine(Say_Lite());
				// _control_Script.ball_Ran = null;
            }
}


        IEnumerator Say_Lite()
        {
            if(!skip_Collision)
            {
                    skip_Collision = true;
                   
                    audio_Source.clip = audioClips[x];
					x++;
					if(x >= audioClips.Length)
					{ 
						x = 0;
					}
                    audio_Source.Play();


				for (int y = 0; y < speech_Times[x].rowdata.Length; y++)
				{
					float flash = speech_Times[x].rowdata[y];  
			
                        while (sine_Bool)
                        {
                            yield return null;
                        } 

                        if (!sine_Bool)
                        {
                            StartCoroutine(Blink_Twice(flash, 50));
							sine_Bool = true;
                        }

                        yield return null;		
                }
                 
			   if(audio_Source.isPlaying)
                 {
                    yield return null;
                 }

                yield return new WaitForSeconds(.5f);
              _control_Script.stop_Col = false;
			   skip_Collision = false;
			}
        }

    IEnumerator Blink_Twice(float Speed, float Amplitude)
    {
        float y = 0;
        float time = 0;

                while (y >= 0)
                {
                    float angle = time * Time.deltaTime * Mathf.PI / Speed;
                    y = Amplitude * (Mathf.Sin(angle));

                    myLight.intensity = y;
                    time += 1f;

                    yield return null;
                }

		sine_Bool = false;
        
    }

    private Vector3 RandomVector(float min, float max)  // Function to return random number vector used for velocity.
    {
        float 
        x = Random.Range(min, max);
        return new Vector3(x, 0, 0);
    }
    
}
