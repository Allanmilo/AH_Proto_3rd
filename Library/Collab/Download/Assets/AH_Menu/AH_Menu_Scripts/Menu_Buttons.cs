/*
	Creates white button rectangle to cover menu selection text.
	Makes alpha value go from zero to full on mouse over, and back to zero on mouse exit.
	On mouse up, runs function SwitchScreens.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Buttons : MonoBehaviour
{

public MenuScript _menuScript; // Creates variable for the MenuScript script that is attached to the CircleBackground game object. 
                               // Assigned in the inspecotr.

Color _menuButtonAlpha;  

    [SerializeField] float alpha;

    public GameObject pointEffectorCircle;

    PanMovement panScript;
    GameObject pan;

    public FreezeText _freezeText; 
    public FreezeText _freezeText02;
    public FreezeText _freezeText03;

    GameObject[] menuButtons;

    
    [SerializeField] Text01Score _text01Score;
    [SerializeField] TextTwoScore _textTwoScore;

    void Awake()
    {
        pointEffectorCircle.SetActive(false);

        pan = GameObject.FindGameObjectWithTag("Pan");
        panScript = pan.GetComponent<PanMovement>();

         _menuButtonAlpha = GetComponent<SpriteRenderer>().color; // Sets _menuButtonAlpha to equal the value of the game objects SpriteRenderer color.
      
      _menuButtonAlpha.a = 0f; // assigns zero to the game object's alpha.
     GetComponent<SpriteRenderer>().color = _menuButtonAlpha;
    }



    void Start()
    {
        menuButtons = GameObject.FindGameObjectsWithTag("MenuButton");

    }

void Update()
{
    alpha = _menuButtonAlpha.a;
}

   void OnMouseOver()
    {
        _menuButtonAlpha.a = .4f;
        GetComponent<SpriteRenderer>().color = _menuButtonAlpha; // gets text sprite renderer component and sets alpha to .4.
        
    }

     void OnMouseExit()
    {
        _menuButtonAlpha.a = 0f;
        GetComponent<SpriteRenderer>().color = _menuButtonAlpha; // gets text sprite renderer component and sets alpha to zero.

    }
    
    void OnMouseUp()
    {
        _menuButtonAlpha.a = 0f;
         GetComponent<SpriteRenderer>().color = _menuButtonAlpha; // gets text sprite renderer component and sets alpha to zero.
        SwitchScreens();
    }



        void SwitchScreens()
    {
        DeActivateButtons();

        _freezeText.bounceOn = false;
        _freezeText02.bounceOn = false;
        _freezeText03.bounceOn = false;
        _menuScript.UnFreezeCircles();
        pointEffectorCircle.SetActive(true);

        panScript.MovePan();

       // _text01Score.StartText01();
       // _textTwoScore.StartText02();
    }
    
    public void DeActivateButtons()
    {
        for(int i = 0; i < menuButtons.Length; i++)
            {
                
                menuButtons[i].SetActive(false);
            }
    }



}
