
/*
This script creates and sets the text for the Menu pucks.
When puck crosses the colidder line it activates the ontriggerenter2D function.
Displays text and fades out before allowing any other triggers.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PuckColliderScript : MonoBehaviour
{  
    string[] orderList; // String used to store text lines.
    public int arrayPos; // Int used to return array loop back to the first entry - orderList[0].
    public int puckArray;
    float duration = 1f; // Float used to adjust speed of lerp.
       
        Color32 tmProColor_0 = new Color32(1, 1, 1, 225);  // Set alpha of text to full.
        Color32 tmProColor_1  = new Color32(1, 1, 1, 0);   // Sets alpha of text to zero.
       

       TextMeshPro tmpText; // Used to access text mesh pro for its color component.

        bool triggerDelay; // Boolean used to prevent more than one text from displaying at a time.

         public Component[] pucksInMenu;

        

    void Start()
    {

          arrayPos = 0;
          puckArray = 0;

        orderList = new string[5];

        orderList[0] = "Make my Day!";
        orderList[1] = "Yippee ki yay!";
        orderList[2] = "You lookin' at me?";
        orderList[3] = "Feelin' lucky?";
        orderList[4] = "You're goin' DOWN!";   

        triggerDelay = true; 
       
    }


        void Update()
        {
                while(triggerDelay)
                {
                    triggerDelay = false;

                    if(arrayPos >= orderList.Length - 1) // This if statement will return the array position to slot zero after reaching the end position of array.
                    {
                        arrayPos = 0;
                    }

                     if(puckArray >= pucksInMenu.Length) // This if statement will return the array position to slot zero after reaching the end position of array.
                    {
                        puckArray = 0;
                    }

                  pucksInMenu[puckArray].GetComponent<TextMeshPro>().text = orderList[arrayPos]; // Assigns the text from one of the array positions to the TMPro component of the pucks child.
                
                    arrayPos++; // advances arrayPos by one.

                    

                    tmpText = pucksInMenu[puckArray].GetComponent<TextMeshPro>(); // Equals TMPro of pucks child.

                    puckArray++;
                   StartCoroutine(PuckTalking());
       
                } 
        }


            IEnumerator PuckTalking()
            {
                tmpText.color = tmProColor_0;  // Sets slpha to full.

                         yield return new WaitForSecondsRealtime(1);

                for (float t = 0.0f; t < 1.0f; t += Time.unscaledDeltaTime ) // Runs lerp for certian amount of time.
                    {
                        tmpText.color = Color.Lerp(tmProColor_0, tmProColor_1, t); // Lerp alpha from full to zero.
                        yield return null;
                    }
                         yield return new WaitForSecondsRealtime(2);

               triggerDelay = true; 
            }    
}
