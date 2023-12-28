

using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.Events; 
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;
//using System;


public class AHScriptManager : MonoBehaviour
{
    GameObject Testing_Tablet_Rep;


    [SerializeField] GameObject _puck;
    
    [SerializeField] GameObject _circleBackground;
                     GameObject prefabHolder;
                     GameObject pointEffectorCircle;
                     GameObject _startMenu;
                     GameObject _midGameMenu;
                     GameObject[] menuButtons;    
                     GameObject[] menuCircleScript;
                     GameObject star_Girl;
                     GameObject star_Boy;
               public GameObject character;
                     GameObject Pan;
                    GameObject opponent_Paddle;
                    GameObject menu_Frame;
                    PolygonCollider2D menu_Frame_Col;

GameObject textCountDown;
    CountDown _countDown;

GameObject backDropGlow;
SpriteRenderer backDropGlow_SR;
public float transparency;
public float changeSpeed;

GameObject _Score;
    ScoreScaling scoreScaling;

SpriteRenderer opponent_Paddle_SR;

public Sprite stars_Paddle;
public Sprite mopseys_Paddle;

public Sprite face_One;
public Sprite face_Two;
public Sprite face_Three;
	public	GameObject your_Paddle;
	public	SpriteRenderer your_Paddle_SR;

   public int moveForward;

Sprite opp_paddle_Sprite;

[SerializeField] Sprite heart_Sprite;

[SerializeField] Material heart_material;

Color litePink;
Color darkPink;

public Color32 color01;
public Color32 color02;


public List<Sprite> paddle_Face_List;
 public List<GameObject> gameObject_List; // = new List<GameObject>();
 public List<SpriteRenderer> sprite_Renderer_List;
public List<RectTransform> rec_List;

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

     Vector3 slerp_Center_Pos;

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


    [SerializeField] FlashFade _flashFade;
    [SerializeField] FlashFadeTop _flashFadeTop;

   
    public bool start_Game;


    public GameObject[] Bad_Arua;
    public float a = 1f;
    [SerializeField] Material bad_Arua;
    Color bad_Alpha;

    [SerializeField] ParticleSystem star_Is_Sad;
    Vector3 Stars_Starting_Position;
    Vector3 Stars_Ending_Position;

    Vector2 stars_Text_Box_Pos;
    Vector2 stars_Text_Box_Size;

    Vector2 stars_Text_Box_Pos_Losing;

    Vector2 stars_Pivot;

    ParticleSystem hearts_00_PS;
    ParticleSystem hearts_01_PS;
    ParticleSystem hearts_02_PS;
    ParticleSystem hearts_03_PS;
    ParticleSystem Opp_Paddle_PS;

    ParticleSystem bad_Hearts_00_PS;
    ParticleSystem bad_Hearts_01_PS;
    ParticleSystem bad_Hearts_02_PS;
    ParticleSystem bad_Hearts_03_PS;

    Renderer hearts_00_Renderer;
    Renderer hearts_01_Renderer;
    Renderer hearts_02_Renderer;
    Renderer hearts_03_Renderer; 

    Renderer Opp_Paddle_Renderer;


// Menu Stars.

    [SerializeField] GameObject menu_Star_01;
    [SerializeField] GameObject menu_Star_02;
    [SerializeField] GameObject menu_Star_03;
    [SerializeField] GameObject menu_Star_04;


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

    Vector3 endPosLeftOffScreen_Fixed;



    public bool switching_Menu;

  public bool start_Count;
  // GameObject textCountDown;

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


int arrayPos;
int[] orderList;


string trashTalk01;
string trashTalk02;
string sayStuff;
string text_Moves;
string text_effect;

public string pan_text_Intros_01;
public string pan_text_Intros_02;
public string pan_text_Intros_03;

public string firstToFive;


Vector2 textBox_width01;
Vector2 textBox_width02;

Vector2 textBox_width03;

[SerializeField] TMP_FontAsset star_Loses_Font;
[SerializeField] TMP_FontAsset stars_Font;

[SerializeField] TMP_FontAsset Mopsey_Loses_Font;
[SerializeField] TMP_FontAsset Mopseys_Font;

[SerializeField] TMP_FontAsset algies_Font;
[SerializeField] TMP_FontAsset algie_Loses_Font;

[SerializeField] SpriteRenderer _sunGlass;
bool no_Fade = false;
bool CR;

bool _text_Is_This;

#endregion Variables

        Color sunGlass_00;
		Color sunGlass_01;
int arrayNum;

        GameObject text_Pan;
        RectTransform text_Pan_Transform;
        //GameObject text_Pan;
        TextMeshPro text_Pan_TMPro;
        Vector3 center;

        Vector3 centerLeft;    

        Vector3 originalPos;   
   
        Vector3 large;   

        Vector3 small;   
       // Vector3 gamePosLeft;
        RectTransform panTrans;
        Vector3 _height_Point;
       Vector3 first_Curve_Height;

       Vector3 main_Cam_Pos;
       Vector3 main_Cam_Pos_Star;


    [SerializeField] StartFireWorks01 _startFireWorks01;
    [SerializeField] StartFireWorks02 _startFireWorks02;


    //public delegate void Lerp_Pos_Delegate();
    //public static event Lerp_Pos_Delegate lerp_Pos_Delegate;

    public delegate void Text_To_Use_Is();
    public static event Text_To_Use_Is  text_To_Use_Is;

    public delegate void Objects_Variables();
    public static event Objects_Variables objects_Variables;

    public delegate void Character_intro();
    public static event Character_intro character_Intro;

   // GameObject stars_Text_Box; 
   // TextMeshPro stars_TMPro; 
   // RectTransform stars_Text_Box_RecTrans;


    GameObject opponent_Text_Box;
    TextMeshPro opponent_TMPro;
    RectTransform opponent_Text_Box_Rec;


    Color mat_Color;

    Color stars_TMPro_Color; 

    Color algies_TMPro_Color; 




    GameObject boys_Text_Box; 
    TextMeshPro boys_TMPro; 
    RectTransform boys_Text_Box_RecTrans; 
    Color boys_TMPro_Color; 

    RectTransform text_Box_RecTransform;
    GameObject text_Box_Object;
    TextMeshPro tmpro_Object;
    
    GameObject player;

    bool function_Done;

    string _Pan_Says;
    public bool rec_Trans_Size_Bool;

    public bool lerp_TMPro_Color_Bool = false;

    public Color current_Color;

    public bool size_Object_Bool;
    public bool scale_Object_Bool;

public bool Pan_Leaves_Screen;

    Vector2 _start_Size_Y;

    Vector2 _mid_Size_Y;
    Vector2 _mid02_Size_Y;
    Vector2 _end_Size_Y;

    Vector2 _start_Size_X;
    Vector2 _end_Size_X ;

    bool openText_Bool = false;

    bool end_Lerp_TMPro_Color = false;

    bool end_Pan_Asks_U_To_tryAgain = false;

    public bool Pan_Asks_U_To_tryAgain_bool;

//StackTrace  stackTrace;
    Camera camera_01;



#region Mopsey_Variables

    GameObject mopseys_Visit; // Not in original
    GameObject good_Bunnies;
    GameObject attack_Bunnies;

    GameObject good_Bunny_01;
    GameObject good_Bunny_02;
    GameObject good_Bunny_03;
    
    GameObject mouth_01;
    GameObject bunny_01;
    GameObject bunny_01_Feet; 

    GameObject aB_Body_01;
    GameObject aB_Body_02;
    GameObject aB_Body_03;

    GameObject bunny_02;
    GameObject mouth_02;
    GameObject bunny_02_Feet;

    GameObject bunny_03;
    GameObject mouth_03;
    GameObject bunny_03_Feet;

    GameObject mopsey_Is_Happy;
    GameObject mopsey_Is_Angry;

    GameObject camera;
    GameObject second_Camera;
    // Camera main_Cam;

    GameObject dark_Overlay;
    GameObject square_Screen;
    GameObject square_Screen_Text;
    GameObject hungry_Container;
    GameObject hungry_Text_Box;



    GameObject hearts_00_GO;   // added.
    GameObject hearts_01_GO;   // added.
    GameObject hearts_02_GO;   // added.
    GameObject hearts_03_GO;   // added.

    GameObject bad_Hearts_00_GO;
    GameObject bad_Hearts_01_GO;
    GameObject bad_Hearts_02_GO;
    GameObject bad_Hearts_03_GO;

    GameObject mopseys_Entrance;
    GameObject mopseys_Exiting;


    GameObject opp_Mask; // added.



    RectTransform good_Bunnies_Rec;
    RectTransform attack_Bunnies_Rec;

    RectTransform good_Bunny_01_Rec;
    RectTransform good_Bunny_02_Rec;
    RectTransform good_Bunny_03_Rec;

    RectTransform mouth_01_Rec;
    RectTransform bunny_01_Rec;
    RectTransform bunny_01_Feet_Rec;

    RectTransform bunny_02_Feet_Rec;
    RectTransform mouth_02_Rec;
    RectTransform bunny_02_Rec;

    RectTransform bunny_03_Feet_Rec;
    RectTransform mouth_03_Rec;
    RectTransform bunny_03_Rec;

    RectTransform mopsey_Is_Happy_Rec;
    RectTransform mopsey_Is_Angry_Rec;
    //RectTransform opponent_Text_Box_Rec;

    RectTransform camera_Rect;
    RectTransform second_Camera_Rect;

    RectTransform square_Screen_Text_Rec;

    Rigidbody2D good_Bunny_03_Rb;


    SpriteRenderer dark_Overlay_Renderer;
    SpriteRenderer square_Screen_Renderer;

    Color square_Screen_Color;
    Color square_Screen_Color_01;

    Color full_Alpha;
    Color zero_Alpha;

    Color32 mopseys_Text_Color;

    public Quaternion camera_Rect_Rotation;



    TextMeshPro square_Screen_Text_TMPro;
    TextMeshPro hungry_Text_TMPro;
    TextMeshPro mopsey_Text_Box_TMPro;

    Vector2 mopseys_Pivot;
    Vector3 _start_Size;
    Vector3 _end_Size;

   public Vector3 start_Pos_Bunny_01;
   public Vector3 end_Pos_Bunny_01;

    Vector3 Mouth_Wide_Size;
    Vector3 mouth_Close_Size;

    Vector3 Mouth_Wide_Size_02;
    Vector3 mouth_Close_Size_02;

    Vector3 Mouth_Wide_Size_03;
    Vector3 mouth_Close_Size_03;


    Vector3 body_forward_Size;
    Vector3 body_norm_Size;

    Vector3 body_forward_Size_02;
    Vector3 body_norm_Size_02;

    Vector3 body_forward_Size_03;
    Vector3 body_norm_Size_03;

    Vector3 bunny_02_Feet_Start;
    Vector3 bunny_02_Feet_Forward;

    Vector3 start_Pos;
    Vector3 finish_Pos;
    Vector3 original_Center;

    Vector3 _center_Point;

    Vector3 new_Center;

     Vector3 camera_Start_Pos; 

     //Vector3 camera_Zoom_Pos;

    Vector3 mopseys_Box_Fullsize;
    Vector3 mopseys_Box_Yis0;

    //float cx;
    //float cy;
    [SerializeField] Vector3 scale_01;
    [SerializeField] Vector3 scale_00;
    [SerializeField] Vector3 scale_Y_00;

    Vector3 opp_Mask_Pos;

    Vector3 opp_Mask_Center;

    Vector3 opp_Mask_Lower;

    

    Vector3 Mopsey_Text_Origin_Pos;
    Vector3 Mopsey_Text_Start_Pos; 
    Vector3 Mopsey_Text_Hello_Pos;

    Vector3 Mopsey_Text_OffSet_Center01;
    Vector3 Mopsey_Text_OffSet_Center02;

    Vector3 slerp_Center_Pos_02;

    Vector3 bunny_3_Pos;

    public int diff_Level;
    public float slerp_Center_Offset;

    public float speed;

    float perlinFloat;

    float camera_x;
    float camera_y;

    public float size;

    public float range;

    public float duration;

   public float main_Cam_Size;
   public float main_Cam_Size_Star;

    bool move_Object_Math_Bool;

   // bool size_Object_Bool;
    //bool scale_Object_Bool;
    public bool Move_Object_Bounce_Bool;
    public bool rotate_Object_Bool;

    public bool glow_On = false;

    public bool IsCanceled;
    public static List<bool> scale_Object_List = new List<bool>();
    public static List<bool> rotate_Object_List = new List<bool>();

    public Sprite[] paddle_Face_Array;
    
    [SerializeField]TMP_FontAsset oh_No;
    [SerializeField]TMP_FontAsset hungry;
	float oh_No_font_Size;
	Color oh_No_new_Color;
    Color oh_No_new_Color_01;
    float hungry_font_Size;
	Color hungry_new_Color;
    Color hungry_new_Color_01;
	float alpha_TMPro_00;
    float alpha_TMPro_01;

    string bunnies_Text;

   public bool stop_Routine;

   
public float pulse_Speed;


    #endregion Mopsey_Variables


#region Mopseys_Carrot_Menu
    GameObject carrots;
 GameObject Carrot_Left_Glow;

GameObject Carrot_Bitten_Glow;

GameObject carrot_Right;

GameObject open_Mouth;

    Vector3 down;
    Vector3 up;

 Vector3 good_Bunny3_Start_Pos;
 Vector3 good_Bunny3_End_Pos;
 
Vector3 zero;
Vector3 one;

 SpriteRenderer Carrot_Left_Glow_SR;
 SpriteRenderer Carrot_Bitten_Glow_SR;
 Color color_Max;
 Color color_Zero;

 Color show_Color;
 Color alpha_Zero;
 private Animator left_Bunnies_Animator; 
 
 #endregion Mopseys_Carrot_Menu

    #region Delegates

    // public delegate void Character();
	// public static event Character character;


	public delegate void Character_Dialogue();
	public static event Character_Dialogue character_Dialogue;

	public delegate void Character_Wins();
	public static event Character_Wins character_Wins;


string pan_Try_Again_Text_01;

string pan_Try_Again_Text_02;

string char_Try_Again_Text_01;

string char_Try_Again_Text_02;
		
string pan_Try_Again_Exit;


public delegate void Character_Try_Again();
public static event Character_Try_Again character_Try_Again;
	
    
    public delegate void Win_Try_Again();
    public static event Win_Try_Again win_Try_Again;
    

