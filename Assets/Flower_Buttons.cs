using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower_Buttons : MonoBehaviour
{

    [SerializeField] float alpha;
    Color _menuButtonAlpha;  

    GameObject _AHScriptManager;
    AHScriptManager _AHManager;

    GameObject textCountDown;
    CountDown _countDown;

    GameObject _Score;
    ScoreScaling scoreScaling;

    void Start()
    {
        _AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
		_AHManager =  _AHScriptManager.GetComponent<AHScriptManager>();

         textCountDown = GameObject.FindGameObjectWithTag("TextCountDown");
		_countDown =  textCountDown.GetComponent<CountDown>();

        _Score = GameObject.FindGameObjectWithTag("Score");
		scoreScaling =  _Score.GetComponent<ScoreScaling>();

        _menuButtonAlpha = GetComponent<SpriteRenderer>().color; // Sets _menuButtonAlpha to equal the value of the game objects SpriteRenderer color.
        _menuButtonAlpha.a = 0f; // assigns zero to the game object's alpha.




        GetComponent<SpriteRenderer>().color = _menuButtonAlpha;
    }

    void Update()
{
    alpha = _menuButtonAlpha.a;
}
    

    void OnMouseOver()
    {
        _menuButtonAlpha.a = 1f;
        GetComponent<SpriteRenderer>().color = _menuButtonAlpha; // gets text sprite renderer component and sets alpha to .4.   

        if(gameObject.name == "Menu_Flower_over_Again")
        {
            _AHManager.flower_Speed_01 = 20; 
        }

        else
        {
            _AHManager.flower_Speed_02 = 20;
        }
    }


     void OnMouseExit()
    {
        _menuButtonAlpha.a = 0f;
        GetComponent<SpriteRenderer>().color = _menuButtonAlpha; // gets text sprite renderer component and sets alpha to zero.
        _AHManager.flower_Speed_01 = 5;
        _AHManager.flower_Speed_02 = 5;
    }
    

    void OnMouseUp()
    {
        _menuButtonAlpha.a = 0f;
         GetComponent<SpriteRenderer>().color = _menuButtonAlpha; // gets text sprite renderer component and sets alpha to zero.
        _AHManager.Try_Again_Star();
        _AHManager.flower_Speed_01 = 5;
        _AHManager.flower_Speed_02 = 5;
        scoreScaling.Score_Text(); 
        _AHManager.StartOver(); 
        _countDown.StartCount(1); 
        _AHManager.MovePan(false, "Go get her!", 0, 1);  // _AHManager.firstToFive
    }



}
