/*
	Creates white button rectangle to cover menu selection text.
	Makes alpha value go from zero to full on mouse over, and back to zero on mouse exit.
	On mouse up, runs function SwitchScreens.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu_Buttons : MonoBehaviour
{
    Color _menuButtonAlpha;  

    Color start_Hue_All;
    Color gentle;
    Color notch;
    Color bring;
    Color run;


    [SerializeField] float alpha;

    GameObject _AHScriptManager;
    AHScriptManager _AHManager;

    GameObject _pan;
    TextMeshProUGUI _pans_Text;

    Vector3 start_Vector;
    Vector3 end_Vector;

    public bool mouse_Over_On;

    public bool mouse_Over_True;

    public bool scale_Object_Bool;

    GameObject textCountDown;
    CountDown _countDown;


    void Awake()
    {

		_AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
		_AHManager =  _AHScriptManager.GetComponent<AHScriptManager>();

        start_Vector = new Vector3(1.78f, 1.78f, 0);
        end_Vector = new Vector3(2, 2, 0);
		
        mouse_Over_On = false;
        mouse_Over_True = false;
        scale_Object_Bool = false;

        start_Hue_All = new Color32(255, 255, 255, 200);
        gentle = new Color32(240, 150, 150, 255);
        notch = new Color32(240, 150, 150, 255);
        bring = new Color32(231, 82, 82, 255);
        run = new Color32(255, 255, 255, 255);

         textCountDown = GameObject.FindGameObjectWithTag("TextCountDown");
		_countDown =  textCountDown.GetComponent<CountDown>();
       
    }



void Update()
{

    /*
    if (Input.GetKeyDown(KeyCode.W))
    {
        
    }
    */
}


void OnMouseOver()
    {
        if(gameObject.tag == "MainMenu")
        {
       mouse_Over_True = true;
        }
    }



   void OnMouseEnter()
    {
      if(gameObject.tag == "MainMenu")
    {
        StartCoroutine(Scale_on_Mouse_Over());  
    }     
    }



     void OnMouseExit()
    {
        if(gameObject.tag == "MainMenu")
    {
      mouse_Over_True = false;
    }
    }


    void OnMouseUp()
    {
      if(gameObject.tag == "MainMenu")

      {
        foreach(SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) 
        {
            sr.material.color = start_Hue_All;
        }

        mouse_Over_On = false;
        mouse_Over_True = false;
        scale_Object_Bool = false;
        _AHManager.gameObject_List.Clear();

        _AHManager.IsCanceled = true;

        if (gameObject.name == "BeGentle")
        {
            _AHManager._maxPuckSpeed = 20f;  

            _AHManager._maxAISpeed = 8f;
        
            _AHManager.start_Count = true;

             _AHManager.start_Game = true;

            _AHManager.SwitchScreens();
            _countDown.StartCount(3);
            _AHManager.MovePan(true, _AHManager.firstToFive, 1, 5.5f);
        }
        
        
        if (gameObject.name == "UpANotch")
        {
           _AHManager._maxPuckSpeed = 35f;  

            _AHManager._maxAISpeed = 30f;

            _AHManager.start_Count = true;

             _AHManager.start_Game = true;

            _AHManager.SwitchScreens();
        }
            

        if (gameObject.name == "BringItOn")
        {
           _AHManager._maxPuckSpeed = 80f;  

            _AHManager._maxAISpeed = 40f;

            _AHManager.start_Count = true;

             _AHManager.start_Game = true;

            _AHManager.SwitchScreens();
        }
            

        if (gameObject.name == "RunAway")
        {
            Application.Quit();
        }




        if (gameObject.name == "JumpBackIn")
        {
           _AHManager.start_Game = false;
            //_pans_Text.text = "That's the spirit!";
             _AHManager.SwitchScreens();
            _countDown.StartCount(3);
            _AHManager.MovePan(true, _AHManager.firstToFive, 1, 5.5f);
        }
            

        if (gameObject.name == "StartOver")
        {       
            _AHManager.Pan_Leaves_Screen = true;
             _AHManager.start_Game = true;
            _AHManager.switching_Menu = true;

           _AHManager.StartOver();
            _AHManager.Switch_Menus();

            _AHManager.Pick_Opponent("Star"); 
            
	 

        }
            

        if (gameObject.name == "2ndRunAway")
        {
            Application.Quit();
        }
      }
    }

IEnumerator Scale_on_Mouse_Over()
    {
        if(!_AHManager.gameObject_List.Contains(gameObject) && scale_Object_Bool == false )    
        {
			 scale_Object_Bool = true;

          

			_AHManager.Scale_Object(gameObject, start_Vector, end_Vector, .3f, 0 );


			foreach(SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) 
                    {
                        sr.material.color = run;
                    }

				while(_AHManager.gameObject_List.Contains(gameObject) || mouse_Over_True == true)
				{
					yield return null;
				}

			_AHManager.Scale_Object(gameObject, end_Vector, start_Vector, .2f, 0 );

			foreach(SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) 
                    {
                        sr.material.color = start_Hue_All;
                    }
			
			scale_Object_Bool = false;
        }
 
    }


   

}
