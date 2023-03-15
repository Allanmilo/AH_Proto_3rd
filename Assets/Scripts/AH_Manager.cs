

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class AHManager : MonoBehaviour
{


    [SerializeField] GameObject _puck;
    
    [SerializeField] GameObject _circleBackground;
                     GameObject prefabHolder;
                     GameObject pointEffectorCircle;
                     GameObject _startMenu;
                     GameObject _midGameMenu;
                     GameObject[] menuButtons;    
                     GameObject[] menuCircleScript;
                     GameObject star_Girl;
                     GameObject Pan;
                     RectTransform Pans_Rec;  ///????


    public CountDown countDown;
	[SerializeField] GameObject startingPuck;
	private Vector2 bottomPuck;
	private Vector2 countDown01;

                     FreezeText[] _freezeText;

   // [SerializeField] PanMovement _panMovement;
                     PountEffectorSwitch _pointEffectorSwitch;
                     StartMenuScript startMenuScript;
                     MenuMidGame midGameMenuScript;
                  
    
    [SerializeField] Text01Score _text01Score;
    [SerializeField] TextTwoScore _textTwoScore;

     Transform highestObject;

     //[SerializeField] Transform Pans_Transform;
     PointEffector2D _pointEffector2D;

    Vector3 offScreenCB;
    Vector3 centerScreenCB;

    public float _maxPuckSpeed;
    public float _maxAISpeed;

    // Menu Return variables.

     [SerializeField] GameObject _menuReturnButton;
     [SerializeField] GameObject _menuRingFill;

    [SerializeField] GameObject[] _menuLetters;
    [SerializeField] Rigidbody2D[] _menuLettersRB;

    Vector2[] _lettersPos;
    Vector2[] _lettersRePos;

    float x;
    float y;

    Vector3 pos;
   
    Color _ringFillAlpha;

   public float alpha02;
   SpriteRenderer objectColor;   

   public bool restoreMenuRunning;

    Vector3 zeroish;
    Vector3 fullSize;

   [SerializeField] TextMeshPro scoreText01;
   [SerializeField] TextMeshPro scoreText02;



   [SerializeField] TextMeshPro _starGirlText;

     // public TextMeshPro pans_Text;

    TextMeshProUGUI allTalk_Public;


    [SerializeField] FlashFade _flashFade;
    [SerializeField] FlashFadeTop _flashFadeTop;

    // [SerializeField] GameObject _text_Pan;
   
    public bool start_Game;


    public GameObject[] Bad_Arua;
    public float a = 1f;
    [SerializeField]  Material bad_Arua;
    Color bad_Alpha;

    [SerializeField] ParticleSystem star_Is_Sad;
    Vector3 Stars_Starting_Position;
    Vector3 Stars_Ending_Position;


// Menu Flowers.
    
    [SerializeField] GameObject menu_Flower_01;
    [SerializeField] GameObject menu_Flower_02;
    [SerializeField] Transform _flower_Menu;

    [SerializeField] Vector3 rotate_Flower;  
    public float flower_Speed_01;
    public float flower_Speed_02;

    bool spin_Flowers;

    Vector3 flowers_Start;
    Vector3 flowers_End;

    Vector3 small_Flowers;
    Vector3 large_Flowers;


     Vector3 Pans_Pos;

    Vector3 endPosLeftOffScreen;
    Vector3 gamePosLeft;



    public bool switching_Menu;

  public bool start_Count;
  GameObject textCountDown;

    ParticleSystem star_Is_Happy;

  ParticleSystem flowers_Particle_01;
  ParticleSystem flowers_Particle_02;

 [SerializeField] GameObject _star_Is_Happy;
  [SerializeField] GameObject _flowers_Particles_01;
  [SerializeField] GameObject _flowers_Particles_02;

  [SerializeField] GameObject try_Again;
    [SerializeField] GameObject back_To_Menu;

    [SerializeField] ScoreScaling _scoreScaling;


    public string text_For_Pan;

   


#region Variables   
RectTransform maskingTextBox;
// RectTransform stars_Text_Box_RecTrans;
// RectTransform boys_Text_Box_RecTrans;

//GameObject stars_text_Box;
//GameObject boys_Text_Box;

//TextMeshPro Stars_TMPro;
//TextMeshPro boys_TMPro;
TextMeshPro allTalk;


int arrayPos;
int[] orderList;


string trashTalk01;
string trashTalk02;
string sayStuff;
string text_Moves;
string text_effect;



Vector2 textBox_width01;
Vector2 textBox_width02;


[SerializeField] TMP_FontAsset _second_Font;
[SerializeField] TMP_FontAsset _first_Font;

[SerializeField] SpriteRenderer _sunGlass;
bool no_Fade;
bool CR;

bool _text_Is_This;

#endregion Variables

        Color sunGlass_00;
		Color sunGlass_01;
int arrayNum;
TextMeshPro[] list_TMPro;
RectTransform[] pan_Text_Rec;

        GameObject text_Pan;
        RectTransform text_Pan_Transform;
        GameObject text_Pan_a;
        TextMeshPro text_Pan_a_TMPro;
        RectTransform text_Pan_a_Transform;

        GameObject text_Pan_b;
        TextMeshPro text_Pan_b_TMPro;
        RectTransform text_Pan_b_Transform;
        Vector3 center;

        Vector3 centerLeft;    

        Vector3 originalPos;   
   
        Vector2 large;   

        Vector2 small;   
       // Vector3 gamePosLeft;
Transform panTrans;

       //Vector3 endPosLeftOffScreen;


    [SerializeField] StartFireWorks01 _startFireWorks01;
    [SerializeField] StartFireWorks02 _startFireWorks02;


    public delegate void Lerp_Pos_Delegate();
    public static event Lerp_Pos_Delegate lerp_Pos_Delegate;

    public delegate void Text_To_Use_Is();
    public static event Text_To_Use_Is  text_To_Use_Is;

    public delegate void Objects_Variables();
    public static event Objects_Variables objects_Variables;

    

    GameObject stars_text_Box; 
    TextMeshPro stars_TMPro; 
    RectTransform stars_Text_Box_RecTrans; 
    Color stars_TMPro_Color; 

    GameObject boys_Text_Box; 
    TextMeshPro boys_TMPro; 
    RectTransform boys_Text_Box_RecTrans; 
    Color boys_TMPro_Color; 

    RectTransform text_Box_RecTransform;
    TextMeshPro tmpro_Object;

    Color tmpro_Color;


    void Start()
    {  
        Pan = GameObject.FindGameObjectWithTag("Pan");
         panTrans = Pan.GetComponent<Transform>();

         endPosLeftOffScreen = new Vector3(-19f, 4f, 0);

         center = originalPos * 0.5f;   // Originally - center = (originalPos + gamePos)* 0.5f;

         centerLeft = (endPosLeftOffScreen + originalPos) * .2f;

        originalPos = new Vector3(-9f, -3.5f, 0);

         gamePosLeft = new Vector3(-13f, 4f, 0);
   
        large = panTrans.localScale;

        small = new Vector3(1f, .8f, 0 );
    
    //    Pans_Rec = text_Pan_a_TMPro.GetComponent<RectTransform>();

        text_Pan = GameObject.FindGameObjectWithTag("PanText");
        text_Pan_Transform = text_Pan.GetComponent<RectTransform>();

        text_Pan_a  = GameObject.FindGameObjectWithTag("PanText_a");
        text_Pan_a_TMPro = text_Pan_a.GetComponent<TextMeshPro>();
        text_Pan_a_Transform = text_Pan_a.GetComponent<RectTransform>();

        text_Pan_b = GameObject.FindGameObjectWithTag("PanText_b");
        text_Pan_b_TMPro = text_Pan_b.GetComponent<TextMeshPro>();
        text_Pan_b_Transform = text_Pan_b.GetComponent<RectTransform>();
    
        arrayNum = 0;
        list_TMPro = new TextMeshPro[2];

        list_TMPro[0] = text_Pan_a_TMPro;
        list_TMPro[1] = text_Pan_b_TMPro;

       pan_Text_Rec = new RectTransform[2];
        pan_Text_Rec[0] = text_Pan_a_Transform;
        pan_Text_Rec[1] = text_Pan_b_Transform;

        text_Pan_a_TMPro.color = new Color(0f, 0f, 0f, 0);

        text_Pan_a_TMPro.text = text_For_Pan;
        text_Pan_b_TMPro.text = text_For_Pan;

        sunGlass_00 = new Color(0, 0, 0, 0);
		sunGlass_01 = new Color(0, 0, 0, .7f);

        _sunGlass.material.color = sunGlass_00;

     

        flowers_Particle_01 = _flowers_Particles_01.GetComponent<ParticleSystem>();
        flowers_Particle_02 = _flowers_Particles_02.GetComponent<ParticleSystem>();
        star_Is_Happy = _star_Is_Happy.GetComponent<ParticleSystem>();

        star_Is_Happy.Stop();

        
        textCountDown = GameObject.FindGameObjectWithTag("TextCountDown");
        countDown = textCountDown.GetComponent<CountDown>();
        star_Girl = GameObject.FindGameObjectWithTag("Star_Girl");

        Bad_Arua = GameObject.FindGameObjectsWithTag("Bad_Arua");
       // Pans_Pos = new Vector3(-640, 4, 0);

        start_Count = true;

        spin_Flowers = false;
        flower_Speed_01 = 5f;
        flower_Speed_02 = 5f;
       

        
        flowers_Start = new Vector3(0, -3, 0);
        flowers_End = new Vector3(-5, 0, 0);
        small_Flowers = new Vector3(0, 0, 0);
        large_Flowers = new Vector3(1, 1, 1);

         

         bad_Alpha = bad_Arua.color;


        Stars_Starting_Position = star_Girl.transform.position;

        Stars_Ending_Position = new Vector3(-40, star_Girl.transform.position.y, 0);

        start_Game = true;

        //pans_Text = text_Pan_a_TMPro.GetComponent<TextMeshPro>();

        restoreMenuRunning = false;

        _lettersPos = new Vector2[_menuLetters.Length];

        for(int i = 0; i < _menuLetters.Length; i++)
        {
            Vector2 pos = _menuLetters[i].transform.position;
            _lettersPos[i] = pos;
           
        }

        _maxPuckSpeed = 0;
        _maxAISpeed = 0;
        
       ActivateReturnMenu(false, false);
 
        centerScreenCB = new Vector3(0, 0, 0);
        offScreenCB = new Vector3(0, 21f, 0);


        zeroish = new Vector3(.01f, .01f, 0f); // Used for setting vector to almost zero. 

        bad_Alpha.a = 0;  

        bad_Arua.color = bad_Alpha;

        gamePosLeft = new Vector3(-13f, 4f, 0);

        endPosLeftOffScreen = new Vector3(-19f, 4f, 0);




        stars_text_Box = GameObject.FindGameObjectWithTag("Text_Girl");
        stars_TMPro = stars_text_Box.GetComponent<TextMeshPro>();
        stars_Text_Box_RecTrans = stars_text_Box.GetComponent<RectTransform>();
        stars_TMPro_Color = stars_TMPro.color;

        boys_Text_Box = GameObject.FindGameObjectWithTag("Text_Boy");
        boys_TMPro = boys_Text_Box.GetComponent<TextMeshPro>();
        boys_Text_Box_RecTrans = boys_Text_Box.GetComponent<RectTransform>();
        boys_TMPro_Color = boys_TMPro.color;

        textBox_width01 = new Vector2(0, 1);
        textBox_width02 = new Vector2(11, 1);

        _text_Is_This = false;
        
        /*
public delegate void Text_To_Use_Is();
public static event Text_To_Use_Is  text_To_Use_Is;

public delegate void Objects_Variables();
public static event Objects_Variables objects_Variables;
     */
   
     StartCoroutine(StartFirstMenu());
        
        
        Set_Random_Array();

    }




        void Update()
        {
             alpha02 = _ringFillAlpha.a;  

         if(spin_Flowers)
            {
                menu_Flower_01.transform.Rotate( rotate_Flower * flower_Speed_01 * Time.deltaTime);
                menu_Flower_02.transform.Rotate( rotate_Flower * flower_Speed_02 * Time.deltaTime);
            }
              

         
        }


#region -----Objects variables-----


public void Pick_Opponent()
{
    Debug.Log("pick the opponent.");
}


public void Boys_TextBox_Variables()
   {
        text_Box_RecTransform =  boys_Text_Box_RecTrans;
        tmpro_Object = boys_TMPro;
        tmpro_Color = boys_TMPro_Color;
        
    }

void Stars_TextBox_Variables()
    {
         text_Box_RecTransform =  stars_Text_Box_RecTrans;
        tmpro_Object = stars_TMPro;
        tmpro_Color = stars_TMPro_Color;
    
    }

#endregion -----Objects variables-----

#region -----Coroutines-----

        IEnumerator Lerp_Color_Alpha(SpriteRenderer sprite_Renderer, Color start_Color, Color end_Color, float secs_To_Wait,  float duration)
		{
			 yield return new WaitForSeconds(secs_To_Wait);  

			float start_Point = 0;

			 while(start_Point < duration)
			{
				sprite_Renderer.material.color = Color.Lerp( start_Color , end_Color ,  start_Point / duration) ;
               
				start_Point += Time.unscaledDeltaTime;
				yield return null ;
			}		
		}


        IEnumerator Lerp_TMPro_Color_Alpha(TextMeshPro _textMeshPro, Color start_Color, Color end_Color, float secs_To_Wait,  float duration)
		{
			 yield return new WaitForSeconds(secs_To_Wait);  

			float start_Point = 0;

			 while(start_Point < duration)
			{
				_textMeshPro.color = Color.Lerp( start_Color , end_Color ,  start_Point / duration) ;
               
				start_Point += Time.unscaledDeltaTime;
				yield return null ;
			}		
		}


        IEnumerator Lerp_Transform_Position(GameObject object_To_Lerp_Position, Vector3 start_Lerp_Pos, Vector3 end_Lerp_Pos, float wait_For_Sec, float duration )
        {
                      if( lerp_Pos_Delegate != null  )
               {     
                     lerp_Pos_Delegate();
                     lerp_Pos_Delegate = null; 
               }

                float time = 0f;
                yield return new WaitForSeconds( wait_For_Sec );
                
                while(time < duration)
                {
                object_To_Lerp_Position.transform.position = Vector3.Lerp( start_Lerp_Pos, end_Lerp_Pos, time / duration );
                    time += Time.unscaledDeltaTime;
                    yield return null;
                }
           
        
              
}


#endregion -----Coroutines-----



 #region -----Textbox_Moves-----



 IEnumerator FadeOutCR( string text_Moves, float WFS, float duration ) // Fades text out from full alpha to zero alpha.
{

    if(text_To_Use_Is != null)
    {
        text_To_Use_Is();
        text_To_Use_Is = null;
    }

    if(objects_Variables != null)
    {
        objects_Variables();
        objects_Variables = null;
    }



    if(text_Moves == "fade")
    {
       
        text_Moves = " ";

        yield return StartCoroutine(FadeInCR( WFS, duration));
    }

    
     if(text_Moves == "type")
    {
       
         text_Moves = " ";

        yield return StartCoroutine(StartAnimation(WFS));
    }

   
     if(text_Moves == "slide")
    {
       
         text_Moves = " ";
        yield return StartCoroutine(OpenText(WFS, duration));
    }
    
      
    float currentTime = 0f;


                if(!no_Fade)
                {
                        while(currentTime < duration)
                        {
                            float alpha = Mathf.Lerp(1f, 0f, currentTime/duration);
                            tmpro_Color = new Color(1, 1, 1, alpha);
                            currentTime += Time.deltaTime;
                            yield return null;
                        }
                
                }

}


IEnumerator StartAnimation(float WFS)
  {
      yield return new WaitForSeconds(WFS);
      string[] array = sayStuff.Split(' ');
       tmpro_Object.text = array[0]; 
      for( int i = 1 ; i < array.Length ; ++ i)
      {     
          // _tmpro_Object.alpha = 1;
          yield return new WaitForSeconds(.3f);
           tmpro_Object.text += " " + array[i]; 
      }
  }


     IEnumerator FadeInCR(float WFS, float duration) // Fades text in from zero alpha to full alpha.
{
   yield return new WaitForSeconds(WFS);
    float currentTime01 = 0f;

    while(currentTime01 < duration)
    { 
        tmpro_Object.text = sayStuff;
        float alpha = Mathf.Lerp(0f, 1f, currentTime01/duration);
        
         tmpro_Color = new Color(1, 1, 1, alpha);
       
        currentTime01 += Time.deltaTime;
        yield return null;
         
    }
}

     IEnumerator OpenText(float WFS, float duration) // Sliding text reveal using the width of recttransform. 
    {
        yield return new WaitForSeconds(WFS);
            float currentTime01 = 0f;
            allTalk.alpha = 1f;
    
        while(currentTime01 < duration)
        { 
        Vector2 newWidth = Vector2.Lerp(textBox_width01, textBox_width02, currentTime01/duration);
            text_Box_RecTransform.sizeDelta = newWidth;
            currentTime01 += Time.deltaTime;
            yield return null;
        }    
    }
   



 IEnumerator Pans_Text_Box(RectTransform pan_Text_Rec, float _PTB_WFS, string _Pan_Says) // Sliding text reveal using the width of recttransform.
    {
        yield return new WaitForSeconds(_PTB_WFS);
       text_Pan_a_TMPro.text = _Pan_Says;
       text_Pan_b_TMPro.text = _Pan_Says;

        float duration01 = 2.5f;
        float currentTime01 = 0f;
        Vector2 width01 = new Vector2(0, 1);
        Vector2 width02 = new Vector2(10, 1);
        

        while(currentTime01 < duration01)
        { 
            Vector2 newWidth = Vector2.Lerp(width01, width02, currentTime01/duration01);
            pan_Text_Rec.sizeDelta = newWidth;
            currentTime01 += Time.deltaTime;
            yield return null;
        }    
    }


 #endregion   -----Textbox_Moves-----




#region -----Character_Texts-----


void First_Text_Line() // Sets text to trashTalk01.
    {
        allTalk.text = trashTalk01;
        sayStuff = allTalk.text;
        
    }


   void Second_Text_Line() // Sets text to trashTalk02.
    {
        allTalk.text = trashTalk02;
        sayStuff = allTalk.text;
    }



    void Set_Random_Array()
        {
            arrayPos = 0;
            orderList = new int[5];

            orderList[0] = 0;
            orderList[1] = 1;
            orderList[2] = 2;
            orderList[3] = 3;
            orderList[4] = 4;

            for (int positionOfArray01 = 0; positionOfArray01 < orderList.Length; positionOfArray01++)
            {
                int obj01 = orderList[positionOfArray01];
                int randomizeArray01 = Random.Range(0, positionOfArray01);
                orderList[positionOfArray01] = orderList[randomizeArray01];
                orderList[randomizeArray01] = obj01;
            }       
        }



public void Stars_Dialogue()
    {
        allTalk = stars_TMPro;  // chose text box.
        sayStuff = allTalk.text;

        maskingTextBox =stars_Text_Box_RecTrans; // chose text box container for slide effect.

        switch (orderList[arrayPos])
        {
            case 0:
                trashTalk01 = "<b><size=12><align=right><color=#acaeea>Don't Run!</color></b>";
				trashTalk02 = "<size=9><color=#acaeea><align=right>The puck doesn't bite!</color> ";

                text_To_Use_Is += First_Text_Line;
                objects_Variables += Stars_TextBox_Variables;

                StartCoroutine(FadeOutCR("slide", 0, 2));
                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("fade", 3, .5f));
				//StartCoroutine(Talk02Wait(Talk_02_Transform, boys_TMPro, "f", 3, .5f, sayStuff)); 
                
            break;

            case 1:
                trashTalk01 = "<b><size=12><align=right><color=#acaeea>Did you see that?</color></b>";
				trashTalk02 = "<size=9><color=#acaeea><align=right>No. I guess you didn't</color> ";
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("type", 0, 2));
				//StartCoroutine(Talk02Wait( "f", 3, 3)); 
              
            break;

            case 2:
                trashTalk01 = "<b><size=12><align=right><color=#acaeea>Say...</color></b>";
				trashTalk02 = "<size=9><color=#acaeea><align=right>is that goal AWAYS open?</color> ";
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR( "slide", 0, 2));
				//StartCoroutine(Talk02Wait("t", 3, 2)); 
            break;

            case 3:
                trashTalk01 = "<b><size=12><align=right><color=#acaeea>Hello?</color></b>";
                trashTalk02 = "<size=10><color=#acaeea><align=right>Are you AFK?</color> ";
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR( "fade", 0, 2 ));
				//StartCoroutine(Talk02Wait( "t", 3, 2));
            break;

            case 4:  
                trashTalk01 = "<b><size=12><align=right><color=#acaeea>That's so sweet</color></b>";
				trashTalk02 = "<size=9><color=#acaeea><align=right>You're letting me win!</color> ";
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR( "fade", 0, 2 ));
				//StartCoroutine(Talk02Wait("t", 3, 2 )); // 1st parameter is WaitForSeconds, 2nd parameter is effect style (f, t, s).

            break;
        }
              if (arrayPos >= orderList.Length - 1)
        {
            arrayPos = 0;
        }

        else
        {
            arrayPos += 1;
        }
    }


    public void Boys_Dialogue()
    {
       // allTalk = boys_TMPro;  // chose text box.
       
      //  maskingTextBox =boys_Text_Box_RecTrans; // chose text box container for slide effect.

        switch (orderList[arrayPos])
        {
            case 0:
                trashTalk01 = "<color=#D6C207>It's hard,</color>";
				trashTalk02 = "<color=#D6C207>Being this good!</color>";
            text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR( "slide", 1, 1));
            text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("fade", 1, 1));

				//StartCoroutine(Talk02Wait(Talk_02_Transform, boys_TMPro, "f", 1, 1," ")); 
                
            break;

            case 1:
                trashTalk01 = "<color=#D6C207>I've seen worse.</color>";
				trashTalk02 = "<color=#D6C207><size=8>But not much worse.</color>";
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("type", 1, 1));
                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("fade", 3, 1));

				//StartCoroutine(Talk02Wait(Talk_02_Transform, boys_TMPro, "f", 1, 1, " ")); 
              
            break;

            case 2:
                trashTalk01 = "<color=#D6C207>It could be worse,</color>";
				trashTalk02 = "<color=#D6C207><size=8>It could be me playing that bad. </color>";
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("slide", 1, 1));
               text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("type", 3, 1));

				//StartCoroutine(Talk02Wait(Talk_02_Transform, boys_TMPro, "t", 1, 1, " ")); 
            break;

            case 3:
                trashTalk01 = "<color=#D6C207>Gotta ask-</color>";
                trashTalk02 = "<color=#D6C207><size=8>Ya know which goal is yours, right? </color>";
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("fade", 1, 1));
              text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("type", 1, 1));

				//StartCoroutine(Talk02Wait(Talk_02_Transform, boys_TMPro, "t", 1, 1, " "));
            break;

            case 4:  
                trashTalk01 = "<color=#D6C207><size=9>Nothin' worse than losing,</color>";
				trashTalk02 = "<color=#D6C207>So I've heard. </color>";
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("fade", 1, 1));
                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR( "slide", 1, 1));

				//StartCoroutine(Talk02Wait(Talk_02_Transform, boys_TMPro, "s", 1, 1, " ")); // 1st parameter is WaitForSeconds, 2nd parameter is effect style (f, t, s).

            break;
        }
              if (arrayPos >= orderList.Length - 1)
        {
            arrayPos = 0;
        }

        else
        {
            arrayPos += 1;
        }
    }


    
    public void Star_Wins()
    {
              //  allTalk = Stars_TMPro;  // chose text box.
                star_Is_Happy.Play();
                Slerp_In_Flowers();
              //  maskingTextBox =stars_Text_Box_RecTrans; // chose text box container for slide effect.
                trashTalk01 = "<b><size=12><align=right><color=#acaeea>That was FUN!</color></b>";
				trashTalk02 = "<size=12><color=#acaeea><align=right>Wanna lose again?</color> ";
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("fade", 1, 1));
                text_To_Use_Is += Second_Text_Line;
				StartCoroutine(FadeOutCR( "type", 1, 1)); // 1st parameter is WaitForSeconds, 2nd parameter is effect style (f, t, s).
  
             //  text_To_Use_Is += Second_Text_Line;
            //    StartCoroutine(FadeOutCR(Talk_02_Transform, boys_TMPro, "slide", 1, 1, sayStuff));
 
  }

    public void Star_Loses()
    {         
                allTalk = stars_TMPro;  // chose text box.
                allTalk.font = _second_Font;
                Debug.Log(allTalk.font);
                maskingTextBox =stars_Text_Box_RecTrans; // chose text box container for slide effect.
                trashTalk01 = "<b><size=9><align=right><color=#0e1111>that wasn't very nice.</color></b>";
				trashTalk02 = "<size=9><color=#0e1111><align=right>i'm gonna tell on you...</color> ";
                First_Text_Line();
                StartCoroutine(FadeOutCR("fade", 1, 1));
				//StartCoroutine(Talk02Wait(Talk_02_Transform, boys_TMPro, "s", 1, 1, sayStuff)); // 1st parameter is WaitForSeconds, 2nd parameter is effect style (f, t, s).
                StartCoroutine(Lerp_Color_Alpha(_sunGlass, sunGlass_00, sunGlass_01, 0, 1.2f));
                Fade_In_Bad_Arua();
                Move_Star();
                StartCoroutine(Lerp_Color_Alpha(_sunGlass, sunGlass_01, sunGlass_00, 7, 1.2f));

    }

 #endregion -----Character_Texts-----



       IEnumerator StartFirstMenu()
                {
                        yield return new WaitForSeconds(1);

                        Time.timeScale = 0;

                        Set_Prefab_Var(); 

                        ActivateReturnMenu(false, false);                                                     
                        
                        startMenuScript.StartMenuOn();
                        
                        midGameMenuScript.MidGameMenuOff();

                        prefabHolder.transform.position = centerScreenCB;

                        FreezeCircles();
                        
                    yield return null;  
                    
                }




    public void ActivateReturnMenu(bool mRB, bool mRF)
    {
         _menuReturnButton.SetActive(mRB);
         _menuRingFill.SetActive(mRF);
    }

