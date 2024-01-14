using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    RectTransform obj_Rect;

    public float dura;
    public float freq;
    public float shake;


    void Start()
    {
        obj_Rect = GetComponent<RectTransform>();


    }

   
    void Update()
    {
       
    }


    IEnumerator Shake_01(RectTransform obj_Rect, float duration, float frequency, float shakeFrequency)
{
	// duration = length of time shaking will occur.
	// frequency = length of time for each individual shake.
	// shakeFrequency = size of shaking.
	
		float time = 0f;
		
		Vector3 _orignalPosOfCam = obj_Rect.position;

	 while(time < duration)
	{
            Vector3 currentPosOfCam = obj_Rect.position;
        
            Vector3 random_Pos = _orignalPosOfCam + Random.insideUnitSphere * shakeFrequency;
            
            float time_Freq = 0;

			while(time_Freq < frequency)
				{
					obj_Rect.position = Vector3.Lerp( _orignalPosOfCam, random_Pos, time_Freq/frequency );

					time_Freq += Time.unscaledDeltaTime;

					yield return null;
				}
				
		time += Time.unscaledDeltaTime;
		yield return null;
    }
       
        float time_Freq02 = 0;
        Vector3 _currentPosOfCam = obj_Rect.position;

        while(time_Freq02 < frequency)
				{
					obj_Rect.position = Vector3.Lerp(_currentPosOfCam,  _orignalPosOfCam, time_Freq02/frequency );

					time_Freq02 += Time.unscaledDeltaTime;

					yield return null;
				}
	
}
}
