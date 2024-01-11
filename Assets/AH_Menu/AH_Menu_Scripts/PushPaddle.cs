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

    int speed;

 GameObject theBalls;

    GameObject thisBall;

  Control_Script_01 _control_Script;
    Light2D myLight;

    AudioSource audio_Source;
	
	public AudioClip[] audioClips;

    bool sine_Bool;

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

        menu_Paddle_RB = this.gameObject.GetComponent<Rigidbody2D>();
        menu_Paddle_RB.AddForce( RandomVector(10, 5), ForceMode2D.Impulse);

        speed = (Random.Range(0, 2) * 2 - 1) * 15;   // Sets int speed to either15 or -15.

        theBalls = GameObject.FindGameObjectWithTag("TheBalls");
        _control_Script = theBalls.GetComponent<Control_Script_01>();

        thisBall = this.gameObject;

        // light settings.
        myLight = GetComponent<Light2D>();

        audio_Source = GetComponent<AudioSource>();
        sine_Bool = false;
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



    void OnCollisionExit2D(Collision2D collision)
    {
    //   Debug.Log("one ");
      if(splashLoad02 == null)
      {
                                                                   
         if(_control_Script.stop_Col == false && collision.gameObject.tag == "MenuPucks")
        {
           // Debug.Log("two ");
                _control_Script.stop_Col = true;
                                            
                _control_Script.paddle.Add(thisBall);
                _control_Script.paddle.Add(collision.gameObject);

                                                                 
                _control_Script.Pick_Paddle();
        }
      }
    }
        


public void Start_Talk()
{
                StartCoroutine(Say_Lite());
}


        IEnumerator Say_Lite()
        {
                    audio_Source.clip = audioClips[x];
					x++;
					if(x >= audioClips.Length)
					{ 
						x = 0;
					}
                    audio_Source.Play();
                    Debug.Log("audio_Source is " +  audio_Source.clip);

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
                 
			   while(audio_Source.isPlaying)
                 {
                    yield return null;
                 }

                yield return new WaitForSeconds(.2f);
              _control_Script.stop_Col = false;
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