	public delegate void Character_Loses();
	public static event Character_Loses character_Loses;

   // public delegate void Play_Paddle_Intro();
	// public static event Play_Paddle_Intro  play_Paddle_Intro;

    public delegate void Play_Paddle_Exit();
	public static event Play_Paddle_Exit  play_Paddle_Exit;

    #endregion Delegates

    public bool speedUp;
    public int paddle_Array_Pos;

    public string[] paddle_Trash_Talk_Array;

    public Sprite[] paddle_Fight_Sprites;
    public Sprite[] paddle_Win_Sprites;
    public Sprite[] paddle_Lose_Sprites;

    string fadeOutCR_Pick_01;
    string fadeOutCR_Pick_02;

    void Start()
    {  
        Pan_Leaves_Screen = true;
        speedUp = false;
       //  moveForward = 0;
        _start_Size_Y = new Vector2(6, 0);
        _mid_Size_Y = new Vector2(6, 1);
        _mid02_Size_Y = new Vector2(6, 4);
        _end_Size_Y = new Vector2(5, 5);

        _start_Size_X = new Vector2(0, 5);
        _end_Size_X = new Vector2(5, 5);

        Pan = GameObject.FindGameObjectWithTag("Pan");
        panTrans = Pan.GetComponent<RectTransform>();

        backDropGlow = GameObject.FindGameObjectWithTag("BackDropGlow");
        backDropGlow_SR = backDropGlow.GetComponent<SpriteRenderer>();

        // paddle_Face_List = new List<Sprite>();

        // gameObject_List = new List<GameObject>();
        
        

        _height_Point = new Vector3(-20, -2, 0);
        first_Curve_Height = new Vector3(-14, -2, 0);
        slerp_Center_Pos = new Vector3(0, -8, 0);
        slerp_Center_Pos_02 = new Vector3(0, -7, 0);
        endPosLeftOffScreen = new Vector3(-22f, 4f, 0);
        endPosLeftOffScreen_Fixed = new Vector3(-22f, 4f, 0);

        center = originalPos * 0.5f;   // Originally - center = (originalPos + gamePos)* 0.5f;


   

        centerLeft = (endPosLeftOffScreen + originalPos) * .2f;

        originalPos = new Vector3(-9f, -3.5f, 0);

        gamePosLeft = new Vector3(-13f, 4f, 0);

        large = new Vector3(1.2f, 1f, 0 );

        small = new Vector3(1f, .8f, 0 );

        text_Pan = GameObject.FindGameObjectWithTag("PanText");
        text_Pan_Transform = text_Pan.GetComponent<RectTransform>();
        text_Pan_TMPro = text_Pan.GetComponent<TextMeshPro>();

        text_Pan_TMPro.color = new Color(0f, 0f, 0f, 0);

        sunGlass_00 = new Color(1, 1, 1, 0);
		sunGlass_01 = new Color(1, 1, 1, 1f);

        current_Color = sunGlass_01;

        _sunGlass.material.color = sunGlass_00;


        // worked here Test_Function();

   textCountDown = GameObject.FindGameObjectWithTag("TextCountDown");
		_countDown =  textCountDown.GetComponent<CountDown>();

        _Score = GameObject.FindGameObjectWithTag("Score");
		scoreScaling =  _Score.GetComponent<ScoreScaling>();

        flowers_Particle_01 = _flowers_Particles_01.GetComponent<ParticleSystem>();
        flowers_Particle_02 = _flowers_Particles_02.GetComponent<ParticleSystem>();
        star_Is_Happy = _star_Is_Happy.GetComponent<ParticleSystem>();

        star_Is_Happy.Stop();

        
        textCountDown = GameObject.FindGameObjectWithTag("TextCountDown");
        countDown = textCountDown.GetComponent<CountDown>();
        star_Girl = GameObject.FindGameObjectWithTag("Star_Girl");
        star_Boy = GameObject.FindGameObjectWithTag("StarBoy");
        Bad_Arua = GameObject.FindGameObjectsWithTag("Bad_Arua");

        // worked here Test_Function();

        opponent_Paddle = GameObject.FindGameObjectWithTag("Opponent");
        opponent_Paddle_SR = opponent_Paddle.GetComponent<SpriteRenderer>();


		your_Paddle = GameObject.FindGameObjectWithTag("Player");
        your_Paddle_SR = your_Paddle.GetComponent<SpriteRenderer>();

       // Opp_Paddle_PS = opponent_Paddle.GetComponent<ParticleSystem>();

        // Opp_Paddle_Renderer = Opp_Paddle_PS.GetComponent<Renderer>();

       
       // Opp_Paddle_PS.Stop();

        hearts_00_GO = GameObject.FindGameObjectWithTag("Hearts_00");
        hearts_00_PS = hearts_00_GO.GetComponent<ParticleSystem>();
        hearts_00_Renderer = hearts_00_PS.GetComponent<Renderer>();

        hearts_01_GO = GameObject.FindGameObjectWithTag("Hearts_01");
        hearts_01_PS = hearts_01_GO.GetComponent<ParticleSystem>();
        hearts_01_Renderer = hearts_01_PS.GetComponent<Renderer>();

        hearts_02_GO = GameObject.FindGameObjectWithTag("Hearts_02");
        hearts_02_PS = hearts_02_GO.GetComponent<ParticleSystem>();
        hearts_02_Renderer = hearts_02_PS.GetComponent<Renderer>();

        hearts_03_GO = GameObject.FindGameObjectWithTag("Hearts_03");
        hearts_03_PS = hearts_03_GO.GetComponent<ParticleSystem>();
        hearts_03_Renderer = hearts_03_PS.GetComponent<Renderer>();

       


        bad_Hearts_00_GO = GameObject.FindGameObjectWithTag("Bad_Hearts_00");
        bad_Hearts_00_PS = bad_Hearts_00_GO.GetComponent<ParticleSystem>();

        bad_Hearts_01_GO = GameObject.FindGameObjectWithTag("Bad_Hearts_01");
        bad_Hearts_01_PS = bad_Hearts_01_GO.GetComponent<ParticleSystem>();

        bad_Hearts_02_GO = GameObject.FindGameObjectWithTag("Bad_Hearts_02");
        bad_Hearts_02_PS = bad_Hearts_02_GO.GetComponent<ParticleSystem>();

        bad_Hearts_03_GO = GameObject.FindGameObjectWithTag("Bad_Hearts_03");
        bad_Hearts_03_PS = bad_Hearts_03_GO.GetComponent<ParticleSystem>();



        start_Count = true;

        spin_Flowers = false;
        flower_Speed_01 = 5f;
        flower_Speed_02 = 5f;
       
        
        
        flowers_Start = new Vector3(0, -3, 0);
        flowers_End = new Vector3(-5, 0, 0);
        small_Flowers = new Vector3(0, 0, 0);
        large_Flowers = new Vector3(1, 1, 1);

        scale_01 = new Vector3(1, 1, 1);
        scale_00 = new Vector3(0, 0, 0);
        scale_Y_00 = new Vector3(1, 0, 0);

        bad_Alpha = bad_Arua.color;

        Stars_Starting_Position = star_Girl.transform.position;

        Stars_Ending_Position = new Vector3(-40, star_Girl.transform.position.y, 0);

        stars_Text_Box_Pos = new Vector2(-5.5f, -.75f);
        stars_Text_Box_Size = new Vector2(9.9f, 1.4f);
        stars_Text_Box_Pos_Losing = new Vector2(-4.2f, -.75f);

        stars_Pivot = new Vector2(1, .5f);

        mopseys_Pivot = new Vector2(0.5f, 0);

        start_Game = true;

        restoreMenuRunning = false;

        _lettersPos = new Vector2[_menuLetters.Length];



        for(int i = 0; i < _menuLetters.Length; i++)
        {
            Vector2 pos = _menuLetters[i].transform.position;
            _lettersPos[i] = pos;
           
        }

        _maxPuckSpeed = 0;
        _maxAISpeed = 0;
        
 
        centerScreenCB = new Vector3(0, 0, 0);
        offScreenCB = new Vector3(0, 21f, 0);

        main_Cam_Pos = new Vector3(0, 0, -10);
        main_Cam_Pos_Star = new Vector3(-8.45f, -3.7f, -10);

        main_Cam_Size = 10;
       main_Cam_Size_Star = 7f;

    IsCanceled = false;

        zeroish = new Vector3(.01f, .01f, 0f); // Used for setting vector to almost zero. 

        bad_Alpha.a = 0;  

        bad_Arua.color = bad_Alpha;

        gamePosLeft = new Vector3(-13f, 4f, 0);

        // endPosLeftOffScreen = new Vector3(-19f, 4f, 0);



        opponent_Text_Box = GameObject.FindGameObjectWithTag("Opponent_Text_Box");
        opponent_TMPro = opponent_Text_Box.GetComponent<TextMeshPro>();
        opponent_Text_Box_Rec = opponent_Text_Box.GetComponent<RectTransform>();


        boys_Text_Box = GameObject.FindGameObjectWithTag("Text_Boy");
        boys_TMPro = boys_Text_Box.GetComponent<TextMeshPro>();
        boys_Text_Box_RecTrans = boys_Text_Box.GetComponent<RectTransform>();
        boys_TMPro_Color = boys_TMPro.GetComponent<TextMeshPro>().color;

        textBox_width01 = new Vector2(0, 1);
        textBox_width02 = new Vector2(11, 1);

        _text_Is_This = false;

        paddle_Array_Pos = 0;

        
             paddle_Trash_Talk_Array = new string[5];

        paddle_Trash_Talk_Array[0] = "Make my Day!";
        paddle_Trash_Talk_Array[1] = "Yippee ki yay!";
        paddle_Trash_Talk_Array[2] = "You lookin' at me?";
        paddle_Trash_Talk_Array[3] = "Feelin' lucky?";
        paddle_Trash_Talk_Array[4] = "You're goin' DOWN!";


        

#region Mopsey_Start

        opp_Mask = GameObject.FindGameObjectWithTag("Opp_Mask");
        opp_Mask_Pos = new Vector3(-8.37f, 7.5f, 0);
        opp_Mask_Center =  new Vector3(-8.37f, -2.2f, 0);
        opp_Mask_Lower = new Vector3(-8.37f, -11.5f, 0);

        mopseys_Text_Color = new Color32(245, 156, 156, 255);

        // Start, end and center offset postions for Mopsey saying HI, 
        // taking in to account pivot location changing do to scaling.
        Mopsey_Text_Origin_Pos =new Vector3(-10.55f, 2.25f, 0); //  new Vector3(-11.5f, -2.8f, 0); 
        Mopsey_Text_Start_Pos = new Vector3(-8.3f, -2.5f, 0);
        Mopsey_Text_Hello_Pos = new Vector3(-11.5f, -2.8f, 0);
        Mopsey_Text_OffSet_Center01 = new Vector3(-11, -4);
        Mopsey_Text_OffSet_Center02 = new Vector3(-7f, -2.5f);

        mopseys_Box_Fullsize = new Vector3(5.3f, 6.5f, 0);
        mopseys_Box_Yis0 = new Vector3(5.5f, 0, 0);

        camera = GameObject.FindGameObjectWithTag("MainCamera");
        camera_Rect = camera.GetComponent<RectTransform>();
        camera_01 = Camera.main;
        //camera_01 = camera.GetComponent<Camera>().main;

        second_Camera = GameObject.FindGameObjectWithTag("Second_Camera");
        second_Camera_Rect = second_Camera.GetComponent<RectTransform>();

        // working here  Test_Function();

        mopseys_Visit = GameObject.FindGameObjectWithTag("Mopseys_Visit");

        attack_Bunnies = GameObject.FindGameObjectWithTag("Attack_Bunnies");
        attack_Bunnies_Rec = attack_Bunnies.GetComponent<RectTransform>();

        good_Bunnies = GameObject.FindGameObjectWithTag("Good_Bunnies");
        good_Bunnies_Rec = good_Bunnies.GetComponent<RectTransform>();

    // working here Test_Function();

        good_Bunny_01 = GameObject.FindGameObjectWithTag("Good_Bunny_01");
        good_Bunny_01_Rec = good_Bunny_01.GetComponent<RectTransform>();

        good_Bunny_02 = GameObject.FindGameObjectWithTag("Good_Bunny_02");
        good_Bunny_02_Rec = good_Bunny_02.GetComponent<RectTransform>();

        good_Bunny_03 = GameObject.FindGameObjectWithTag("Good_Bunny_03");
        good_Bunny_03_Rec = good_Bunny_03.GetComponent<RectTransform>();
        good_Bunny_03_Rb = good_Bunny_03.GetComponent<Rigidbody2D>();

        mouth_01 = GameObject.FindGameObjectWithTag("Mouth_01");
        mouth_01_Rec = mouth_01.GetComponent<RectTransform>();

        bunny_01 = GameObject.FindGameObjectWithTag("Bunny01");
        bunny_01_Rec = bunny_01.GetComponent<RectTransform>();

        bunny_01_Feet = GameObject.FindGameObjectWithTag("AB_Front_Feet");
        bunny_01_Feet_Rec = bunny_01_Feet.GetComponent<RectTransform>();

    // working here Test_Function();

        bunny_02 = GameObject.FindGameObjectWithTag("Bunny02");
        bunny_02_Rec = bunny_02.GetComponent<RectTransform>();

        mouth_02 = GameObject.FindGameObjectWithTag("Mouth02");
        mouth_02_Rec = mouth_02.GetComponent<RectTransform>();

        bunny_02_Feet = GameObject.FindGameObjectWithTag("AB_Right_Feet");
        bunny_02_Feet_Rec = bunny_02_Feet.GetComponent<RectTransform>();


        bunny_03 = GameObject.FindGameObjectWithTag("Bunny03");
        bunny_03_Rec = bunny_03.GetComponent<RectTransform>();

        mouth_03 = GameObject.FindGameObjectWithTag("Mouth03");
        mouth_03_Rec = mouth_03.GetComponent<RectTransform>();

        bunny_03_Feet = GameObject.FindGameObjectWithTag("AB_Left_Feet");
        bunny_03_Feet_Rec = bunny_03_Feet.GetComponent<RectTransform>();

        mopsey_Is_Happy = GameObject.FindGameObjectWithTag("Mopsey");
        mopsey_Is_Happy_Rec = mopsey_Is_Happy.GetComponent<RectTransform>();

        mopsey_Is_Angry = GameObject.FindGameObjectWithTag("Mopsey_Is_Angry");
        mopsey_Is_Angry_Rec = mopsey_Is_Angry.GetComponent<RectTransform>();

        mopseys_Entrance = GameObject.FindGameObjectWithTag("Mopseys_Entrance");


        mopseys_Exiting = GameObject.FindGameObjectWithTag("Mopseys_Exiting");

        // working here Test_Function();

        square_Screen = GameObject.FindGameObjectWithTag("Square_Screen");
        square_Screen_Renderer = square_Screen.GetComponent<SpriteRenderer>();

        square_Screen_Text = GameObject.FindGameObjectWithTag("square_Screen_Text_Box");
        square_Screen_Text_Rec = square_Screen_Text.GetComponent<RectTransform>();
        square_Screen_Text_TMPro = square_Screen_Text.GetComponent<TextMeshPro>();

       // working here  Test_Function();

        dark_Overlay = GameObject.FindGameObjectWithTag("Dark_Overlay");
        dark_Overlay_Renderer = dark_Overlay.GetComponent<SpriteRenderer>();

        // woking here Test_Function();

        hungry_Container = GameObject.FindGameObjectWithTag("Hungry");
        hungry_Text_Box = GameObject.FindGameObjectWithTag("Hungry_Text");
        hungry_Text_TMPro = hungry_Text_Box.GetComponent<TextMeshPro>();

    
        oh_No_font_Size = 36;
        oh_No_new_Color = new Color32(240, 200, 200, 0);
        oh_No_new_Color_01 = new Color32(240, 200, 200, 255);
        hungry_font_Size = 36;
        hungry_new_Color = new Color32(130, 0, 0, 0);
        hungry_new_Color_01 = new Color32(159, 7, 7, 255);
        alpha_TMPro_00 = 0;
        alpha_TMPro_01 = 1;



        body_norm_Size =  new Vector3(1f, 1f, 0);
        body_forward_Size =  new Vector3(9f, 9f, 0);

        body_forward_Size_02 =  new Vector3(6f, 6f, 0);
        body_norm_Size_02 =  new Vector3(1f, 1f, 0);

        body_forward_Size_03 =  new Vector3(6f, 6f, 0);
        body_norm_Size_03 =  new Vector3(1f, 1f, 0);

        Mouth_Wide_Size = new Vector3(1f, 1f, 0);
        mouth_Close_Size = new Vector3(0f, 0f, 0);

        bunny_02_Feet_Start = new Vector3(1.2f, 1.2f , 0);
        bunny_02_Feet_Forward = new Vector3(1.6f, 1.6f, 0);
#endregion Mopsey_Start

#region Mopsey_Carrot_Menu_Start

        carrots = GameObject.FindGameObjectWithTag("Carrots");
        carrot_Right = GameObject.FindGameObjectWithTag("Carrot_Right");
        open_Mouth = GameObject.FindGameObjectWithTag("Open_Mouth");

        up = new Vector3(0, 1, 0);
       down = new Vector3(0f, -7f, 0); 

        good_Bunny3_Start_Pos = new Vector3(-6.6f, -6.7f, 0);
        good_Bunny3_End_Pos = new Vector3(-8.0f, -6.7f, 0);

        zero = new Vector3(0, 0, 0);
        one = new Vector3(1, 1, 1);

		left_Bunnies_Animator = good_Bunny_03.GetComponent<Animator>();
  
		Carrot_Left_Glow = GameObject.FindGameObjectWithTag("Carrot_Left_Glow");
        
		Carrot_Left_Glow_SR = Carrot_Left_Glow.GetComponent<SpriteRenderer>();

        Carrot_Bitten_Glow = GameObject.FindGameObjectWithTag("Carrot_Right_Glow");
		Carrot_Bitten_Glow_SR = Carrot_Bitten_Glow.GetComponent<SpriteRenderer>();

        show_Color = Carrot_Left_Glow_SR.material.color;

		color_Max = new Color(show_Color.r ,show_Color.g , show_Color.b, 1.1f);
		color_Zero = new Color(show_Color.r ,show_Color.g , show_Color.b, 0);

		Carrot_Left_Glow_SR.material.color = color_Zero; 		
        Carrot_Bitten_Glow_SR.material.color = color_Zero; 
		
        
		
#endregion Mopsey_Carrot_Menu_Start

        hungry_Container.SetActive(false);
        //mopsey_Text_Box.SetActive(false);
        square_Screen_Text.SetActive(false);    
        square_Screen.SetActive(false);         
        dark_Overlay.SetActive(false);
        mopseys_Visit.SetActive(false);
        second_Camera.SetActive(false);


        Pick_Opponent("Star");
        StartCoroutine(StartFirstMenu());
        Set_Random_Array();

        no_Fade = false;

        Pan.transform.localScale = large;

        pan_text_Intros_01 = " ";
        pan_text_Intros_02 = " ";
        pan_text_Intros_03 = " ";
    
    //bunny_3_Pos = bunny_03_Rec.position;
    //bunny_3_Pos.y = Mathf.Clamp(bunny_3_Pos.y, -7.23f, 7.0f);
      
       Pick_Player();

       firstToFive = "1st to <B><color=yellow>5</color></B> wins!";

       litePink = new Color32(250, 192, 192, 255);
        darkPink = new Color32(238, 134, 134, 255);

        stars_TMPro_Color = new Color32(255, 255, 255, 255);

        character = star_Girl;

    }




