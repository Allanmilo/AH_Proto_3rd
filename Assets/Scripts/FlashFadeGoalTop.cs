using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashFadeGoalTop : MonoBehaviour
{
	// setting variables
	public Color startColor;
	public Color endColor;

	public float fadeInTime = 1f;
	public float fadeOutTime = 2f;
	public float fadeDelay = 3f;

	public GameObject startingPuck;
	private Vector2 puckPos;

	private SpriteRenderer _spriteRender;


	void Awake()
	{
		_spriteRender = GetComponent<SpriteRenderer>();
		_spriteRender.color = new Color(1, 1, 1, 0f);
	}


	public void FlashGoal()
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
