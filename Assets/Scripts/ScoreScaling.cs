
// Script attached to Score game object.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScaling : MonoBehaviour
{

	public Vector2 minScale;
	public Vector2 maxScale;

	public float speed = 3f;
	public float duration = .1f;

	public TextMeshPro scoreScale_Text;

	float scoreScaling_Secs_2_Wait;

	string achievment_Text; 

	void Start()
	{
		achievment_Text = " ";
		scoreScale_Text = GetComponent<TextMeshPro>();
		Score_Text();
	}


	public void Score_Text()
	{
		scoreScale_Text.text = "Score!";
		scoreScale_Text.color = new Color32(6, 242, 39, 255);
		scoreScale_Text.fontSize = 28;
		scoreScaling_Secs_2_Wait = 0;
	}

	public void Lose_Text()
	{
		scoreScale_Text.text = "You Lose!";
		scoreScale_Text.color = new Color32(203, 22, 5, 255);
		scoreScale_Text.fontSize = 20;
		scoreScaling_Secs_2_Wait = 0;
	}

	public void Win_Text()
	{
		scoreScale_Text.text = "You won!";
		scoreScale_Text.color = new Color32(224, 214, 31, 255);
		scoreScale_Text.fontSize = 20;
		scoreScaling_Secs_2_Wait = 0;
	}

	public void Achievment_Unlocked(int achievment_Num)
	{
		if(achievment_Num == 01)
		{
			achievment_Text = "<b><size=7><color=#FF85B3>-ACHIEVMENT UNLOCKED-</color></b>\nMade a little girl cry!";
		}

		scoreScale_Text.text = achievment_Text;
		scoreScale_Text.color = new Color32(219, 91, 189, 255);
		scoreScale_Text.fontSize = 8;
		scoreScaling_Secs_2_Wait = 2;
		Scoring();
	}




	
public void Scoring()
{
	StartCoroutine(Scaling());
}

	public IEnumerator Scaling()

	{
		minScale = new Vector2(0f, 0f); // sets scale to original setting.

			yield return ScoringLerp(minScale, maxScale, duration); //lerp up scale
			yield return new WaitForSeconds(scoreScaling_Secs_2_Wait);
			yield return ScoringLerp(maxScale, minScale, duration); // lerp down scale
			yield return null;
	}

	public IEnumerator ScoringLerp(Vector2 a, Vector2 b, float time)
	{
		float i = 0.0f;
		float rate = (1.0f / time) * speed;

		while (i < 1.0f)
		{
			i += Time.deltaTime * rate;
			transform.localScale = Vector2.Lerp(a, b, i);
			yield return null;
		}
	}
}