using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Control_Script_01 : MonoBehaviour
{
    public List<GameObject> paddle =  new List<GameObject>();
    public int listPick;
    public bool stop_Col;
	public GameObject ball_Ran;
    public GameObject next_Ball;
    int maxAttempts;


    void Start()
    {
        stop_Col = false;
        maxAttempts = 50;
    }

   
    public void Pick_Paddle()
    {
        if (paddle.Count >= 2)
        {  
            for (int i = 0; next_Ball == ball_Ran && i < maxAttempts; i++)
            {
                listPick = Random.Range(0, paddle.Count);
                ball_Ran = paddle[listPick];
            }

                 next_Ball = ball_Ran;
        }

            ball_Ran.GetComponent<PushPaddle>().Start_Talk();

            paddle.Clear();
       
    }

}

