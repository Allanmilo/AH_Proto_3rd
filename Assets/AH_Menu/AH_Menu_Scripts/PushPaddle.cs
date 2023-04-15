using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PushPaddle : MonoBehaviour
{
    Rigidbody2D menu_Paddle_RB;

    GameObject AHScriptManager;
    AHScriptManager _AHManager;

    TextMeshPro tmpText;

    Color tmProColor_1; 
    Color tmProColor_0;

    bool stopTalk;

    [SerializeField] float exitSpeed;

    Vector3 viewPos; // Variable for storing the current transform position.

    int speed;


    void Start()
    {
        AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
        _AHManager = AHScriptManager.GetComponent<AHScriptManager>();

        tmpText = transform.GetChild(0).GetComponent<TextMeshPro>();

        menu_Paddle_RB = this.gameObject.GetComponent<Rigidbody2D>();

        menu_Paddle_RB.AddForce( RandomVector(10, 5), ForceMode2D.Impulse);

        tmProColor_1 =  new Color(1, 1, 1, 1);
        tmProColor_0 =  new Color(1, 1, 1, 0);

        speed = (Random.Range(0, 2) * 2 - 1) * 15;   // Sets int speed to either15 or -15.

        stopTalk = false;
    }

    void Update()
    {
        if(_AHManager.speedUp == true)
        {
            transform.position += transform.position * 1f * Time.deltaTime; // makes paddles move a little faster.
            transform.Rotate(0, 0, speed, Space.Self); // gives paddles a spin as menu blows apart
        }
    }

    void OnCollisionEnter2D(Collision2D collisionStuff)
    {
        if(collisionStuff.collider.tag == "MenuPucks")
        {
            if (_AHManager.paddle_Array_Pos >= _AHManager.paddle_Trash_Talk_Array.Length - 1) // This if statement will return the array position to slot zero after reaching the end position of array.
            {
                _AHManager.paddle_Array_Pos = 0;
            }

        /*
                    if (puckArray >= pucksInMenu.Length) // This if statement will return the array position to slot zero after reaching the end position of array.
                    {
                        puckArray = 0;
                    }
        */

        tmpText.text = _AHManager.paddle_Trash_Talk_Array[_AHManager.paddle_Array_Pos]; // Assigns the text from one of the array positions to the TMPro component of the pucks child.

        _AHManager.paddle_Array_Pos++; // advances arrayPos by one.


        if(stopTalk == false)
            {
                StartCoroutine(PuckTalking());
            }

        }
        
    }


    IEnumerator PuckTalking()
    {
        stopTalk = true;

        tmpText.color = tmProColor_1;  // Sets slpha to full.

        yield return new WaitForSecondsRealtime(0);

        for (float t = 0.0f; t < 1.0f; t += Time.unscaledDeltaTime) // Runs lerp for certian amount of time.
        {
            tmpText.color = Color.Lerp(tmProColor_1, tmProColor_0, t); // Lerp alpha from full to zero.
            yield return null;
        }
        yield return new WaitForSecondsRealtime(3);

        stopTalk = false;
    }



    private Vector3 RandomVector(float min, float max)  // Function to return random number vector used for velocity.
    {
        float 
        x = Random.Range(min, max);
        return new Vector3(x, 0, 0);
    }
    
}