        void Update()
        {
        
             alpha02 = _ringFillAlpha.a;  

/*
                if(spin_Flowers)
                    {
                        menu_Flower_01.transform.Rotate( rotate_Flower * flower_Speed_01 * Time.deltaTime);
                        menu_Flower_02.transform.Rotate( rotate_Flower * flower_Speed_02 * Time.deltaTime);
                    }

                     if(spin_Flowers)
                    {
                        menu_Star_01.transform.Rotate( rotate_Flower * flower_Speed_01 * Time.deltaTime);
                        menu_Star_02.transform.Rotate( rotate_Flower * flower_Speed_02 * Time.deltaTime);
                         menu_Star_03.transform.Rotate( rotate_Flower * flower_Speed_01 * Time.deltaTime);
                        menu_Star_04.transform.Rotate( rotate_Flower * flower_Speed_02 * Time.deltaTime);

                    }
  */            

            if(Pan)
            {
                backDropGlow_SR.color = new Color(1, 1, 1, transparency);
                float pingpong = Mathf.PingPong((Time.time) * changeSpeed, 1);
                transparency = Mathf.Lerp(.5f, 1f, pingpong);
            }



            if (Input.GetKeyUp(KeyCode.S))
        {
                 StartCoroutine(Unfreeze(good_Bunny_03_Rb, .1f));
        }

             if (Input.GetKeyDown(KeyCode.W))
        {
                   StartCoroutine(Freeze(good_Bunny_03_Rb, 0f));
        }



        }


public void Test_Function()
{
    Debug.Log("Testing function.");
}




        IEnumerator Enter_Mopsey_Test()
        {
            star_Girl.SetActive(false);
            yield return new WaitForSeconds(3);
        }

public void Pick_Opponent(string opponent)
{
    if(opponent == "Star")
    {
      if(character != null)
      { 
        character.SetActive(false);
        character = null;
      }
        character_Dialogue = null;
        character_Intro = null;
        character_Wins = null;
        win_Try_Again = null;
       character_Try_Again = null;
        character_Loses = null;

        character = star_Girl;
        character_Dialogue += Stars_Dialogue; // is used to start text.
        character_Wins += Star_Wins;
       // win_Try_Again += Star_Try_Again;
        character_Try_Again += Star_Try_Again;
        character_Loses += Star_Loses;

        // Set characters beginning settings.
        character.SetActive(true);
        Change_Opponent_Text_Box (stars_Text_Box_Size, stars_Text_Box_Pos, stars_Pivot, stars_Font, stars_TMPro_Color, 10);
        mat_Color = bad_Arua.color;
        bad_Arua.color = new Color(mat_Color.r, mat_Color.g, mat_Color.b, 0);
        star_Girl.transform.position = Stars_Starting_Position;  
        opponent_Paddle_SR.sprite = stars_Paddle; 
        opponent_Paddle.SetActive(true);

        Reset_Flowers();
    }

    if(opponent == "Mopsey")
    {
        Debug.Log("Mopsey starting...");

        character.SetActive(false);
        character = null;
        character_Dialogue = null;
        character_Intro = null;
        character_Wins = null;
        character_Loses = null;
        character_Try_Again = null;
                
        character = mopseys_Visit;
        character_Dialogue += Mopseys_Dialogue;  //  not used yet
        character_Intro += Mopseys_Intro_Start;
        character_Wins += Mopsey_Wins;
        character_Loses += Mopsey_Loses;
        character_Try_Again += Mopsey_Try_Again;

        mopseys_Visit.SetActive(false);
        mopsey_Is_Angry.SetActive(false);
        attack_Bunnies.SetActive(false);

        good_Bunny_01_Rec.localScale = scale_00 ;
        good_Bunny_02_Rec.localScale = scale_00 ;
        good_Bunny_03_Rec.localScale = scale_00 ;
        // good_Bunny_03_Rec.position.y = Mathf.Clamp(good_Bunny_03_Rec.position.y, -7.23f, 7.0f);
        opponent_Text_Box_Rec.localScale = scale_00;
       opp_Mask.transform.position =  opp_Mask_Pos; 
       // play_Paddle_Intro += Mopseys_Paddle_Intro;
      //  play_Paddle_Exit += Mopseys_Paddle_Exit;

        // Carrot_Bitten_Glow.SetActive(false);


        Change_Opponent_Text_Box(mopseys_Box_Fullsize, Mopsey_Text_Start_Pos, mopseys_Pivot, Mopseys_Font, mopseys_Text_Color, 10);

            tmpro_Object.alignment = TextAlignmentOptions.Top;
            tmpro_Object.enableWordWrapping = true;

    }

/*
    if(opponent == "Algernon") // mouse with huge ego about his intelligence.
    {
        FlashFade.character += Algies_Variables;
        FlashFade.character_Dialogue += Algies_Dialogue;
        FlashFade.character_Wins += Algies_Wins;
        FlashFade.character_Loses += Algies_Loses;
    }
*/


}

public void Characters_Text()
{
       

					if(character_Dialogue != null)
					{
						character_Dialogue();
					}
}

public void Start_Character_Loses()
	{
        tmpro_Object = opponent_TMPro;

        if(character_Loses != null)
					{
						character_Loses();
					}
	}

public void Start_Character_Wins()
	{
        tmpro_Object = opponent_TMPro;

        if(character_Loses != null)
					{
						character_Wins();
					}
	}    

public void Pick_Player()
{
    if(star_Boy)
    {
        
        FlashFadeTop.player_Dialogue += Boys_Dialogue;
   
    }
}

#region -----Objects variables-----



void Pan_Intros(string character)
		{
			if(character == "Mopsey")
			{
			    pan_text_Intros_01 =  "Congrats! \nYou showed \nthat toddler \nwho's boss." ;
			    pan_text_Intros_02 =  "Ready to take \nit out of the \nnursery?";
			    pan_text_Intros_03 =  "Meet - " ;
			}
			

		}

    public void Change_Opponent_Text_Box (Vector2 box_Size, Vector2 box_Pos, Vector2 pivot_Point, TMP_FontAsset new_Font, Color font_Color, float font_Size)
    {
        opponent_Text_Box_Rec.sizeDelta = box_Size;  // set text box size.
        opponent_Text_Box_Rec.position = box_Pos;   // set text box position
        opponent_TMPro.font = new_Font;   // SET FONT.
        opponent_TMPro.fontSize = font_Size;   // set font color.
        opponent_TMPro.color = font_Color;   // SET FONT SIZE.
        opponent_Text_Box_Rec.pivot = pivot_Point;
    }

#endregion -----Objects variables-----

#region -----Coroutines-----      

                            // Switch secs_To_Wait and duration.

        IEnumerator Lerp_Color_Alpha(SpriteRenderer sprite_Renderer, Color start_Color, Color end_Color, float duration, float secs_To_Wait)
		{
            sprite_Renderer_List.Add(sprite_Renderer);

			 yield return new WaitForSeconds(secs_To_Wait);  

			float start_Point = 0;

			 while(start_Point < duration)
			{
				sprite_Renderer.material.color = Color.Lerp( start_Color , end_Color ,  start_Point / duration) ;
               
				start_Point += Time.unscaledDeltaTime;
				yield return null ;

                sprite_Renderer_List.Remove(sprite_Renderer);
			}		
		}


        IEnumerator Lerp_TMPro_Color_Alpha(TextMeshPro _textMeshPro, Color start_Color, Color end_Color, float secs_To_Wait,  float duration)
		{
                lerp_TMPro_Color_Bool = true;
			 yield return new WaitForSeconds(secs_To_Wait);  

			float start_Point = 0;
            _textMeshPro.color =  start_Color;

			 while(start_Point < duration)
			{
				_textMeshPro.color = Color.Lerp( start_Color , end_Color ,  start_Point / duration) ;
               
				start_Point += Time.unscaledDeltaTime;

                if(end_Lerp_TMPro_Color)
                {
                    end_Lerp_TMPro_Color = false;
                    yield break;
                }

				yield return null ;
			}		
               lerp_TMPro_Color_Bool = false;	
		}

