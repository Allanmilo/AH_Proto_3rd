using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashFadeTop : MonoBehaviour
{
	// setting variables
	public Color startColor;
	public Color endColor;

	public float fadeInTime = 1f;
	public float fadeOutTime = 2f;
	public float fadeDelay = 3f;

	private SpriteRenderer _spriteRender;
	public FlashFadeGoalTop flashFadeGoalTop;

	public GameObject startingPuck;
	private Vector2 puckPos;

	public float topDelayDrop;

	[SerializeField]
	private TextMeshPro bottomGoalScore;
	public int scoreValue01;
	public StartFireWorks02 fireWorks02;
	public TextTwoScore textTwoScore;
	public StarBoytext starBoytext;
	public StarGirlText starGirlText;

	public CountDown countDown;
	private Vector2 topPuck;
	private Vector2 countDown02;

	[SerializeField] ScoreScaling _scoreScaling;

	GameObject AHScriptManager;
    AHScriptManager _AHManager;

	GameObject BottomGoal;
	FlashFade _FlashFade;
	public delegate void Player();
	public static event Player player;

	public delegate void Player_Dialogue();
	public static event Player_Dialogue player_Dialogue;

	public delegate void Player_Wins();
	public static event Player_Wins player_Wins;

	Color32 color01;
	Color32 color02;

	[SerializeField]float speed;

	void Awake()
	{
		  AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
        _AHManager = AHScriptManager.GetComponent<AHScriptManager>();

		 BottomGoal = GameObject.FindGameObjectWithTag("GoalFlash");
        _FlashFade = BottomGoal.GetComponent<FlashFade>();

		_spriteRender = GetComponent<SpriteRenderer>();
		_spriteRender.color = new Color(1, 1, 1, 0f);

		topPuck = new Vector2(0f, 3.6f);
		countDown02 = new Vector2(0f, 3.6f);
		scoreValue01 = 0;
		
		fireWorks02 = GameObject.FindGameObjectWithTag("FireWorks02").GetComponent<StartFireWorks02>();
	}



	void OnCollisionEnter2D(Collision2D top)
	{
		if (top.gameObject.tag == "Puck")
		{
			//color01 = _AHManager.your_Paddle_SR.color;
			
			//  _AHManager.color_Pulse_Bool = false;
			// StopCoroutine(_AHManager.Color_Pulse(_AHManager.your_Paddle_SR, _AHManager.color01, _AHManager.color02, 3));
		 _AHManager.stop_Routines();
		 _AHManager.color_Pulse_Bool = false;
			_AHManager.your_Paddle_SR.sprite = _AHManager.paddle_Win_Sprites[Random.Range(0, 4)];

		// yellow.
		 color01 = new Color(.4f, .4f, 0, 1);
		color02 = new Color(1f, 1f, 0, 1);
			
			_AHManager.Start_Color_Pulse(_AHManager.your_Paddle_SR, color01, color02, 1, speed);
		// _AHManager.your_Paddle_SR.color = Color.white;

			//_AHManager.Pick_Player();
			scoreValue01 += 1;

			if (scoreValue01 <= 4)
			{
				_AHManager.ActivateReturnMenu(true, false);

				countDown.SetCDPos(false, topPuck, countDown02);
				Flash();
				_scoreScaling.Score_Text();
				_scoreScaling.Scoring();
				flashFadeGoalTop.FlashGoal();
				fireWorks02.FireWorks02();
				 textTwoScore.StartText02();

				if(player != null)
					{
						player();
						//player = null;
					}
					

					if(player_Dialogue != null)
					{
						// player_Dialogue();
						//player_Dialogue = null;
					}

				//starBoytext.LoadTalk();
				//_AHManager.Boys_Dialogue();
				_AHManager.Start_The_Count();
				startingPuck.SetActive(false);
				bottomGoalScore.text = ("" + scoreValue01);

				_AHManager.moveForward = 0;
			}

			if (scoreValue01 == 5)
			{
				_AHManager.ActivateReturnMenu(true, false);

				_scoreScaling.Win_Text();

				Flash();
				_scoreScaling.Scoring();
				flashFadeGoalTop.FlashGoal();
				fireWorks02.FireWorks02();
				 textTwoScore.StartText02();
				startingPuck.SetActive(false);
				//	_AHManager.your_Paddle_SR.sprite = _AHManager.face_Two;
					_AHManager.moveForward = 0;
					Debug.Log("moveforward flashfadetop is " + _AHManager.moveForward);
				_AHManager.Start_Character_Loses();

				bottomGoalScore.text = ("" + scoreValue01);
			}
		}
	}


	public void Flash()
	{

		_spriteRender.color = new Color(1, 1, 1, 1f);
		StartCoroutine(ColorLerpIn());
	}

	// Coroutine
	IEnumerator ColorLerpIn()
	{
		// for loop.
		// Create variable float t. When called, if t is less than the fadeInTime value add 0.01f to t.
		for (float t = 0.01f; t < fadeInTime; t += 0.1f)
		{   // Method will run lerp for the time it takes for t to equal fadeInTime value.
			_spriteRender.material.color = Color.Lerp(startColor, endColor, t / fadeInTime);

			yield return null;
		}
		yield return new WaitForSeconds(fadeDelay); // Causes delay before starting colorLerpOut coroutine.
		StartCoroutine(ColorLerpOut());
	}

	// reverse of colorLerpIn coroutine.
	IEnumerator ColorLerpOut()
	{
		for (float t = 0.01f; t < fadeOutTime; t += 0.1f)
		{

			_spriteRender.material.color = Color.Lerp(endColor, startColor, t / fadeOutTime);

			yield return null;
		}

	}
}
