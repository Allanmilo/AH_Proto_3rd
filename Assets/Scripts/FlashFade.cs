
// Script attached to The goal flash sprite.
// Flash sprite has edge collider.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class FlashFade : MonoBehaviour
{
	//public StartFireWorks01 fireworks01;

	public Color startColor ; 
	public Color endColor ;   
	
	public float fadeInTime = 1f ;
	public float fadeOutTime = 2f ;
	public float fadeDelay = 3f ;

	public float dropDelay;

	private SpriteRenderer _spriteRender ;
	public FlashFadeGoal flashFadeGoal;
	public CountDown countDown;

	public GameObject startingPuck;
	private Vector2 bottomPuck;
	private Vector2 countDown01;

	[SerializeField]
	public TextMeshPro topGoalScore;
	public int scoreValue02;
	
	public StartFireWorks01 fireWorks01;
	public StarGirlText starGirlText;
	public Text01Score text01Score;
	[SerializeField] ScoreScaling _scoreScaling;
	// public Canvas canvas;
	
	GameObject AHScriptManager;
    AHScriptManager _AHManager;

/*
	public delegate void Character();
	public static event Character character;


	public delegate void Character_Dialogue();
	public static event Character_Dialogue character_Dialogue;

	public delegate void Character_Wins();
	public static event Character_Wins character_Wins;

	public delegate void Character_Loses();
	public static event Character_Loses character_Loses;
*/
	void Awake()
	{
		AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
        _AHManager = AHScriptManager.GetComponent<AHScriptManager>();

		_spriteRender = GetComponent<SpriteRenderer> () ;
		_spriteRender.color = new Color(1, 1, 1, 0f);
		bottomPuck = new Vector2(0f, -3.5f);
		countDown01 = new Vector2(0f, -3.5f);
		scoreValue02 = 0;
	}

	
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Puck")
		
        {	

			//	_AHManager.Pick_Opponent();

			scoreValue02 += 1;

			if (scoreValue02 <= 4)
			{

				_AHManager.ActivateReturnMenu(true, false);

				countDown.SetCDPos(true, bottomPuck, countDown01);
				
				
					
				Flash();
				_scoreScaling.Score_Text();
				_scoreScaling.Scoring();
				flashFadeGoal.FlashGoal();
				fireWorks01.FireWorks01();
				text01Score.StartText01();
				_AHManager.Characters_Text();


				_AHManager.Start_The_Count();
				startingPuck.SetActive(false);
				
				topGoalScore.text = ("" + scoreValue02);
			}



			if (scoreValue02 == 5)
			{
				// Sets puck to player position.
				countDown.SetCDPos(true, bottomPuck, countDown01);  // SetCDPos(bool setCDPos, Vector2 PuckPos, Vector2 GoalPos)
			_AHManager.ActivateReturnMenu(true, false);
			_scoreScaling.Lose_Text(); // Message scaled in and out after a score has been made.

				Flash();
				_scoreScaling.Scoring();
				flashFadeGoal.FlashGoal();
				fireWorks01.FireWorks01();
				text01Score.StartText01();
				startingPuck.SetActive(false);
				_AHManager.Start_Character_Wins();
				_AHManager.start_Count = false;
				
				topGoalScore.text = ("" + scoreValue02);


			}
        }
    }


   public void Flash()
	{	
			_spriteRender.color = new Color(1, 1, 1, 1f);
			StartCoroutine(ColorLerpIn()); 
	}

	
	IEnumerator ColorLerpIn()
	{
		// for loop.
		// Create variable float t. When called, if t is less than the fadeInTime value add 0.01f to t.
		for (float t = 0.01f ; t<fadeInTime ; t += 0.1f ) 
		{   // Method will run lerp for the time it takes for t to equal fadeInTime value.
			_spriteRender.material.color = Color.Lerp ( startColor , endColor , t / fadeInTime) ;

			yield return null ;
		}
		yield return new WaitForSeconds (fadeDelay) ; // Causes delay before starting colorLerpOut coroutine.
		StartCoroutine (ColorLerpOut()) ;
	}

	// reverse of colorLerpIn coroutine.
	IEnumerator ColorLerpOut()
		{
			for ( float t = 0.01f ; t < fadeOutTime ; t += 0.1f )
			{

				_spriteRender.material.color = Color.Lerp(endColor , startColor , t / fadeOutTime) ;

				yield return null ;
			}		
		}
}