    public IEnumerator Color_Pulse(SpriteRenderer renderer, Color color001, Color color002, float duration, float speed)
{

Color color_Start = renderer.color; // current color of game object.
float tt =0;


if(stop_Routine == false) // loops will only run if this bool is true. Call stop_Routines() function to change to false.
{
    stop_Routine = true;
}

	while( tt < duration) // Duratin adjest how long it takes to change color.
	{
       
          if(stop_Routine == false) // used to stop coroutine.
        {
            yield break;
        }
    tt += Time.deltaTime / 1.0f;
     renderer.color = Color.Lerp(color_Start, color001, tt ); // Change from current color to new color.
     // tt += .01f; 
      yield return null;
    }

   

     while( true)
    { 
       //  Debug.Log("bool is " + stop_Routine); // used to stop coroutine.

        if(stop_Routine == false)
        {
            yield break;
        }
                    // loop through new color and secondary color.
        renderer.color = Color.Lerp(color001, color002, Mathf.PingPong(Time.time * speed, 1)); // speed adjusts how fast colors loop.
        yield return null;
    }
    
}


 

public void Start_Color_Pulse(SpriteRenderer renderer, Color color001, Color color002, float duration, float speed)
{
    StartCoroutine(Color_Pulse(your_Paddle_SR, color001, color002, duration, speed));
}


public void stop_Routines()
{
    StopAllCoroutines();
    stop_Routine = false;
}



/*    IEnumerator Lerp_Transform_Position(GameObject object_To_Lerp, Vector3 start_Lerp_Pos, Vector3 end_Lerp_Pos, float wait_For_Sec, float duration )
        {
           
                float time = 0f;
                yield return new WaitForSeconds( wait_For_Sec );
                
                while(time < duration)
                {
                    object_To_Lerp.transform.localPosition = Vector3.Lerp( start_Lerp_Pos, end_Lerp_Pos, time / duration );
                    time += Time.unscaledDeltaTime;
                    yield return null;
                }
        } 
 */       
        IEnumerator Lerp_Transform_Position(GameObject object_To_Lerp, Vector3 start_Lerp_Pos, Vector3 end_Lerp_Pos, float duration, float wait_For_Sec )
        {
           gameObject_List.Add(object_To_Lerp);

                float time = 0f;
                yield return new WaitForSeconds( wait_For_Sec );
                
                while(time < duration)
                {
                    object_To_Lerp.transform.localPosition = Vector3.Lerp( start_Lerp_Pos, end_Lerp_Pos, time / duration );
                    time += Time.unscaledDeltaTime;
                    yield return null;
                }

                gameObject_List.Remove(object_To_Lerp);
        } 


        public async void Slerp_Transform_Position(GameObject object_To_Slerp, Vector3 start_Slerp_Pos, Vector3 end_Slerp_Pos, int _sec_2_Wait, float duration )
        {
            
                    float time = 0f;
                    await Task.Delay(_sec_2_Wait);
                
                while(time < duration)
                {
                    object_To_Slerp.transform.position = Vector3.Slerp( start_Slerp_Pos, end_Slerp_Pos, time / duration );
                    time += Time.unscaledDeltaTime;
                     await Task.Yield();
                }
        }


        public async void Move_Object_Slerp(RectTransform object_Rect, Vector3 start_Pos, Vector3 end_Pos, Vector3 center_Pos, float journeyTime)
            { 
                /* center_Pos adjusts the height of the arc.
                   +y axis and -x axis makes the object curve upward.
                   -y axis and +x axis makes the object curve downward. */
                
                float startTiming = Time.unscaledTime;
            
                while(Time.unscaledTime - startTiming < journeyTime)
                {
                   
                    // The center of the arc
                    Vector3 center = (start_Pos + end_Pos) * 0.5F;
                   
                    // move the center a bit downwards to make the arc vertical
                    center -= center_Pos; //new Vector3(0, 1, 0);

                    // Interpolate over the arc relative to center
                    Vector3 riseRelCenter = start_Pos - center;
                    Vector3 setRelCenter = end_Pos - center;

                    // The fraction of the animation that has happened so far is
                    // equal to the elapsed time divided by the desired time for
                    // the total journey.
                    float fracComplete = (Time.unscaledTime - startTiming) / journeyTime;

                    object_Rect.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
                    object_Rect.position += center;
                   
                    await Task.Yield();
                    
                }
               // Debug.Log("Three");
            }


  public async void Move_Object_Curve_Async(RectTransform gameObject_Rect, Vector2 start_Point, Vector2 height_Point, Vector2 finish_Point, float duration, int WFS)
{
	await Task.Delay(WFS);

	float time = 0f;


        while (time < duration)
        {
            time += duration * Time.unscaledDeltaTime;

            Vector3 m1 = Vector2.Lerp(start_Point, height_Point, time / duration);
            Vector3 m2 = Vector2.Lerp(height_Point, finish_Point, time / duration);

            gameObject_Rect.localPosition = Vector2.Lerp(m1, m2, time / duration);

			await Task.Yield();
        }

}
        

         public async void Scale_Object(GameObject object_To_Scale, Vector3 start_Size, Vector3 end_Size, float duration, int _sec_2_Wait )
            {
                gameObject_List.Add(object_To_Scale);

                                string result = "List contents: ";
                                foreach (var item in gameObject_List)
                                {
                                    result += item.ToString() + ", ";
                                }
                                

                float time = 0f;
                  
                await Task.Delay(_sec_2_Wait);

                    while(time <= duration)
                    {
                        object_To_Scale.transform.localScale = Vector3.Lerp(start_Size, end_Size, time / duration );
                        time += Time.unscaledDeltaTime; 
                       await Task.Yield();
                    }   

                object_To_Scale.transform.localScale = end_Size;
                gameObject_List.Remove(object_To_Scale);
                    
            }


public async void Size_Object(GameObject object_To_Size, Vector3 start_Size, Vector3 end_Size, int sec_To_Wait, float duration) 
       {
            // x is the recttransforms width; y is the recttransform's height.
            // starting point is were the pivot point is placed.
            size_Object_Bool = true;

            float time = 0f;
            float x;
            float y;

        await Task.Delay(sec_To_Wait);


             tmpro_Object.color = new Color(1, 1, 1, 1);  // does this need to be here?


            while(time < duration)
            { 
                x = Mathf.Lerp(start_Size.x, end_Size.x, time / duration);
                y = Mathf.Lerp(start_Size.y, end_Size.y, time / duration);

                object_To_Size.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x);
                object_To_Size.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y);

                time += Time.unscaledDeltaTime;

               await Task.Yield();
            }    

            size_Object_Bool = false;
         }


         IEnumerator Move_Object_Math(RectTransform _object_Rec, float x_Distance, float y_Distance, float WFS, float duration)
        {
            move_Object_Math_Bool = false;

			yield return new WaitForSeconds(WFS);

            float time = 0f;

            float xAxis = _object_Rec.position.x;
            float yAxis = _object_Rec.position.y;

                    while(time < duration)
                    {
                       float y = Mathf.Lerp(0, y_Distance, time / duration ); // Set y_Distance or x_distance to zero to maintain current position.
                       float x = Mathf.Lerp(0, x_Distance, time / duration );

                         _object_Rec.position = new Vector3(xAxis + x, yAxis + y, 0);

                        time += Time.deltaTime;
                        yield return null;
                    }

                move_Object_Math_Bool = true;
                    
        }


IEnumerator Word_Text_Reveal(TextMeshPro objects_TMPro, string words_To_Split, float duration, float WFS)
    {
    //----------------Word by word text reveal.------------------
        yield return new WaitForSeconds(WFS);

        string[] array = words_To_Split.Split(' ');
        objects_TMPro.text = array[0]; 

        objects_TMPro.color = new Color(1, 1, 1, 1);
Debug.Log(opponent_TMPro.color + objects_TMPro.color);
      for( int i = 1 ; i < array.Length ; ++ i)
      {
        yield return new WaitForSeconds(duration);
        objects_TMPro.text += " " + array[i]; 
      }
    }


    IEnumerator Set_Object_Activate(GameObject object_To_Set, bool on_Off, float WFS)
    {
        yield return new WaitForSeconds(WFS);
        object_To_Set.SetActive(on_Off);
    }

public void Set_Font(TextMeshPro _TMPro, Color32 new_Color, TMP_FontAsset font_Settings, float font_Size)
{
			_TMPro.font = font_Settings;
			_TMPro.fontSize = font_Size;
			_TMPro.color = new_Color;

}



#endregion -----Coroutines-----

 #region -----Textbox_Moves-----

 IEnumerator FadeOutCR( string text_Moves, float WFS, float duration ) // Fades text out from full alpha to zero alpha.
{
   function_Done = false;

    if(text_To_Use_Is != null)
    {
        text_To_Use_Is();
        text_To_Use_Is = null;
    }
/*
    if(objects_Variables != null)
    {
        objects_Variables();
        objects_Variables = null;
    }
*/
    if(text_Moves == "fade")
    {
        text_Moves = " ";

         tmpro_Object.text = sayStuff;
        yield return StartCoroutine(Lerp_TMPro_Color_Alpha(tmpro_Object, sunGlass_00, sunGlass_01, WFS, duration));
    }

     if(text_Moves == "type")
    {
         text_Moves = " ";

        yield return StartCoroutine(Word_Text_Reveal(tmpro_Object, sayStuff, .3f, WFS));
    }

   
     if(text_Moves == "slide")
    {
         text_Moves = " ";
         tmpro_Object.text = sayStuff;
        Size_Object(opponent_Text_Box, textBox_width01, textBox_width02, 0, duration);

          while (size_Object_Bool == true)
        {
            yield return null;
        }
              //    yield return new WaitForSeconds(1f);    
 
    }
                float currentTime = 0f;
   
                if(!no_Fade)
                {
                        while(currentTime < duration)
                        {
                            float alpha = Mathf.Lerp(1f, 0f, currentTime/duration);
                           tmpro_Object.color = new Color(tmpro_Object.color.r, tmpro_Object.color.b, tmpro_Object.color.g, alpha);
                            currentTime += Time.deltaTime;
                            yield return null;
                        }
                }

                yield return new WaitForSeconds(.5f);
                tmpro_Object.text = "";
                text_To_Use_Is = null;
                function_Done = true;

}


 #endregion   -----Textbox_Moves-----






#region -----Character_Texts-----