void Set_Prefab_Var()
{
    Debug.Log("Instantiate circleBackground");
        prefabHolder = Instantiate(_circleBackground) as GameObject;
        
        pointEffectorCircle = GameObject.FindGameObjectWithTag("PointEffector");

       _startMenu = GameObject.FindGameObjectWithTag("Menu01");

        _midGameMenu = GameObject.FindGameObjectWithTag("Menu92");
        
        menuCircleScript = GameObject.FindGameObjectsWithTag("MenuCircles"); // Loads array with menu circle.
        
        menuButtons = GameObject.FindGameObjectsWithTag("MenuButton");

        _freezeText = GameObject.FindObjectsOfType<FreezeText>();

         _pointEffectorSwitch = pointEffectorCircle.GetComponent<PountEffectorSwitch>();

        startMenuScript = _startMenu.GetComponent<StartMenuScript>();

       midGameMenuScript = _midGameMenu.GetComponent<MenuMidGame>();

}

    public void StartReturnMenu()
    {
        ActivateReturnMenu(true, false);

        for(int i = 0; i < _menuLetters.Length; i++)
            {
              _menuLetters[i].GetComponent<BoxCollider2D> ().enabled = true;
            }

       _ringFillAlpha =  _menuRingFill.GetComponent<SpriteRenderer>().color;
      
      _ringFillAlpha.a = 0f;
      
       _menuRingFill.GetComponent<SpriteRenderer>().color = _ringFillAlpha;

       _lettersRePos = new Vector2[] {RandomVector(), RandomVector(), RandomVector(), RandomVector()};

        RandomMove();
    }


