using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarGirlText : TextCoroutines
{
    public int[] orderList;
    public int arrayPos;

    public bool wait;

    public float alphaTalk;

   //  public GameObject FF01;
    public FlashFade flashFade;

    [SerializeField] GameObject star_Is_Sad;
    [SerializeField] ParticleSystem star_Is_Happy;
    GameObject AHScriptManager;
    AHManager _AHManager;

    

    void Awake()
    {
        star_Is_Happy.Pause();

        AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
        _AHManager = AHScriptManager.GetComponent<AHManager>();

        GameObject FF01 = GameObject.Find("GoalFlash");
         flashFade = FF01.GetComponent<FlashFade>();
    
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


    public void LoadTalk()
    {
        
        switch (orderList[arrayPos])
        {
            case 0:
                flashFade.dropDelay = 4;
               allTalk = girlTalk;  // chose text box.
                maskingTextBox = girlsTextBox; // chose text box container for slide effect.
                trashTalk01 = "<b><size=12><align=right><color=#acaeea>Don't Run!</color></b>";
				trashTalk02 = "<size=10><color=#acaeea><align=right>The puck doesn't bite!</color> ";
                TT1();
                slide = true; // Chose text effect for TT1/trashTalk01.
                StartCoroutine(FadeOutCR());
				StartCoroutine(Talk02Wait(3, 'f', false)); 
                
            break;

            case 1:
                flashFade.dropDelay = 4;
               allTalk = girlTalk;  // chose text box.
                maskingTextBox = girlsTextBox; // chose text box container for slide effect.
                trashTalk01 = "<b><size=12><align=right><color=#acaeea>Did you see that?</color></b>";
				trashTalk02 = "<size=10><color=#acaeea><align=right>No. I guess you didn't</color> ";
                TT1();
                type = true; // Chose text effect for TT1/trashTalk01.
                StartCoroutine(FadeOutCR());
				StartCoroutine(Talk02Wait(3, 'f', false)); 
              
            break;

            case 2:
                flashFade.dropDelay = 5;
               allTalk = girlTalk;  // chose text box.
                maskingTextBox = girlsTextBox; // chose text box container for slide effect.
                trashTalk01 = "<b><size=12><align=right><color=#acaeea>Say...</color></b>";
				trashTalk02 = "<size=10><color=#acaeea><align=right>is that goal AWAYS open?</color> ";
                TT1();
                slide = true; // Chose text effect for TT1/trashTalk01.
                StartCoroutine(FadeOutCR());
				StartCoroutine(Talk02Wait(3, 't', false)); 
            break;

            case 3:
                allTalk = girlTalk;
                flashFade.dropDelay = 3;
                trashTalk01 = "<b><size=12><align=right><color=#acaeea>Hello?</color></b>";
                trashTalk02 = "<size=10><color=#acaeea><align=right>Are you AFK?</color> ";
				maskingTextBox = girlsTextBox;
                TT1();
                fade = true;
                StartCoroutine(FadeOutCR());
				StartCoroutine(Talk02Wait(2, 't', false));
            break;

            case 4:  
                allTalk = girlTalk;  // chose text box.
                flashFade.dropDelay = 3;
                maskingTextBox = girlsTextBox; // chose text box container for slide effect.
                trashTalk01 = "<b><size=12><align=right><color=#acaeea>That's so sweet</color></b>";
				trashTalk02 = "<size=10><color=#acaeea><align=right>You're letting me win!</color> ";
                TT1();
                fade = true; // Chose text effect for TT1/trashTalk01.
                StartCoroutine(FadeOutCR());
				StartCoroutine(Talk02Wait(3, 's', false)); // 1st parameter is WaitForSeconds, 2nd parameter is effect style (f, t, s).

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

    public void Star_Wins()
    {
                allTalk = girlTalk;  // chose text box.
                maskingTextBox = girlsTextBox; // chose text box container for slide effect.
                trashTalk01 = "<b><size=12><align=right><color=#acaeea>That was FUN!</color></b>";
				trashTalk02 = "<size=12><color=#acaeea><align=right>Wanna lose again?</color> ";
                TT1();
                fade = true; // Chose text effect for TT1/trashTalk01.
                star_Is_Happy.Play();
                StartCoroutine(FadeOutCR());
				StartCoroutine(Talk02Wait(3, 's', true)); // 1st parameter is WaitForSeconds, 2nd parameter is effect style (f, t, s).
                _AHManager.Slerp_In_Flowers();
                
    }

    public void Star_Loses()
    {           
                allTalk = girlTalk;  // chose text box.
                allTalk.font = _second_Font;

                maskingTextBox = girlsTextBox; // chose text box container for slide effect.
                trashTalk01 = "<b><size=12><align=right><color=#300101>that wasn't very nice.</color></b>";
				trashTalk02 = "<size=12><color=#300101><align=right>i'm gonna tell on you...</color> ";
                TT1();
                fade = true; // Chose text effect for TT1/trashTalk01.
                StartCoroutine(FadeOutCR());
				StartCoroutine(Talk02Wait(3, 's', false)); // 1st parameter is WaitForSeconds, 2nd parameter is effect style (f, t, s).
                _AHManager.Fade_In_Bad_Arua();
                _AHManager.Move_Star();

    }
    
    
}