void First_Text_Line() // Sets text to trashTalk01.
    {
        sayStuff = trashTalk01;
    }


   void Second_Text_Line() // Sets text to trashTalk02.
    {
        sayStuff = trashTalk02;
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

//------------------------------StarBoy's Dialogue----------------------------------

/*

async void Boys_Case_Zero()
           {
            text_To_Use_Is = null;
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("slide", 0, 3));
                
             while( function_Done == false )
                  {
                        await Task.Yield();
                  }

                text_To_Use_Is = null;
                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("slide", 0, 3f));
           }    

async void Boys_Case_One()
           {
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("slide", 0, 3));
                
             while( function_Done == false )
                  {
                        await Task.Yield();
                  }

                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("slide", 0, 3));
           }   

           async void Boys_Case_Two()
           {
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("slide", 0, 3));
                
             while( function_Done == false )
                  {
                        await Task.Yield();
                  }

                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("type", 0, 1));
           }  

           async void Boys_Case_Three()
           {
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("fade", 0, 1));
                
             while( function_Done == false )
                  {
                        await Task.Yield();
                  }

                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("type", 0, 1));
           }  

           async void Boys_Case_Four()
           {
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("fade", 0, 1));
                
             while( function_Done == false )
                  {
                        await Task.Yield();
                  }

                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("slide", 0, 3));
           }  
 */   
    public void Boys_Dialogue()
    {
        // text_Box_Object = boys_Text_Box;
        tmpro_Object = boys_TMPro;
        tmpro_Object.text = " ";

        textBox_width01 = new Vector2(0, 1);
        textBox_width02 = new Vector2(11, 1);

        switch (orderList[arrayPos])
        {
            case 0:
                trashTalk01 = "<color=#D6C207>It's hard,</color>";
				trashTalk02 = "<color=#D6C207>Being this good!</color>";
                 fadeOutCR_Pick_01 = "fade"; 
                fadeOutCR_Pick_02 = "type";
                 Character_Switch_Case(); 
                
            break;

            case 1:
                trashTalk01 = "<color=#D6C207>I've seen worse.</color>";
				trashTalk02 = "<color=#D6C207><size=8>But not much worse.</color>";
                 fadeOutCR_Pick_01 = "fade"; 
                fadeOutCR_Pick_02 = "type";
                 Character_Switch_Case(); 
              
            break;

            case 2:
                trashTalk01 = "<color=#D6C207>It could be worse,</color>";
				trashTalk02 = "<color=#D6C207><size=8>It could be me playing that bad. </color>";
                 fadeOutCR_Pick_01 = "fade"; 
                fadeOutCR_Pick_02 = "type";
                Character_Switch_Case(); 
            break;

            case 3:
                trashTalk01 = "<color=#D6C207>Gotta ask-</color>";
                trashTalk02 = "<color=#D6C207><size=8>Ya know which goal is yours, right? </color>";
                 fadeOutCR_Pick_01 = "fade"; 
                fadeOutCR_Pick_02 = "type";
                Character_Switch_Case(); 
            break;

            case 4:  
                trashTalk01 = "<color=#D6C207><size=9>Nothin' worse than losing,</color>";
				trashTalk02 = "<color=#D6C207>So I've heard. </color>";
                 fadeOutCR_Pick_01 = "fade"; 
                fadeOutCR_Pick_02 = "type";
                 Character_Switch_Case(); 
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

//--------------------------------End Star Boy's Dialogue-------------------------------------------
//-----------------------------------Star's Dialogue------------------------------------------------

async void Character_Switch_Case()
           {
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR(fadeOutCR_Pick_01, 0, 1.5f));
                
             while( function_Done == false )
                  {
                        await Task.Yield();
                  }

                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR(fadeOutCR_Pick_02, 0, 1.5f));
           }  

/*
async void Stars_Case_Zero()
           {
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("fade", 0, 1.5f));
                
             while( function_Done == false )
                  {
                        await Task.Yield();
                  }

                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("type", 0, 1.5f));
           }    

async void Stars_Case_One()
           {
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("slide", 0, 2f));
                
             while( function_Done == false )
                  {
                        await Task.Yield();
                  }

                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("fade", 0, 1.5f));
           }   

           async void Stars_Case_Two()
           {
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("slide", 0, 2f));
                
             while( function_Done == false )
                  {
                        await Task.Yield();
                  }

                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("type", 0, 1.5f));
           }  

           async void Stars_Case_Three()
           {
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("slide", 0, 2f));
                
             while( function_Done == false )
                  {
                        await Task.Yield();
                  }

                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("type", 0, 1.5f));
           }  

           async void Stars_Case_Four()
           {
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("type", 0, 1.5f));
                
             while( function_Done == false )
                  {
        
        
                        await Task.Yield();
                  }

                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("slide", 0, 2f));
           }  

*/




public void Stars_Dialogue()
    {
        tmpro_Object = opponent_TMPro;
        textBox_width01 = new Vector2(0, 1);
        textBox_width02 = new Vector2(11, 1);

        switch (orderList[arrayPos])
        {
            case 0:
                trashTalk01 = "<b><size=12><align=right><color=#780987>Don't Run!</color></b>";
				trashTalk02 = "<size=9><align=right><color=#780987>The puck doesn't bite!</color>";
                fadeOutCR_Pick_01 = "fade"; 
                fadeOutCR_Pick_02 = "type";
                Character_Switch_Case();
            break;

            case 1:
                trashTalk01 = "<b><size=12><align=right><color=#780987>Did you see that?</b>";
				trashTalk02 = "<size=9><align=right><color=#780987>No. I guess you didn't</color>";
                 fadeOutCR_Pick_01 = "fade"; 
                fadeOutCR_Pick_02 = "type";
                Character_Switch_Case();
            break;

            case 2:
                trashTalk01 = "<b><size=12><align=right><color=#780987>Say...</color></b>";
				trashTalk02 = "<size=9><align=right><color=#780987>is that goal AWAYS open?</color>";
                 fadeOutCR_Pick_01 = "fade"; 
                fadeOutCR_Pick_02 = "type";
                Character_Switch_Case(); 
            break;

            case 3:
                trashTalk01 = "<b><size=12><align=right><color=#780987>Hello?</color></b>";
                trashTalk02 = "<size=10><align=right><color=#780987>Are you AFK?</color>";
                 fadeOutCR_Pick_01 = "fade"; 
                fadeOutCR_Pick_02 = "type";
                Character_Switch_Case();
            break;

            case 4:  
                trashTalk01 = "<b><size=12><align=right><color=#780987>That's so sweet</color></b>";
				trashTalk02 = "<size=9><align=right><color=#780987>You're letting me win!</color>";
                 fadeOutCR_Pick_01 = "type"; 
                fadeOutCR_Pick_02 = "slide";
                Character_Switch_Case();
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

 public async void Star_Wins()
    {
        pan_Try_Again_Text_01 = "It's not her\nbedtime yet,";

		pan_Try_Again_Text_02 = "you can still\nwin back\nsome of\nyour diginity!";

		char_Try_Again_Text_01 = "<b><size=12><align=right><color=#780987>That was FUN!</color></b>";

		char_Try_Again_Text_02 = "<size=12><align=right><color=#780987>Wanna lose again?</color>";
		
		pan_Try_Again_Exit = "Go get her!";

            //  Function to show try again menu.
                star_Is_Happy.Play();




                Slerp_In_Flowers();


                text_To_Use_Is = null;
              
                trashTalk01 = char_Try_Again_Text_01;
				trashTalk02 = char_Try_Again_Text_02;
                text_To_Use_Is += First_Text_Line;

                StartCoroutine(FadeOutCR("fade", 0, 1.5f));

                while(function_Done == false)
                    {
                        await Task.Yield();
                    }
                
               text_To_Use_Is += Second_Text_Line;
			    StartCoroutine(FadeOutCR( "type", 0, 1.5f));
                Pan.SetActive(true);
                StartCoroutine(Lerp_Transform_Position(Pan, endPosLeftOffScreen_Fixed, gamePosLeft, 1, 0 ));
                await Task.Delay(1000);
                text_Pan_TMPro.color = new Color(0, 0, 0, 1);
                StartCoroutine(Pan_Asks_U_To_tryAgain());               
  }

  public void Character_Try_Again_Fun()
  {
        character_Try_Again();
  }

    public async void Star_Loses()
    { 
       
                await Task.Delay(1500);
                tmpro_Object.font = star_Loses_Font;
                opponent_Text_Box_Rec.position = stars_Text_Box_Pos_Losing;
                trashTalk01 = "<b><size=9><align=right><color=#0e1111>that wasn't very nice.</color></b>";
				trashTalk02 = "<size=9><color=#0e1111><align=right>i'm gonna tell on you...</color> ";
        

        
                StartCoroutine(Lerp_Color_Alpha(_sunGlass, sunGlass_00, sunGlass_01, 1f, 0f));

                StartCoroutine(MoveTowards_Object(camera_Rect, main_Cam_Pos_Star, .2f, 0));
                StartCoroutine(Math_lerp_Cam_Size(camera_01, main_Cam_Size, main_Cam_Size_Star, 1.5f, 0));
                 
                Fade_In_Bad_Arua();
                 text_To_Use_Is += First_Text_Line;
                
                StartCoroutine(FadeOutCR("fade", 1, 1));
                
                while(function_Done == false)
                    {
                        await Task.Yield();
                    }
                
               text_To_Use_Is += Second_Text_Line;
			    StartCoroutine(FadeOutCR( "type", .2f, 1));

                await Task.Delay(3000);
                star_Is_Sad.Play();
                StartCoroutine(Lerp_Transform_Position(star_Girl, Stars_Starting_Position, Stars_Ending_Position, 2.5f, 0 ));

                StartCoroutine(MoveTowards_Object(camera_Rect, main_Cam_Pos, .6f, .2f));
                StartCoroutine(Math_lerp_Cam_Size(camera_01, main_Cam_Size_Star, main_Cam_Size, 4, .2f));
                StartCoroutine(Lerp_Color_Alpha(_sunGlass, sunGlass_01, sunGlass_00, 1f, .8f));

                 opponent_Paddle.SetActive(false);

               await Task.Delay(1500);
                star_Girl.SetActive(false);
                star_Is_Sad.Stop();

                _scoreScaling.Achievment_Unlocked(01); 

                Pick_Opponent("Mopsey");

                StartCoroutine(Pan_Intro_New_Opp());

    }



//-------------------------------End Star's Dialogue---------------------------------------------
//--------------------------------Mopsey's Dialogue----------------------------------------------
    

    
     /*       async void Mopseys_Case_Zero()
           {
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("type", 0, 1f));
                
             while( function_Done == false )
                  {
                        await Task.Yield();
                  }

                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("slide", 0, 2f));
           }    

            async void Mopseys_Case_One()
           {
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("type", 0, 1.5f));
                
             while( function_Done == false )
                  {
                        await Task.Yield();
                  }

                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("fade", 0, 1.5f));
           }   

            async void Mopseys_Case_Two()
           {
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("type", 0, 1.5f));
                
             while( function_Done == false )
                  {
                        await Task.Yield();
                  }

                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("slide", 0, 1.5f));
           }  

            async void Mopseys_Case_Three()
           {
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("fade", 0, 1.5f));
                
             while( function_Done == false )
                  {
                        await Task.Yield();
                  }

                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("type", 0, 1.5f));
           }  

            async void Mopseys_Case_Four()
           {
                text_To_Use_Is += First_Text_Line;
                StartCoroutine(FadeOutCR("type", 0, 1.5f));
                
             while( function_Done == false )
                  {
                        await Task.Yield();
                  }

                text_To_Use_Is += Second_Text_Line;
                StartCoroutine(FadeOutCR("fade", 0, 1.5f));
           }  

*/
public void Mopseys_Dialogue()
    {
        tmpro_Object = opponent_TMPro;
        textBox_width01 = new Vector2(5.5f, 0);
        textBox_width02 = new Vector2(5.5f, 6.5f);
        tmpro_Object.text = " ";

        switch (orderList[arrayPos])
    {
            case 0:
                trashTalk01 = "<b><size=9>Don't \nbe \nAfraid!</b>";
				trashTalk02 = "<size=8>Bunnies <br>just like <br>to <br>have fun.";
                 fadeOutCR_Pick_01 = "fade"; 
                fadeOutCR_Pick_02 = "type"; 
                Character_Switch_Case();
            break; 

            case 1:
                trashTalk01 = "<b><size=9>The \nbunnies \nwill \nwait</b>";
				trashTalk02 = "<size=9>If you need a nap.";
                 fadeOutCR_Pick_01 = "fade"; 
                fadeOutCR_Pick_02 = "type";
                Character_Switch_Case();
              
            break;

            case 2:
                trashTalk01 = "<b><size=10>Want \na \ncarrot?</b>";
				trashTalk02 = "<size=9>They're <br>good for <br>the eyes.";
                 fadeOutCR_Pick_01 = "fade"; 
                fadeOutCR_Pick_02 = "type";
                Character_Switch_Case(); 
            break;

            case 3:
                trashTalk01 = "<b><size=8>We don't\nhave enough\nrabbits feet</b>";
                trashTalk02 = "<size=9>to \nimprove \nyour \nluck.";
                 fadeOutCR_Pick_01 = "fade"; 
                fadeOutCR_Pick_02 = "type";
                Character_Switch_Case();
            break;

            case 4:  
                trashTalk01 = "<b><size=9>The \nbunnies \nare \nsad</b>";
				trashTalk02 = "<size=8>They were \nhoping \nfor a \nchallenge.";
                 fadeOutCR_Pick_01 = "fade"; 
                fadeOutCR_Pick_02 = "type";
                Character_Switch_Case();

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



public void Mopsey_Try_Again()
{

}

   


    public async void Mopsey_Loses()
    {
        StartCoroutine(Bunny_Attack_01_Start());
    }



public void Change_Paddle(Sprite paddle)
    {
        opponent_Paddle.SetActive(true);

        opponent_Paddle_SR.sprite = paddle;
        
        Scale_Object(opponent_Paddle, scale_00, scale_01, 1, 0);

      //  play_Paddle_Intro();
       
    }


IEnumerator Pan_Intro_New_Opp()
{
                //await Task.Delay(1000);
                yield return new WaitForSeconds(1);
                Pan.SetActive(true);
                StartCoroutine(Lerp_Transform_Position(Pan,  endPosLeftOffScreen, gamePosLeft, 1, 0 )); // Pan lerps in.

                Pan_Intros("Mopsey"); // Sets pans dialog.


                text_Pan_TMPro.text = pan_text_Intros_01;
                text_Pan_TMPro.color = new Color(0, 0, 0, 1); 
                Size_Object(text_Pan, _start_Size_Y, _mid_Size_Y, 0, 1f);
                yield return new WaitForSeconds(1);
                Size_Object(text_Pan, _mid_Size_Y, _end_Size_Y, 0, 1f);
                StartCoroutine(Lerp_TMPro_Color_Alpha(text_Pan_TMPro, sunGlass_01, sunGlass_00, 2,  1));

                yield return new WaitForSeconds(3);
            
                text_Pan_TMPro.text = pan_text_Intros_02; 
                text_Pan_TMPro.color = new Color(0, 0, 0, 1); 
                Size_Object(text_Pan, _start_Size_Y, _mid02_Size_Y, 0, 1f);
                yield return new WaitForSeconds(1.5f);
                StartCoroutine(Lerp_TMPro_Color_Alpha(text_Pan_TMPro, sunGlass_01, sunGlass_00, 0,  1));

                
                yield return new WaitForSeconds(1);

                text_Pan_TMPro.text = pan_text_Intros_03;
                StartCoroutine(Lerp_TMPro_Color_Alpha(text_Pan_TMPro, sunGlass_00, sunGlass_01, 0,  1));
                StartCoroutine(Lerp_TMPro_Color_Alpha(text_Pan_TMPro, sunGlass_01, sunGlass_00, 2,  1));

                character_Intro();

}
   

public void Mopseys_Intro_Start()
{
    StartCoroutine(Mopseys_Intro());
}


IEnumerator Mopseys_Intro()
{
    yield return new WaitForSeconds(2);



   mopseys_Visit.SetActive(true);
    
   // mopsey_Text_Box.SetActive(true);
    mopsey_Is_Angry.SetActive(false);
    attack_Bunnies.SetActive(false);
    carrots.SetActive(false);
    good_Bunny_01_Rec.localScale = scale_00 ;
    good_Bunny_02_Rec.localScale = scale_00 ;
    good_Bunny_03_Rec.localScale = scale_00 ;
    opponent_Text_Box_Rec.localScale = scale_00;



    Scale_Object(good_Bunny_01, scale_00, body_norm_Size, 1, 0);
    hearts_01_PS.Play();
    yield return new WaitForSeconds(1);
    Scale_Object(good_Bunny_02, scale_00, body_norm_Size_02, 1, 0);
    hearts_02_PS.Play();
    yield return new WaitForSeconds(1);
    Scale_Object(good_Bunny_03, scale_00, body_norm_Size_03, 1, 0);
    hearts_03_PS.Play();
    yield return new WaitForSeconds(1);
    StartCoroutine(Lerp_Transform_Position(opp_Mask, opp_Mask_Pos, opp_Mask_Center, 3, 1));
    hearts_00_PS.Play();

   // Change_Paddle(mopseys_Paddle);

    Opp_Paddle_Intro(mopseys_Paddle, 0);



    // Mopsey says Hi!.
    yield return new WaitForSeconds(4);
        opponent_TMPro.text = "\nHi!\n";    // Replace mopsey_Text_Box_TMPro with  tmpro_Object.
    
    opponent_Text_Box_Rec.pivot = new Vector2(.5f, .5f);
   // opponent_Text_Box_Rec.pivot = new Vector2(.9f, .3f);
    Vector3 newCenterOffset = new Vector3(0, -10, 0);

    Move_Object_Slerp(opponent_Text_Box_Rec, Mopsey_Text_Start_Pos, Mopsey_Text_Hello_Pos, newCenterOffset, .3f);
    //Move_Object_Curve_Async(opponent_Text_Box_Rec, Mopsey_Text_Start_Pos, Mopsey_Text_OffSet_Center01, Mopsey_Text_Origin_Pos, .7f, 0);

    Scale_Object(opponent_Text_Box, scale_00, scale_01, .3f, 0);

    yield return new WaitForSeconds(2);

     

     Move_Object_Slerp(opponent_Text_Box_Rec, Mopsey_Text_Hello_Pos, Mopsey_Text_Start_Pos, newCenterOffset, .2f);
   //  Move_Object_Curve_Async(opponent_Text_Box_Rec, Mopsey_Text_Origin_Pos, Mopsey_Text_OffSet_Center02, Mopsey_Text_Start_Pos, .2f, 0);

    Scale_Object(opponent_Text_Box, scale_01, scale_00, .25f, 0);



// Reset Mopsey text box?
     yield return new WaitForSeconds(2);
    opponent_TMPro.text = " ";
    opponent_Text_Box_Rec.localScale = scale_01;
    opponent_Text_Box_Rec.position = new Vector3(-13, -1.2f, 0);
   // opponent_Text_Box_Rec.pivot = new Vector2(.5f, .5f);



// Mopsey intros herself.

   
    opponent_Text_Box_Rec.pivot = new Vector2(.8f, .3f);  // adjust position of box when at scale 1.
    opponent_TMPro.text = "\nI'm \nMopsey.";

    Scale_Object(opponent_Text_Box, scale_00, scale_01, .3f, 0);
    Move_Object_Slerp(opponent_Text_Box_Rec, Mopsey_Text_Start_Pos, Mopsey_Text_Hello_Pos, newCenterOffset, .3f);

    yield return new WaitForSeconds(1);

    Scale_Object(opponent_Text_Box, scale_01, scale_00, .2f, 0);
    Move_Object_Slerp(opponent_Text_Box_Rec, Mopsey_Text_Hello_Pos, Mopsey_Text_Start_Pos, newCenterOffset, .2f);
    
    yield return new WaitForSeconds(1.5f);

   

// Get Mopseys text box ready for dialogue text.
    opponent_TMPro.text = " "; 
   // Scale_Object(mopsey_Text_Box, scale_00, scale_01, 0, 1);
    opponent_Text_Box_Rec.localScale = scale_01;
    opponent_Text_Box_Rec.position = Mopsey_Text_Origin_Pos;
    opponent_Text_Box_Rec.pivot = new Vector2(1f, 1f);
   // string firstToFive = "1st to <B><color=yellow>5</color></B> wins!";
    StartOver();
    countDown.StartCount(0.5f); 
    MovePan(false, firstToFive, 0, 2f);
    
}



/*
public void Mopseys_Paddle_Intro()
    {
        var _colorOverLifetime = Opp_Paddle_PS.colorOverLifetime;
        var _rotationOverLifetime = Opp_Paddle_PS.rotationOverLifetime;
        _colorOverLifetime.enabled = false;
        _rotationOverLifetime.enabled = false;

         var textureSheetAnimation = Opp_Paddle_PS.textureSheetAnimation;
        textureSheetAnimation.enabled = true;
        textureSheetAnimation.mode = ParticleSystemAnimationMode.Sprites;

        if(textureSheetAnimation.spriteCount > 0)
        {
        textureSheetAnimation.RemoveSprite(0);
        }
        
        textureSheetAnimation.AddSprite(heart_Sprite);

                var object_PS_Main = Opp_Paddle_PS.main;
                //object_PS_Main.startColor = new ParticleSystem.MinMaxGradient(Color.red, Color.yellow);
                object_PS_Main.startColor = new ParticleSystem.MinMaxGradient(litePink, darkPink);

                 Opp_Paddle_PS.Play();
    }
*/


/*
public void Mopseys_Paddle_Exit()
    {
        var _colorOverLifetime = Opp_Paddle_PS.colorOverLifetime;
        var _rotationOverLifetime = Opp_Paddle_PS.rotationOverLifetime;
        _colorOverLifetime.enabled = true;
        _rotationOverLifetime.enabled = true;

        Opp_Paddle_Renderer.material = heart_material;
        var textureSheetAnimation = Opp_Paddle_PS.textureSheetAnimation;
        textureSheetAnimation.enabled = true;
        textureSheetAnimation.mode = ParticleSystemAnimationMode.Grid; // Sets mode to 'Grid'.

       textureSheetAnimation.numTilesX = 17; // Sets number of frames for 'tiles' when in grid mode.

        if(textureSheetAnimation.spriteCount > 0)
        {
        textureSheetAnimation.RemoveSprite(0);
        }

        var PS_COL = Opp_Paddle_PS.colorOverLifetime;
        Gradient grad = new Gradient();
        grad.SetKeys( new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.black, .3f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) } );

         PS_COL.color = grad;

                 Opp_Paddle_PS.Play();

                 opponent_Paddle.SetActive(false);
    }
*/


 public async Task Bunnies_Attack()
        {
            
            StartCoroutine(Move_Object_Bounce_03(bunny_01_Rec, Mathf.PI * 2, 2, .2f, .17f, 2f, 0f, false));
            StartCoroutine(Move_Object_Bounce_03(bunny_02_Rec, Mathf.PI * 2, 1.5f, .2f, .17f, 2f, 0f, false));
            StartCoroutine(Move_Object_Bounce_03(bunny_03_Rec, Mathf.PI * 2, 2.5f, .2f, .17f, 2f, 0f, true));

        }


IEnumerator Bunny_Attack_01_Start()
{
    yield return new WaitForSeconds(2f);

    square_Screen_Color = new Color32(0, 0, 0, 0);
    square_Screen_Color_01 = new Color32(0, 0, 0, 255);

    // dark_Overlay.SetActive(true);
    square_Screen.SetActive(true); // activate square_Screen.
    square_Screen_Text.SetActive(true);

        // square_Screen_Renderer.color = square_Screen_Color; // activate square_Screen.
        // square_Screen_Text.SetActive(true);



        // set screen color and font.

        //Set_Font(square_Screen_Text_TMPro, oh_No_new_Color_01, oh_No, oh_No_font_Size);
        Set_Font(square_Screen_Text_TMPro, oh_No_new_Color, oh_No, oh_No_font_Size);

    // Ohno! fades in and out.
    StartCoroutine(Lerp_Color_Alpha(square_Screen_Renderer, square_Screen_Color, square_Screen_Color_01, 1, 0));// fade in black screen with 'Oh no!' text.
    StartCoroutine(Lerp_TMPro_Color_Alpha(square_Screen_Text_TMPro, oh_No_new_Color, oh_No_new_Color_01, 0,  1));
    
    StartCoroutine(Lerp_TMPro_Color_Alpha(square_Screen_Text_TMPro, oh_No_new_Color_01, oh_No_new_Color, 1,  1));  // fade out text.
    StartCoroutine(Lerp_Color_Alpha(square_Screen_Renderer, square_Screen_Color_01, square_Screen_Color, 1, 2)); // fade out color screen.
   
   yield return new WaitForSeconds(2f);

    Switch_Cameras(second_Camera, camera); // active camera two and deactive main camera.
    
    square_Screen_Text.SetActive(false);
    good_Bunnies.SetActive(false);
    attack_Bunnies.SetActive(true);
    mopsey_Is_Angry.SetActive(true);
    mopsey_Is_Happy.SetActive(false);

    yield return new WaitForSeconds(1.1f);
    // run mopsey text box- bunnies are angry..
    Angry_Bunnies_Text();

    // Angry bunnies hop wildly.
    Bunnies_Attack();

        yield return new WaitForSeconds(1f);


         Vector3 start_Size = new Vector3(1f, 1f, 0); 
        Vector3 scale_factor = new Vector3(1.3f, 1.3f, 0);

        Vector3 start_Size_02 = new Vector3(1f, 1f, 0); 
        Vector3 scale_factor_02 = new Vector3(1.3f, 1.3f, 0);

        Vector3 start_Size_03 = new Vector3(1f, 1f, 0); 
        Vector3 scale_factor_03 = new Vector3(1.3f, 1.3f, 0);



      //  int follow = 0;


        // angry bunnies snap at you.
        StartCoroutine(Scale_Object(mouth_01_Rec, mouth_Close_Size, Mouth_Wide_Size, .3f, 0)) ;
        StartCoroutine(Scale_Object(bunny_01_Rec, start_Size, scale_factor, .3f, .4f)) ;
        StartCoroutine(Scale_Object(bunny_01_Feet_Rec, bunny_02_Feet_Start, bunny_02_Feet_Forward, .3f, .4f)) ;

        StartCoroutine(Scale_Object(bunny_02_Rec, start_Size_02, scale_factor_02, .4f, 0.3f)) ;
        StartCoroutine(Scale_Object(bunny_02_Feet_Rec, bunny_02_Feet_Start, bunny_02_Feet_Forward, 1.3f, .4f)) ;
        StartCoroutine(Scale_Object(mouth_02_Rec, mouth_Close_Size, Mouth_Wide_Size, .3f, 0)) ;
        Rotate_Object(bunny_02_Rec, 0, 0, -.1f, 1, 1, 100);

        StartCoroutine(Scale_Object(mouth_03_Rec, mouth_Close_Size, Mouth_Wide_Size, .3f, 0)) ;
        StartCoroutine(Scale_Object(bunny_03_Rec, start_Size_03, scale_factor_03, .3f, .4f)) ;
        StartCoroutine(Scale_Object(bunny_03_Feet_Rec, bunny_02_Feet_Start, bunny_02_Feet_Forward, .3f, .4f)) ;
        Rotate_Object(bunny_03_Rec, 0, 0, .1f, 1, 1, 0);
        

         while(scale_Object_List.Count < 9)
                    {
                      //  Debug.Log("bunny 04 " + scale_Object_List.Count);
                        yield return null;
                    }

        scale_Object_List.Clear();

        StartCoroutine(Scale_Object(mouth_01_Rec, Mouth_Wide_Size, mouth_Close_Size, 1f, 0));
        StartCoroutine(Scale_Object(bunny_01_Rec, scale_factor, start_Size, 1f, 0));
        StartCoroutine(Scale_Object(bunny_01_Feet_Rec, bunny_02_Feet_Forward, bunny_02_Feet_Start, 1f, 0));

        StartCoroutine(Scale_Object(mouth_02_Rec, Mouth_Wide_Size, mouth_Close_Size, 1f, 0));
        StartCoroutine(Scale_Object(bunny_02_Rec, scale_factor_02, start_Size_02, 1f, 0));
        StartCoroutine(Scale_Object(bunny_02_Feet_Rec, bunny_02_Feet_Forward, bunny_02_Feet_Start, 1f, 0));
        Rotate_Object(bunny_02_Rec, 0, 0, 0f, 1, 1, 100);

        StartCoroutine(Scale_Object(mouth_03_Rec, Mouth_Wide_Size_03, mouth_Close_Size_03, 1f, 0));
        StartCoroutine(Scale_Object(bunny_03_Rec, scale_factor_03, start_Size_03,  1f, 0));
        StartCoroutine(Scale_Object(bunny_03_Feet_Rec, bunny_02_Feet_Forward, bunny_02_Feet_Start, 1f, 0));
        Rotate_Object(bunny_03_Rec, 0, 0, 0f, 1, 1, 0);


        while(scale_Object_List.Count < 9)
                    {
                        yield return null;
                    }
        scale_Object_List.Clear();


        yield return new WaitForSeconds(.5f);

        Bunny_Attack_04();

}
   
    
        public async void Bunny_Attack_04()
{

       // Angry bunnies lunge and bite.
        StartCoroutine(Scale_Object(mouth_01_Rec, mouth_Close_Size, Mouth_Wide_Size,  .3f, 0f)) ;
        StartCoroutine(Scale_Object(bunny_01_Rec, body_norm_Size, body_forward_Size, .3f, .4f)) ;
        StartCoroutine(Scale_Object(bunny_01_Feet_Rec, bunny_02_Feet_Start, bunny_02_Feet_Forward, .3f, .4f)) ;
        StartCoroutine(Move_Object_Math(bunny_01_Rec, 0, 8, .4f, 0.3f));

        StartCoroutine(Scale_Object(bunny_02_Rec, body_norm_Size_02, body_forward_Size_02, .3f, .4f)) ;
        StartCoroutine(Scale_Object(bunny_02_Feet_Rec, bunny_02_Feet_Start, bunny_02_Feet_Forward, .3f, .4f)) ;
        StartCoroutine(Scale_Object(mouth_02_Rec, mouth_Close_Size, Mouth_Wide_Size, 1f, 0)) ;
        Rotate_Object(bunny_02_Rec, 0, 0, -.1f, 1, 1, 100);

        StartCoroutine(Scale_Object(mouth_03_Rec, mouth_Close_Size, Mouth_Wide_Size, .3f, 0)) ;
        StartCoroutine(Scale_Object(bunny_03_Rec, body_norm_Size_03, body_forward_Size_03, .3f, .4f)) ;
        StartCoroutine(Scale_Object(bunny_03_Feet_Rec, bunny_02_Feet_Start, bunny_02_Feet_Forward, .3f, .4f)) ;
        Rotate_Object(bunny_03_Rec, 0, 0, .1f, 1, 1, 0);

        

        while(scale_Object_List.Count < 9)
                    {
                      //  Debug.Log("bunny 04 " + scale_Object_List.Count);
                        await Task.Yield();
                    }

           scale_Object_List.Clear();

 // hungry_Container.SetActive(true);
          // red screen and hungry text activates and fades out.
         StartCoroutine(Lerp_Color_Alpha(square_Screen_Renderer, hungry_new_Color_01, hungry_new_Color, 3, 0));
           
         hungry_Text_TMPro.color = hungry_new_Color_01;

             StartCoroutine(Lerp_TMPro_Color_Alpha(hungry_Text_TMPro, hungry_new_Color_01, zero_Alpha, 4 ,  1f));
             StartCoroutine(Stop_Drops());


        // angry bunnies sit back down.
        StartCoroutine(Scale_Object(mouth_01_Rec, Mouth_Wide_Size, mouth_Close_Size, 0f, .1f));
        StartCoroutine(Scale_Object(bunny_01_Rec, body_forward_Size, body_norm_Size, 0f, .1f));
        StartCoroutine(Scale_Object(bunny_01_Feet_Rec, bunny_02_Feet_Forward, bunny_02_Feet_Start, .1f, 0));
       // StartCoroutine(Move_Object_Math(bunny_01_Rec, 0, -8, 0f, .5f));

        StartCoroutine(Scale_Object(mouth_02_Rec, Mouth_Wide_Size, mouth_Close_Size, .1f, 0));
        StartCoroutine(Scale_Object(bunny_02_Rec, body_forward_Size_02, body_norm_Size_02, .1f, 0));
        StartCoroutine(Scale_Object(bunny_02_Feet_Rec, bunny_02_Feet_Forward, bunny_02_Feet_Start, .1f, 0));
        Rotate_Object(bunny_02_Rec, 0, 0, 0f, 1, 1, 100);

        StartCoroutine(Scale_Object(mouth_03_Rec, Mouth_Wide_Size_03, mouth_Close_Size_03, .1f, 0));
        StartCoroutine(Scale_Object(bunny_03_Rec, body_forward_Size_03, body_norm_Size_03,  .1f, 0));
        StartCoroutine(Scale_Object(bunny_03_Feet_Rec, bunny_02_Feet_Forward, bunny_02_Feet_Start, .1f, 0));
        Rotate_Object(bunny_03_Rec, 0, 0, 0f, 1, 1, 0);

 Switch_Cameras(camera, second_Camera);
    hungry_Container.SetActive(true);
  /*      

         mouth_01_Rec.localPosition =  mouth_Close_Size;
        bunny_01_Rec.localPosition =  body_norm_Size;
        bunny_01_Feet_Rec.localPosition =  bunny_02_Feet_Start;
       // StartCoroutine(Move_Object_Math(bunny_01_Rec, 0, -8, 0f, .5f));

        mouth_02_Rec.localPosition =  mouth_Close_Size;
        bunny_02_Rec.localPosition =  body_norm_Size_02;
        bunny_02_Feet_Rec.localPosition = bunny_02_Feet_Start;
        Rotate_Object(bunny_02_Rec, 0, 0, 0f, 1, 1, 100, true);

        mouth_03_Rec.localPosition = mouth_Close_Size_03;
        bunny_03_Rec.localPosition = body_norm_Size_03;
        bunny_03_Feet_Rec.localPosition = bunny_02_Feet_Start;
        Rotate_Object(bunny_03_Rec, 0, 0, 0f, 1, 1, 0, true);
 
 
        while(scale_Object_List.Count < 9)
                    {
                      //  Debug.Log("bunny 04 " + scale_Object_List.Count);
                        await Task.Yield();
                    }
*/
       // Color square_Screen_Color_02 = new Color(159, 7, 7, .3f);
       // StartCoroutine(Lerp_Color_Alpha(dark_Overlay_Renderer, square_Screen_Color_02, square_Screen_Color, 2,  1.5f));
        bunny_01_Rec.localPosition = new Vector3(-.28f, .45f, 1.75f);
        scale_Object_List.Clear();

        await Task.Delay(1000);
        // Start Mopseys exit.
        // Opp_Paddle_Exit(mopseys_Paddle, 1);
        StartCoroutine(Mopseys_Exit());
        
}


#region Mopsey_Wins_Functions

 public async void Mopsey_Wins() // used as character_Wins. Called by FlashFade?
    {
        pan_Try_Again_Text_01 = "Beaten by a bunch of bunnies?";

		pan_Try_Again_Text_02 = "Afraid you'll lose again?";

		char_Try_Again_Text_01 = "The bunnies Call you CARROT.";

		char_Try_Again_Text_02 = " ";
		
		pan_Try_Again_Exit = "Show'em what you're made of!";

      StartCoroutine(Start_Carrots());

      
				text_To_Use_Is = null;

              //  maskingTextBox =stars_Text_Box_RecTrans; // chose text box container for slide effect.
                trashTalk01 = char_Try_Again_Text_01;   // "<b><size=12><align=right><color=#780987>That was FUN!</color></b>"
				trashTalk02 = char_Try_Again_Text_02;   // "<size=12><align=right><color=#780987>Wanna lose again?</color>"
                text_To_Use_Is += First_Text_Line;

                StartCoroutine(FadeOutCR("fade", 0, 1.5f));

                while(function_Done == false)
                    {
                        await Task.Yield();
                    }
                
                text_To_Use_Is += Second_Text_Line;
			    StartCoroutine(FadeOutCR( "type", 0, 1.5f));

      Pan.SetActive(true);
      StartCoroutine(Lerp_Transform_Position(Pan, endPosLeftOffScreen, gamePosLeft, 1, 0 ));
  
     await Task.Delay(2000); // asyncneeded delay- is it? 
                text_Pan_TMPro.color = new Color(0, 0, 0, 1);
                StartCoroutine(Pan_Asks_U_To_tryAgain()); 
  
    }

 IEnumerator Start_Carrots()
    {
        carrots.SetActive(true);
      Carrot_Bitten_Glow.SetActive(false);
	  
	  yield return new WaitForSeconds(.5f);

       StartCoroutine(Lerp_Transform_Position(carrots, down, up, .7f, 0 ));
            StartCoroutine(Unfreeze(good_Bunny_03_Rb, .1f));

            while(gameObject_List.Contains(carrots))
            {
                  yield return null;
            }

            StartCoroutine(Bunny_Takes_A_Bite());
    }


    IEnumerator Bunny_Takes_A_Bite()
{
      Rotate_Object(good_Bunny_02_Rec, 0, 0, .1f, 1, .1f, 0) ;  //Rotate
			StartCoroutine(Lerp_Transform_Position(good_Bunny_02, good_Bunny3_Start_Pos, good_Bunny3_End_Pos, .2f, 0 ));
      Scale_Object(open_Mouth, zero, one,  .2f, 0 );
	//		Invoke("Turn_Off_Carrot", .5f);
 
 	// yield return new WaitForSeconds( .5f );

   while(rec_List.Contains(good_Bunny_02_Rec ) || gameObject_List.Contains(open_Mouth) )
   {
        yield return null;
   }

      carrot_Right.SetActive(false);

      Scale_Object(open_Mouth, one, zero, .2f, 0 );
			Rotate_Object(good_Bunny_02_Rec, 0, 0, 0f, 1, 1, 0)	;
			StartCoroutine(Lerp_Transform_Position(good_Bunny_02, good_Bunny3_End_Pos, good_Bunny3_Start_Pos, .5f, 0 ));

      Carrot_Bitten_Glow.SetActive(true);
}


public void Carrot_Left_MO()
		{
			//Carrot_Left_Glow.SetActive(true); // Enable glow carrot sprite.
			StartCoroutine(Lerp_Color_Alpha(Carrot_Left_Glow_SR, color_Zero, color_Max, .5f, 0f));  // lerp glow carrot alpha to max.
			 
			left_Bunnies_Animator.speed = 2f;
      left_Bunnies_Animator.Play("Base Layer.Bunny_Left_MO" ,-1 , 0);  // Make bunny twitch. S
		}


public void Carrot_Left_ME()
		{				
			StartCoroutine(Lerp_Color_Alpha(Carrot_Left_Glow_SR, color_Max, color_Zero, .5f, 0f));  // lerp glow carrot alpha to zero.
			
		}



/*
public async void Carrot_Left_MUP()
		{		
			StartCoroutine(Lerp_Transform_Position(carrots, up, down, .7f, 0 ));

            bool stop_y = true;
            float min = -5.23f;
            Vector3 b3_pos;

            while(gameObject_List.Contains(carrots))
            {
                b3_pos = good_Bunny_03_Rec.position;
                Debug.Log("pos bunny 3 " + good_Bunny_03_Rec.position);
                Debug.Log("pos bunny 3 b3pos " + b3_pos);
                
                if( b3_pos.y <= min && stop_y == true)
                {
                    good_Bunny_03_Rec.position = new Vector3(b3_pos.x, min, b3_pos.z);
                    left_Bunnies_Animator.Play("Base Layer.Bunny_Left",-1 , 0);
                    stop_y = false;
                    StartCoroutine(Freeze(good_Bunny_03_Rb, 0f));
                    Debug.Log("pos bunny 3 end " + good_Bunny_03_Rec.position);
                    Debug.Log("pos bunny 3 end b3pos " + b3_pos);
                }
                    await Task.Yield();
            }

           // StartCoroutine(Freeze(good_Bunny_03_Rb, .1f));
            StartOver();
            Opp_Paddle_Intro(stars_Paddle, 2);
             _countDown.StartCount(1); 
             MovePan(false, "Try not to screw-up!", 0, 1); 
        
		}
    */

public async void Carrot_Left_MUP()
		{		

			StartCoroutine(Lerp_Transform_Position(carrots, up, down, .7f, 0 ));

            float min = -7f;
            Vector3 b3_pos = new Vector3(-13.23f, 7.0f, 0);

            while(good_Bunny_03_Rec.position.y  > min)
            {
                await Task.Yield();
            }
                
                left_Bunnies_Animator.Play("Base Layer.Bunny_Left",-1 , 0);
                StartCoroutine(Freeze(good_Bunny_03_Rb, 0f));

            // use for each try again restart.
            StartOver();
            start_Count = true;
            _countDown.StartCount(1); 
            MovePan(false, pan_Try_Again_Exit, 0, 1); 
        
		}

public void Carrot_Right_MO()
		{
			//Carrot_Left_Glow.SetActive(true); // Enable glow carrot sprite.
			StartCoroutine(Lerp_Color_Alpha(Carrot_Bitten_Glow_SR, color_Zero, color_Max, .5f, 0f));  // lerp glow carrot alpha to max.
			 
			//.speed = 2f;
     // left_Bunnies_Animator.Play("Base Layer.good_Bunny_03_MO",-1 , 0);  // Make bunny twitch. 
		}


public void Carrot_Right_ME()
		{				
			StartCoroutine(Lerp_Color_Alpha(Carrot_Bitten_Glow_SR, color_Max, color_Zero, .5f, 0f));  // lerp glow carrot alpha to zero.
			
		}
		

public void Carrot_Right_MUP()
		{				
			
		}

		
void Turn_Off_Carrot()
			{
				carrot_Right.SetActive(false);
			}


    IEnumerator Unfreeze(Rigidbody2D rb2D, float wfs)
    {
       yield return new WaitForSeconds( wfs);
         rb2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }

IEnumerator Freeze(Rigidbody2D rb2D, float wfs)
    {
        yield return new WaitForSeconds( wfs);
        // rb2D.constraints &= RigidbodyConstraints2D.FreezePositionY;
        rb2D.constraints = RigidbodyConstraints2D.FreezeAll; 

    }

#endregion Mopsey_Wins_Functions


IEnumerator Mopseys_Exit()
{
    yield return new WaitForSeconds(2f);

    StartCoroutine(mopseys_Exit_Text());

    yield return new WaitForSeconds(4f);

bad_Hearts_01_PS.Play();
Fade_Children(bunny_01);
  
     yield return new WaitForSeconds(1);
   

bad_Hearts_02_PS.Play();
Fade_Children(bunny_02);
   
     yield return new WaitForSeconds(1);
    
    
bad_Hearts_03_PS.Play();
Fade_Children(bunny_03);
    
     yield return new WaitForSeconds(1);

    Opp_Paddle_Exit(mopseys_Paddle, 1);

bad_Hearts_00_PS.Play();
   
    StartCoroutine(Lerp_Transform_Position(opp_Mask, opp_Mask_Center, opp_Mask_Lower, 1, 1));
    yield return new WaitForSeconds(1);

}


IEnumerator mopseys_Exit_Text()
		{
			textBox_width02 = new Vector2(5.5f, 1.5f);
			opponent_TMPro.text = "<size=7>Just wait!<br>  When<br>Ayre Hawki<br>gets <br> here";
			Size_Object(opponent_Text_Box, textBox_width01, textBox_width02, 1, 2);

				while(size_Object_Bool == true) 
				{
					yield return null;
				}
		
			textBox_width03 = new Vector2(5.5f, 6.5f);
			Size_Object(opponent_Text_Box, textBox_width02, textBox_width03, 500, 1.5f);

            while(size_Object_Bool == true)
				{
					yield return null;
				}

			StartCoroutine(Lerp_TMPro_Color_Alpha(tmpro_Object, sunGlass_01, sunGlass_00, 0, .5f));
			
			while(lerp_TMPro_Color_Bool)
				{
					yield return null; 
				}
				 
				opponent_TMPro.text = "<size=10> The<br> fur's<br> gonna<br> fly!"; 
				// opponent_TMPro.color = new Color(0, 0, 0, 1);
				StartCoroutine(Word_Text_Reveal(opponent_TMPro, opponent_TMPro.text, .5f, 0));
				
				yield return new WaitForSeconds(2f);

				StartCoroutine(GlowAdjust(opponent_TMPro, 0, 1f, .5f));
				//yield return new WaitForSeconds(2);
				 StartCoroutine(Lerp_TMPro_Color_Alpha(tmpro_Object, sunGlass_01, sunGlass_00, .8f, 1));
   
    	}
		
		
		
		
		IEnumerator GlowAdjust(TextMeshPro tMPro, float start, float end,  float duration)
		{
			
			glow_On = true;
			float glowPower = 0;
			float time = 0;
			while(time < duration)
					{ 
						glowPower = Mathf.Lerp( start, end, time / duration);

						tMPro.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, glowPower); //new Color32(255, 240, 0, 100));

						time += Time.unscaledDeltaTime;
 
					   yield return null;
					} 

			glowPower = 0;
			time = 0;
					while(time < duration)
					{ 
						glowPower = Mathf.Lerp( end, start, time / duration);

						tMPro.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, glowPower); //new Color32(255, 240, 0, 100));

						time += Time.unscaledDeltaTime;

					   yield return null;
					} 

					glow_On = false;
		}



    public void Angry_Bunnies_Text()
    {

        Set_Font(opponent_TMPro, oh_No_new_Color, oh_No, 10f);
        bunnies_Text = "The bunnies are angry...";
        StartCoroutine(Word_Text_Reveal(opponent_TMPro, bunnies_Text, .3f, 0));
        StartCoroutine(Lerp_TMPro_Color_Alpha(opponent_TMPro, oh_No_new_Color_01, oh_No_new_Color, 1.5f,  1));// fade out text.
    }





public void Fade_Children(GameObject parent)
		{	
			    foreach (Transform t in parent.transform)
				{
					SpriteRenderer SR_Child = t.gameObject.GetComponent<SpriteRenderer>();
					StartCoroutine(Lerp_Color_Alpha(SR_Child, sunGlass_01, sunGlass_00, .5f, 1f));
				}
		}


 IEnumerator Stop_Drops()
        {
                yield return new WaitForSeconds(4f);
                ParticleSystem PS;
                GameObject[] PS_Drops = GameObject.FindGameObjectsWithTag("Drops");
                foreach(GameObject drops in PS_Drops)
                {
                PS = drops.GetComponent<ParticleSystem>();
                PS.Stop();
                }
        }


        void Switch_Cameras(GameObject camera_01, GameObject camera_02)
    {
        camera_01.SetActive(true);
        camera_02.SetActive(false);
    }

public async Task Rotate_Object(RectTransform _object_Rec, float x, float y, float z, float w, float duration, int WFS)
{
    rec_List.Add(_object_Rec);

        await Task.Delay(WFS);
        float time = 0;

                    Quaternion rotation = new Quaternion(x, y, z, w);

                   Quaternion current = _object_Rec.localRotation;

                     while(time < duration)
                    {
                        _object_Rec.rotation =  Quaternion.Slerp(current, rotation, time * 3);

                        time = time + Time.deltaTime;

                        await Task.Yield();
                    }

           // rotate_Object_List.Add(onOff);
            rec_List.Remove(_object_Rec);
          await Task.Yield();
}


public async Task Rotate_Object_02(GameObject _object, Quaternion current, Vector4 xyzw, float duration, int WFS)
{
    gameObject_List.Add(_object);

        await Task.Delay(WFS);
        float time = 0;

                    Quaternion rotation = new Quaternion(xyzw.x, xyzw.y, xyzw.z, xyzw.w);

                   // Quaternion current = _object.transform.localRotation;  Make as a variable to enter as current argument.

                     while(time < duration)
                    {
                        _object.transform.rotation =  Quaternion.Slerp(current, rotation, time * 3);

                        time = time + Time.deltaTime;

                        await Task.Yield();
                    }

            gameObject_List.Remove(_object);
          await Task.Yield();
}






            IEnumerator Scale_Object(RectTransform object_To_Scale, Vector3 start_Size, Vector3 end_Size,  float duration, float WFS)
            {
                //  scale_Object_Bool = false;

                float time = 0f;
          
                    yield return new WaitForSeconds(WFS);

                    while(time <= duration)
                    {
                        object_To_Scale.localScale = Vector3.Lerp(start_Size, end_Size,  time / duration);
                        time += Time.unscaledDeltaTime; 
                       yield return null;
                    }

                    scale_Object_List.Add(true);

                     // scale_Object_Bool = true; 

                      object_To_Scale.localScale = end_Size;

                     // follow++;
                 

                yield return null;
            }


 IEnumerator Move_Object_Bounce_03(RectTransform _object_Rec, float cycle, float speed, float length_X, float length_Y, float duration, float WFS, bool switch_Bool)
        {
			yield return new WaitForSeconds(WFS);

            Move_Object_Bounce_Bool = false;

            float x = _object_Rec.position.x;
            float y = _object_Rec.position.y;

            float time = 0f;
            //float duration = 2f;
            //float length = .1f;

                    while(time < duration)
                    {
                        float xAxis = (Mathf.Sin(time * cycle) * speed) * length_X;
                        float yAxis = Mathf.PingPong (Time.time / .5f, length_Y) + y;
                        _object_Rec.position = new Vector3(xAxis + x, yAxis, 0);

                       //  transform.position = Vector2.Lerp(Vector3_Starting_Position, Vector3_Ending_Position, time / duration );
                        time += Time.deltaTime;
                        yield return null;
                    }

           _object_Rec.position = new Vector3(x, y, 0);

          
             yield return null;

              Move_Object_Bounce_Bool = switch_Bool;
        }
 
public void Opp_Paddle_Intro(Sprite paddle, int child_Num)
		{
			opponent_Paddle.SetActive(true);   // activate opp paddle.
			
			    foreach (Transform t in opponent_Paddle.transform)
				{
					t.gameObject.SetActive(false); // deactivate current child.
				}

			opponent_Paddle_SR.sprite = paddle; // Set sprite to use.
			opponent_Paddle.transform.GetChild(child_Num).gameObject.SetActive(true); // set particle system to active.
			
			Scale_Object(opponent_Paddle, scale_00, scale_01, 1, 0); // Scale sprite to full.
		}


public async void  Opp_Paddle_Exit(Sprite paddle, int child_Num)
		{
			    foreach (Transform t in opponent_Paddle.transform)
				{
					t.gameObject.SetActive(false); // deactivate current child.
				}

			opponent_Paddle_SR.sprite = paddle; // Set sprite to use.
			opponent_Paddle.transform.GetChild(child_Num).gameObject.SetActive(true); // set particle system to active.
			await Task.Delay(500);
		     Scale_Object(opponent_Paddle, scale_01, scale_00, .5f, 0); // Scale sprite to full.
		     await Task.Delay(5000);
             opponent_Paddle.SetActive(false);   // deactivate opp paddle.
}


//-----------------------------------End Mopsey's Dialogue-----------------------------------------------



 #endregion -----Character_Texts-----



       IEnumerator StartFirstMenu()
                {
                    

                        yield return new WaitForSeconds(1);
                        // Time.timeScale = 0;
                        Set_Prefab_Var();
                        menu_Frame_Col.isTrigger = false;
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
 
        menu_Frame = GameObject.FindGameObjectWithTag("MenuFrame");
        menu_Frame_Col = menu_Frame.GetComponent<PolygonCollider2D>();
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
        speedUp = false;
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
            Set_Random_Array();
            text_To_Use_Is = null;
			 
}        




    public void SwitchScreens()
    {
        // Time.timeScale = 1;  

         StartReturnMenu();

        DeActivateButtons();

        menu_Frame_Col.isTrigger = true;

         foreach (FreezeText freezeText in _freezeText)  // is this needed? not in new version.
            {
                 freezeText.bounceOn = false;
            }

        speedUp = true;
         _pointEffectorSwitch.SwitchEffector();
     
         UnFreezeCircles();

        //countDown.StartCount();
       text_Pan_TMPro.color = new Color(1, 1, 1, 1); 
       
        // MovePan();
        Invoke("DestroyPrefabHolder", 2f);

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
            menu_Frame.SetActive(false);
         }
        
         
}
       
 
          public void restoreMenu()
        {
            speedUp = false;
            Scale_Object(Pan, small, large, 1, 0 );

            Pan.SetActive(true);
            endPosLeftOffScreen = panTrans.position;

            Move_Object_Slerp(panTrans, endPosLeftOffScreen, originalPos, slerp_Center_Pos, 1f);


           Set_Prefab_Var();
            menu_Frame_Col.isTrigger = false;
            startMenuScript.StartMenuOff();
            prefabHolder.transform.position = offScreenCB;
            midGameMenuScript.MidGameMenuOn();
            FreezeCircles();
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
   
    
     _text01Score.FadeTextScore01();
     _textTwoScore.FadeTextScore02();
  
    StartCoroutine(Lerp_Transform_Position(prefabHolder, offScreenCB, centerScreenCB, 1, 0 ));
    
    ActivateReturnMenu(false, false);
     _puck.SetActive(false);   
    restoreMenuRunning = false;
} 






    public void LookForPuck()
    {
        if(_puck)
        {
             restoreMenuRunning = true;
             // Time.timeScale = 0;
             ActivateReturnMenu(true, false);
            restoreMenu();
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
           // Color mat_Color = bad_Arua.color;

            while (counter < duration)
            {
                counter += Time.deltaTime;
                float alpha = Mathf.Lerp(0, 1, counter / duration);
                

                bad_Arua.color = new Color(mat_Color.r, mat_Color.g, mat_Color.b, alpha);
               
                yield return null;
            }
        }


public IEnumerator Pan_Asks_U_To_tryAgain()
{
        Pan_Asks_U_To_tryAgain_bool = true;

            text_Pan_TMPro.color =  sunGlass_00;
            Vector2 _start_Size = new Vector2(5.7f, 0);
            Vector2 _end_Size = new Vector2(5.7f, 6);


            _Pan_Says = pan_Try_Again_Text_01;
             text_Pan_TMPro.text = _Pan_Says;

             text_Pan_Transform.sizeDelta = _end_Size;

           yield return (Lerp_TMPro_Color_Alpha(text_Pan_TMPro, sunGlass_00, sunGlass_01, 0,  1));

           yield return (Lerp_TMPro_Color_Alpha(text_Pan_TMPro, sunGlass_01, sunGlass_00, 2,  1));
           
            
        if(!end_Pan_Asks_U_To_tryAgain)
        {
            _Pan_Says = pan_Try_Again_Text_02;
             text_Pan_TMPro.text = _Pan_Says;

         //   Debug.Log("pans text is " + _Pan_Says);

            text_Pan_Transform.sizeDelta = _start_Size;
            text_Pan_TMPro.color =  sunGlass_01;
            Size_Object(text_Pan, _start_Size, _end_Size, 2, 2f);
           
            
            yield return (Lerp_TMPro_Color_Alpha(text_Pan_TMPro, sunGlass_01, sunGlass_00, 3,  1));
        }
            text_Pan_TMPro.text = "";
            end_Pan_Asks_U_To_tryAgain = false;
            end_Lerp_TMPro_Color = false;
            Pan_Asks_U_To_tryAgain_bool = false;

            yield break;
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

            while(time < duration)
            {
                _flower_Menu.localPosition = Vector3.Slerp(  flowers_Start, flowers_End, time / duration);
               _flower_Menu.localScale = Vector3.Lerp( small_Flowers, large_Flowers, time / duration );
                time += Time.unscaledDeltaTime;
                yield return null;
            }  

        }


        public void Reset_Flowers()
        {
                spin_Flowers = false;
            _flower_Menu.localPosition = flowers_Start;
         _flower_Menu.localScale = small_Flowers;
        }

/*
        public void Try_Again( )
        {
            start_Count = true;
            start_Game = false;

            switching_Menu = false;

            try_Again.SetActive(false);
            back_To_Menu.SetActive(false);

            _scoreScaling.Score_Text();

            countDown.delay = 1f;
        }
*/   public void Slerp_In_Stars()
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


        IEnumerator SlerpingStars()
        {
            float time = 0f;
            float duration = 1f;

            yield return new WaitForSeconds(4);

            while(time < duration)
            {
                _flower_Menu.localPosition = Vector3.Slerp(  flowers_Start, flowers_End, time / duration);
               _flower_Menu.localScale = Vector3.Lerp( small_Flowers, large_Flowers, time / duration );
                time += Time.unscaledDeltaTime;
                yield return null;
            }  

        }


        public void Reset_Stars()
        {
                spin_Flowers = false;
            _flower_Menu.localPosition = flowers_Start;
         _flower_Menu.localScale = small_Flowers;
        }





        public void Star_Try_Again()
        {
            end_Pan_Asks_U_To_tryAgain = true;

            if(Pan_Asks_U_To_tryAgain_bool)
            {
                StopCoroutine(Pan_Asks_U_To_tryAgain());  //end pan's coroutine
            }

            start_Count = true;
            start_Game = false;
            switching_Menu = false;
            try_Again.SetActive(false);
            back_To_Menu.SetActive(false);
            _scoreScaling.Score_Text();
            countDown.delay = 1f;

        // Function to remove try againmenu.
            flowers_Particle_01.Play();
            flowers_Particle_02.Play();
            Invoke("Reset_Flowers", 5);


            scoreScaling.Score_Text(); 
            StartOver(); 
            _countDown.StartCount(1); 
            MovePan(false, pan_Try_Again_Exit, 0, 1);  
        }


    void Pans_Text_DOESNT_Follow()
    {
        // Setting the parent to ‘null’ unparents the GameObject
        // and turns child into a top-level object in the hierarchy

        text_Pan_TMPro.text = " ";
        text_Pan.transform.SetParent(null);
       // text_Pan_b_TMPro.text = " ";
       // text_Pan_b.transform.SetParent(null);
    }
    
    public void Start_The_Count()
    {
       StartCoroutine(countDown.MathfSin(3));
    }


     public void MovePan(bool curving, string speech, float wfs, float delay)
        {

            if(curving == true)
            {
                Move_Object_Curve_Async(panTrans, originalPos, first_Curve_Height, gamePosLeft, 1, 600);
                Scale_Object(Pan, large, small, 1, 600 );
                Set_Scoreboard(300);
            }

       
             text_For_Pan = speech;
            
            text_Pan_TMPro.text = text_For_Pan;

     //   Debug.Log("pans move text is " + text_Pan_TMPro.text);
         
            StartCoroutine(Lerp_TMPro_Color_Alpha (text_Pan_TMPro, sunGlass_00, sunGlass_01, wfs, 1));
            StartCoroutine(Lerp_TMPro_Color_Alpha(text_Pan_TMPro, sunGlass_01, sunGlass_00, delay, 1));
           
           			if(Pan_Leaves_Screen) // added.
{
            StartCoroutine(Lerp_Transform_Position(Pan, gamePosLeft, endPosLeftOffScreen_Fixed, 1, delay ));
            
            StartCoroutine(Set_Object_Activate(Pan, false, 7));
            Vector2 _end_Size = new Vector2(5, 1);
            text_Pan_Transform.sizeDelta = _end_Size;
}
      //  Debug.Log("pans next move text is " + text_Pan_TMPro.text);
        }

public async void Set_Scoreboard(int _sec_2_Wait)
{
    await Task.Delay(_sec_2_Wait);
            
            _startFireWorks01.FireWorks01();
            _startFireWorks02.FireWorks02();
             _text01Score.StartText01();
            _textTwoScore.StartText02();
}

IEnumerator MoveTowards_Object(RectTransform object_Rec, Vector3 target, float movementSpeed, float WFS)
{

    yield return new WaitForSeconds(WFS);

     Vector3 velocity = Vector3.zero;

		while(object_Rec.position != target)
		{
			//object_Rec.position = Vector3.MoveTowards(object_Rec.position, target, movementSpeed * Time.deltaTime);
            object_Rec.position =  Vector3.SmoothDamp(object_Rec.position, target, ref velocity, movementSpeed);
			yield return null;
		}

		if(object_Rec.position == target)
		{
            yield return null;
		}
}


IEnumerator Math_lerp_Cam_Size(Camera cam, float start_Cam_Size, float end_Cam_Size, float duration, float WFS)
{

        yield return new WaitForSeconds(WFS);
		float time = 0;
         float velocity = 0.0f;
		// float new_Cam_Size;

		while( time < duration )
		{
				float new_Cam_Size = Mathf.Lerp(start_Cam_Size, end_Cam_Size, time * duration );
				cam.orthographicSize = new_Cam_Size;
               // cam.orthographicSize = Mathf.SmoothDamp(start_Cam_Size, end_Cam_Size, ref velocity, time / duration);
				time += Time.deltaTime;
                //Debug.Log(new_Cam_Size);
                // Debug.Log("time is " + time);
                yield return null;
		}
}

}