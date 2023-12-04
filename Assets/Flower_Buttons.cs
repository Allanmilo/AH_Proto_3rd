using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
// using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Experimental.Rendering.Universal;

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

    GameObject child_00;

    GameObject child_01;
    GameObject child_02;
    Light2D text_Light_Glow;

float child_00_Speed;

float child_01_Speed;

Vector3 rotate_Object_01;

Vector3 rotate_Object_02;

    void Start()
    {
        _AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
		_AHManager =  _AHScriptManager.GetComponent<AHScriptManager>();

         textCountDown = GameObject.FindGameObjectWithTag("TextCountDown");
		_countDown =  textCountDown.GetComponent<CountDown>();

        _Score = GameObject.FindGameObjectWithTag("Score");
		scoreScaling =  _Score.GetComponent<ScoreScaling>();

        _menuButtonAlpha = GetComponent<SpriteRenderer>().color; // Sets _menuButtonAlpha to equal the value of the game objects SpriteRenderer color.
     
        GetComponent<SpriteRenderer>().color = _menuButtonAlpha;

        child_00 = gameObject.transform.GetChild(0).gameObject;

        child_01 = gameObject.transform.GetChild(1).gameObject;

        child_02 = gameObject.transform.GetChild(2).gameObject;

        text_Light_Glow = child_00.GetComponent<Light2D>();
        
        child_00_Speed = 5f;
        child_01_Speed = 7f;

        rotate_Object_01 = new Vector3(0, 0, 1);

	    rotate_Object_02 = new Vector3(0, 0, 1);

        Spinning_Menus();

    }



    void Update()
{
    alpha = _menuButtonAlpha.a;
}
    
public async void Spinning_Menus()
{
    Debug.Log(child_00);
    Debug.Log(child_01);
	while(true)
	{
		child_00.transform.Rotate( rotate_Object_01 * child_00_Speed * Time.deltaTime);
		child_01.transform.Rotate( rotate_Object_02 * child_01_Speed * Time.deltaTime);
        await Task.Yield();

	}
}

    void OnMouseOver()
    {
        Debug.Log("1 " + rotate_Object_02);
         child_00_Speed = 20;
         rotate_Object_02.z = -1; // spin opposite direction.
        Debug.Log("2 " + rotate_Object_02);
          text_Light_Glow.intensity = 50;

    }


     void OnMouseExit()
    {
         text_Light_Glow.intensity = 0;
      // StopCoroutine(Text_Glowing(1, 1));

         child_00_Speed = 5;
         rotate_Object_02.z = 1;
    }

    void OnMouseUp()
    {
        text_Light_Glow.intensity = 0;

        if(gameObject.tag == "Try_Again")
        { _AHManager.Pan_Leaves_Screen = true;
             _AHManager.Character_Try_Again_Fun();
            
        }
        else
        {
                _AHManager.restoreMenu();
                _AHManager.Pan_Leaves_Screen = false;
        }

        text_Light_Glow.intensity = 0;
      // StopCoroutine(Text_Glowing(1, 1));

         child_00_Speed = 5;
         rotate_Object_02.z = 1;

    }

IEnumerator Text_Glowing(float Speed, float Amplitude)
{

        float y = 0;
        float time = 0;

                while (y >= 0)
                {
                    float angle = time * Time.deltaTime * Speed;
                    y = Amplitude * (Mathf.Sin(angle));

                    text_Light_Glow.intensity = y;
                    time += 1f;

                    yield return null;
                }
}



}
