using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarBoytext : TextCoroutines
{
    public int[] orderList;
    public int arrayPos;

    public bool wait;

    public float alphaTalk;

     public GameObject FF02;
    public FlashFadeTop flashFadeTop;

    void Awake()
    {GameObject FF02 = GameObject.Find("GoalFlash02");
    flashFadeTop = FF02.GetComponent<FlashFadeTop>();
    
        wait = false;

        arrayPos = 0;
        orderList = new int[5];

        orderList[0] = 0;
        orderList[1] = 1;
        orderList[2] = 2;
        orderList[3] = 3;
        orderList[4] = 4;

        for (int positionOfArray01 = 0; positionOfArray01 < orderList.Length; positionOfArray01++)
        {
            int obj01 = orderList[positionOfArray01];
            int randomizeArray01 = Random.Range(0, positionOfArray01);
            orderList[positionOfArray01] = orderList[randomizeArray01];
            orderList[randomizeArray01] = obj01;
        }       
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            LoadTalk();       
        }
    }

    public void LoadTalk()
    {
        switch (orderList[arrayPos])
        {
            case 0:
                flashFadeTop.topDelayDrop = 4;
               allTalk = boyTalk;  // chose text box.
                maskingTextBox = boysTextBox; // chose text box container for slide effect.
                trashTalk01 = "<b><size=12><align=left><color=#ffec8b>FYI</color></b>";
				trashTalk02 = "<size=10><color=#ffec8b><align=left>That's called skill.</color> ";
                TT1();
                fade = true; // Chose text effect for TT1/trashTalk01.
                StartCoroutine(FadeOutCR());
				StartCoroutine(Talk02Wait(2, 't', false)); 
              
            break;

            case 1:
                flashFadeTop.topDelayDrop = 4;
               allTalk = boyTalk;  // chose text box.
                maskingTextBox = boysTextBox; // chose text box container for slide effect.
                trashTalk01 = "<b><size=12><align=left><color=#ffec8b>It's hard</color></b>";
				trashTalk02 = "<size=10><color=#ffec8b><align=left>Making it look so easy.</color> ";
                TT1();
                fade = true; // Chose text effect for TT1/trashTalk01.
                StartCoroutine(FadeOutCR());
				StartCoroutine(Talk02Wait(2, 't', false)); 
              
            break;

            case 2:
                flashFadeTop.topDelayDrop = 4;
               allTalk = boyTalk;  // chose text box.
                maskingTextBox = boysTextBox; // chose text box container for slide effect.
                trashTalk01 = "<b><size=12><align=left><color=#ffec8b>Outta the way!</color></b>";
				trashTalk02 = "<size=10><color=#ffec8b><align=left>Pain-train coming through.</color> ";
                TT1();
                slide = true; // Chose text effect for TT1/trashTalk01.
                StartCoroutine(FadeOutCR());
				StartCoroutine(Talk02Wait(3, 't', false)); 
            break;

            case 3:
                allTalk = boyTalk;
                flashFadeTop.topDelayDrop = 4;
                trashTalk01 = "<b><size=12><align=left><color=#ffec8b>Don't say it...</color></b>";
                trashTalk02 = "<size=12><color=#ffec8b><align=left>I know I'm awesome!</color> ";
				maskingTextBox = boysTextBox;
                TT1();
                fade = true;
                StartCoroutine(FadeOutCR());
				StartCoroutine(Talk02Wait(2, 's', false));
            break;

            case 4:  
                allTalk = boyTalk;  // chose text box.
                flashFadeTop.topDelayDrop = 4;
                maskingTextBox = boysTextBox; // chose text box container for slide effect.
                trashTalk01 = "<b><size=12><align=left><color=#ffec8b>Bet you're thinking-</color></b>";
				trashTalk02 = "<size=10><color=#ffec8b><align=left>That's AMAZING!</color> ";
                TT1();
                slide = true; // Chose text effect for TT1/trashTalk01.
                StartCoroutine(FadeOutCR());
				StartCoroutine(Talk02Wait(3, 'f', false)); // 1st parameter is WaitForSeconds, 2nd parameter is effect style (f, t, s).

            break;
        }
        StepForward();
    }


    public void StepForward()
    {
        if (arrayPos >= orderList.Length - 1)
        {
            arrayPos = 0;
        }

        else
        {
            arrayPos += 1;
        }
    }
    
    
}