public void RandomMove()
    {
        for(int i = 0; i < _menuLettersRB.Length; i++)
            {
                Vector2 vel = _lettersRePos[i] ;
                _menuLettersRB[i].velocity = vel;
            }

    }



         public void ReAlign()
    {
        for(int i = 0; i < _menuLetters.Length; i++)
            {
                Vector2 pos = _lettersPos[i] ;
                _menuLetters[i].transform.position = pos;
            }
    }

     private Vector2 RandomVector() 
     {
         x = Random.Range(-3f, 3f);
         y = Random.Range(-3f, 3f);
    
         return new Vector2(x, y);
     }



    public void OnMouseEnter_Fun()
    {
        
    // Sets the alpha from 0 to .2 on the circle inside the menu ring.
    _ringFillAlpha.a = .4f;
    _menuRingFill.GetComponent<SpriteRenderer>().color = _ringFillAlpha;
    
    
        for(int i = 0; i < _menuLetters.Length; i++)
            {
                _menuLetters[i].GetComponent<BoxCollider2D> ().enabled = false;
                _menuLetters[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero; 
           }

    }

    public void OnMouseOver_Fun()
    {
        for(int i = 0; i < _menuLetters.Length; i++) 
            {
          _menuLetters[i].transform.position = Vector2.Lerp(_menuLetters[i].transform.position, _lettersPos[i], 15 * Time.deltaTime );
           
           }
        
    } 
    public void OnMouseExit_Fun()
    {
        for(int i = 0; i < _menuLetters.Length; i++)
            {
              _menuLetters[i].GetComponent<BoxCollider2D> ().enabled = true;
            }

        _ringFillAlpha.a = 0f;
        _menuRingFill.GetComponent<SpriteRenderer>().color = _ringFillAlpha;

      RandomMove();
    }
    
    public void OnMouseUp_Fun()
    {
        _ringFillAlpha.a = 0f;
         _menuRingFill.GetComponent<SpriteRenderer>().color = _ringFillAlpha;

        LookForPuck();
    }






public void Switch_Menus()
{
     
     fullSize = _midGameMenu.transform.localScale;
 
      StartCoroutine( _Switch_Menus( ));
 }
  
    
 IEnumerator _Switch_Menus( )
 {
     
     yield return StartCoroutine(ScaleMidMenuDown( ));     

     // Deactivate mid game menu game object.
      _midGameMenu.SetActive(false);


     // activate main menu.
      startMenuScript.StartMenuOn();
        
     fullSize = _startMenu.transform.localScale;  
      _startMenu.transform.localScale = zeroish;
    float time = .3f;
     float counter = 0;

      while(counter < time)
    {
        counter += Time.unscaledDeltaTime;
     _startMenu.transform.localScale = Vector3.Lerp(zeroish, fullSize, counter / time);
    
        yield return null;
    }
        
 }


IEnumerator ScaleMidMenuDown( )
{

    float time = .3f;
    float counter = 0;
    //  Scale mid game menu game object down almost to zero.
    while(counter < time)
    {
        counter += Time.unscaledDeltaTime;
    _midGameMenu.transform.localScale = Vector3.Lerp(fullSize, zeroish, counter / time);
   
    
	yield return null;
    }

    // Deactivate mid game menu game object.
      _midGameMenu.SetActive(false);

}   



public void StartOver()
{
            scoreText01.text = "0";
            scoreText02.text = "0";
            _flashFade.scoreValue02 = 0;
            _flashFadeTop.scoreValue01 = 0;
            bottomPuck = new Vector2(0f, -3.5f);
	        countDown01 = new Vector2(0f, -3.5f);
            countDown.SetCDPos(true, bottomPuck, countDown01);
			startingPuck.SetActive(false);
            
            if(switching_Menu)
            {
                Switch_Menus();
            }
}           




    public void SwitchScreens()
    {
        Time.timeScale = 1;

         StartReturnMenu();

        DeActivateButtons();

         foreach (FreezeText freezeText in _freezeText)
            {
                 freezeText.bounceOn = false;
            }

         _pointEffectorSwitch.SwitchEffector();
     
         UnFreezeCircles();

        countDown.StartCount(3);
       text_Pan_a_TMPro.color = new Color(1, 1, 1, 1); 
       
         MovePan();
        Invoke("DestroyPrefabHolder", 1f);

    }
    


    void DestroyPrefabHolder()
    {
        Destroy(prefabHolder, 1);
    }

    public void DeActivateButtons()
    {
        for(int i = 0; i < menuButtons.Length; i++)
            {
                menuButtons[i].SetActive(false);
            }
    }



public void FreezeCircles()
{

         foreach (GameObject menuCircle_00  in menuCircleScript)
         {
           
            menuCircle_00.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll; 

         }
}

public void UnFreezeCircles()
{
         foreach (GameObject menuCircle_00  in menuCircleScript)
         {
            menuCircle_00.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None; 
        
         }
        
         
}

 
          public void restoreMenu()
        {
           
            // _panMovement.StartSlerpingOut();
            StartSlerpingOut();

           Set_Prefab_Var();
            
            startMenuScript.StartMenuOff();
        
            midGameMenuScript.MidGameMenuOn();
           
              prefabHolder.transform.position = offScreenCB;
           // FreezeCircles();
           // StartCoroutine(lowerTheScreen());
            LowerTheScreen();
        }

IEnumerator lowerTheScreen()
        {
                

                float time = 0f;
                float duration = 1.5f;

           _text01Score.FadeTextScore01();
           _textTwoScore.FadeTextScore02();

                while(time < duration)
                {
                 prefabHolder.transform.position = Vector2.Lerp(offScreenCB, centerScreenCB, time / duration );

                

                    time += Time.unscaledDeltaTime;
                    yield return null;
                }

                 ActivateReturnMenu(false, false);
                
                _puck.SetActive(false);

                 restoreMenuRunning = false;
        }

void LowerTheScreen()
{
    Debug.Log("start lowerscreen");
    lerp_Pos_Delegate += FreezeCircles;
    
     _text01Score.FadeTextScore01();
     _textTwoScore.FadeTextScore02();
  
    StartCoroutine(Lerp_Transform_Position(prefabHolder, offScreenCB, centerScreenCB, 0, 1 ));
    Debug.Log(offScreenCB + centerScreenCB);
    ActivateReturnMenu(false, false);
     _puck.SetActive(false);   
    restoreMenuRunning = false;
} 






    public void LookForPuck()
    {
        if(_puck)
        {
             restoreMenuRunning = true;
             Time.timeScale = 0;
             ActivateReturnMenu(true, false);
            restoreMenu();
        }
    }



    public IEnumerator First_2_5_In(string text_For_Pan, float _sec_2_Wait)
    {
        text_Pan_a_TMPro.text = text_For_Pan;
        text_Pan_b_TMPro.text = text_For_Pan;

         float duration01 = 2f;
        float currentTime01 = 0f;

         yield return new WaitForSeconds(_sec_2_Wait);

            while(currentTime01 < duration01)
            { 
                float alpha = Mathf.Lerp(0f, 1f, currentTime01/duration01);
                text_Pan_a_TMPro.color = new Color(0, 0, 0, alpha);
                text_Pan_b_TMPro.color = new Color(0, 0, 0, alpha);
                currentTime01 += Time.deltaTime;
                yield return null;
            }
    }

    public IEnumerator First_2_5_Out(float fade_Out_Sec)
    {
        yield return new WaitForSeconds(fade_Out_Sec);
         float duration01 = 1f;
        float currentTime01 = 0f;

            while(currentTime01 < duration01)
            { 
                float alpha = Mathf.Lerp(1f, 0f, currentTime01/duration01);
                text_Pan_a_TMPro.color = new Color(0, 0, 0, alpha);
                text_Pan_b_TMPro.color = new Color(0, 0, 0, alpha);
                currentTime01 += Time.deltaTime;
                yield return null;
            }
    }



// Star's functions.

    public void Fade_In_Bad_Arua()
    {
        spin_Flowers = true;
        StartCoroutine(fadeOut());
    }


        IEnumerator fadeOut()
        {
            float counter = 0;
            float duration = .3f;
            Color mat_Color = bad_Arua.color;

            while (counter < duration)
            {
                counter += Time.deltaTime;
                float alpha = Mathf.Lerp(0, 1, counter / duration);
                

                bad_Arua.color = new Color(mat_Color.r, mat_Color.g, mat_Color.b, alpha);
               
                yield return null;
            }
        }



    public void Move_Star()
    {
        StartCoroutine(Star_Leaves());
    }
        IEnumerator Star_Leaves()
        {
             yield return new WaitForSeconds(4.5f);

            star_Is_Sad.Play();
            float time = 0f;
            float duration = 2.5f;
             Vector3 velocity = Vector3.zero;

                    while(time < duration)
                    {
                       star_Girl.transform.position = Vector2.Lerp(Stars_Starting_Position, Stars_Ending_Position, time / duration );

                        time += Time.deltaTime;
                        yield return null;
                    }

                     yield return new WaitForSeconds(1.5f);
                    star_Girl.SetActive(false);
                    star_Is_Sad.Stop();

                    yield return null;
        }


    

        public void Slerp_In_Flowers()
        {
            spin_Flowers = true;
            ActivateReturnMenu(true, true);

            if(try_Again.activeSelf == false || back_To_Menu.activeSelf == false)
            {
                try_Again.SetActive(true);
                back_To_Menu.SetActive(true);
            }

            StartCoroutine(SlerpingFlowers());
        }


        IEnumerator SlerpingFlowers()
        {
            float time = 0f;
            float duration = 1f;

            yield return new WaitForSeconds(4);

            StartCoroutine(PanMoving_In());

            while(time < duration)
            {
                _flower_Menu.localPosition = Vector3.Slerp(  flowers_Start, flowers_End, time / duration);
               _flower_Menu.localScale = Vector3.Lerp( small_Flowers, large_Flowers, time / duration );
                time += Time.unscaledDeltaTime;
                yield return null;
            }  

            yield return new WaitForSeconds(1);
            text_Pan_a_TMPro.color = new Color(0, 0, 0, 1);
            text_Pan_b_TMPro.color = new Color(1, 1, 1, 1);

            for (int x = 0; x <= pan_Text_Rec.Length; x++)
            {
                StartCoroutine(Pans_Text_Box(pan_Text_Rec[x], 0f, "It's not her bed time yet,"));
                StartCoroutine(Pans_Text_Box(pan_Text_Rec[x], 2f, "try and win back your diginity!"));
            }
                StartCoroutine(First_2_5_Out(4f));
        }

        public void Reset_Flowers()
        {
             Debug.Log("reset flowers");
           // flowers_Particle_01.Stop();
           // flowers_Particle_02.Stop();
                spin_Flowers = false;
            _flower_Menu.localPosition = flowers_Start;
         _flower_Menu.localScale = small_Flowers;
        }


        public void Try_Again( )
        {
            start_Count = true;
            start_Game = true;

            switching_Menu = false;

            try_Again.SetActive(false);
            back_To_Menu.SetActive(false);

            _scoreScaling.Score_Text();
           StartOver();
            countDown.delay = 1f;
            start_Count = true;
            countDown.StartCount(2);
           // Pans_Text_Follows();
            endPosLeftOffScreen = new Vector3(-35f, 4f, 0);
           StartCoroutine(PanMoving_Out(5));
            StartCoroutine(Fade_Out_Text());
           

        }

        public void Try_Again_Star()
        {
            Try_Again();

                text_Pan_a_TMPro.text = text_For_Pan;
                text_Pan_b_TMPro.text = text_For_Pan;
                text_For_Pan = "That's right,";

            for (int x = 0; x <= pan_Text_Rec.Length - 1; x++)
            {
                _text_Is_This = true;
               
                StartCoroutine(Lerp_TMPro_Color_Alpha(list_TMPro[x], sunGlass_00, sunGlass_01, 0, 1.2f));
                StartCoroutine(Lerp_TMPro_Color_Alpha(list_TMPro[x], sunGlass_01, sunGlass_00, 3, 1.2f));
                //StartCoroutine(FadeOutCR(Pans_Rec, "fade", 2, "That's right,"));

               text_Pan_a_TMPro.color = new Color(0, 0, 0, 1);
               text_Pan_b_TMPro.color = new Color(1, 1, 1, 1);
               StartCoroutine(Pans_Text_Box(pan_Text_Rec[x], 5f, "give her the spanking she deserves!"));
            }

                flowers_Particle_01.Play();
                flowers_Particle_02.Play();
                Invoke("Reset_Flowers", 5);
                // Invoke("Pans_Text_DOESNT_Follow", 4);
        }


        IEnumerator Fade_Out_Text() // Fades text out from full alpha to zero alpha.
{
    float duration = 1f; 
    float currentTime = 0f;

                        while(currentTime < duration)
                        {
                            float alpha = Mathf.Lerp(1f, 0f, currentTime/duration);
                            _starGirlText.color = new Color(_starGirlText.color.r, _starGirlText.color.g, _starGirlText.color.b, alpha);
                            currentTime += Time.deltaTime;
                            yield return null;
                        }

}

         IEnumerator PanMoving_In()   
        {
            float time = 0f;
            float duration = 1f;

                    while(time < duration)
                    {
                        Pan.transform.position = Vector2.Lerp( endPosLeftOffScreen, gamePosLeft, time / duration );
                        time += Time.deltaTime;
                        yield return null;
                    }
                    
               ActivateReturnMenu(true, true);
               yield return null;
        }

        IEnumerator PanMoving_Out(float delay_Pan_Moving_out)   
        {
            float time = 0f;
            float duration = 3f;

            yield return new WaitForSeconds(delay_Pan_Moving_out);

                    while(time < duration)
                    {
                        Pan.transform.position = Vector2.Lerp(  gamePosLeft, endPosLeftOffScreen, time / duration );
                        time += Time.deltaTime;
                        yield return null;
                    }
               
               yield return null;
        }


       

    void Pans_Text_Follows()
    {
        // Sets "newParent" as the new parent of the child GameObject.

        for (int x = 0; x <= pan_Text_Rec.Length - 1; x++)
            {
                pan_Text_Rec[x].SetParent(Pan.GetComponent<Transform>());
            }

       

        // Same as above, except worldPositionStays set to false
        // makes the child keep its local orientation rather than
        // its global orientation.

        // child.transform.SetParent(newParent, false);
    }

    void Pans_Text_DOESNT_Follow()
    {
        // Setting the parent to ‘null’ unparents the GameObject
        // and turns child into a top-level object in the hierarchy

        text_Pan_a_TMPro.text = " ";
        text_Pan_a.transform.SetParent(null);
        text_Pan_b_TMPro.text = " ";
        text_Pan_b.transform.SetParent(null);
    }
    
    public void Start_The_Count()
    {
       StartCoroutine(countDown.MathfSin(3));
    }


     public void MovePan()
        {
            Debug.Log("StartMovePan");

            StartCoroutine(SlerpingIn());
            StartCoroutine(PanMoving());  // Try moving this to countdown and remove wait for seconds.

            if( start_Game)
            {
                // for (int x = 0; x <= pan_Text_Rec.Length - 1; x++)
                //    {
                //        StartCoroutine(Pans_Text_Box(pan_Text_Rec[x], 2f, "1st to <B><color=yellow>5</color></B> wins!"));
                    
                //    }

               StartCoroutine(First_2_5_In("1st to <B><color=yellow>5</color></B> wins!", 1));
            }

             if( !start_Game)
            {
                //for (int x = 0; x <= pan_Text_Rec.Length - 1; x++)
                //    {
                //        StartCoroutine(Pans_Text_Box(pan_Text_Rec[x], 2f, "That's the spirit!"));
                    
                //    }
               StartCoroutine(First_2_5_In("That's the spirit!", 1));
               
            }
        }


        IEnumerator SlerpingIn()
        {
            float time = 0f;
            float duration = .8f;
            
             yield return new WaitForSeconds(.6f);
            
                    while(time <= duration)
                    {
                       // panTrans.position = Vector3.Slerp(centerStart, centerEndLeft, time / duration);
                         panTrans.position = Vector3.Slerp(originalPos, gamePosLeft, time / duration);

                        panTrans.localScale = Vector2.Lerp(large, small, time / duration );
                        time += Time.deltaTime;
                        transform.position += center;
                        yield return null;
                    }

                panTrans.position = gamePosLeft;

            yield return new WaitForSeconds(.3f);

            _startFireWorks01.FireWorks01();
            _startFireWorks02.FireWorks02();
             _text01Score.StartText01();
            _textTwoScore.StartText02();
        }


        IEnumerator PanMoving()   
        {
            float time = 0f;
            float duration = 1f;

             yield return new WaitForSeconds(5.5f);

            if(  start_Game)
            {
                start_Game = false;
                StartCoroutine(First_2_5_Out(0f));
            }

                    while(time < duration)
                    {
                        panTrans.position = Vector2.Lerp(gamePosLeft, endPosLeftOffScreen, time / duration );
                        time += Time.deltaTime;
                        yield return null;
                    }
                    
               ActivateReturnMenu(true, true);
               
               yield return null;
        }


        public void StartSlerpingOut()
        {
            StartCoroutine(SlerpingOut());
        }

        IEnumerator SlerpingOut()
        {
            float time = 0f;
            float duration = 1f;
            
             endPosLeftOffScreen = panTrans.position;

            while(time < duration)
            {
                //panTrans.position = Vector3.Slerp(  centerOffScreen, centerStartLeft, time / duration);
                 panTrans.position = Vector3.Slerp(  endPosLeftOffScreen, originalPos, time / duration);
                panTrans.localScale = Vector2.Lerp( small, large, time / duration );
                time += Time.unscaledDeltaTime;
                transform.position += centerLeft;
                yield return null;
            }
        }


}

