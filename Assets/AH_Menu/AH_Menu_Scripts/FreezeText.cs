/*
		This script is attached to the menu pucks.
		It instantiates a game object/TextMeshPro prefab (menuPucktext) as a child.
		It sets boundaries that keep the pucks in the screen width and height as long as bool bounceOn is true.
		If bounceOn is false (triggered by clicking on a menu selection) boundaries are not given and puck velocity is increased.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using TMPro;

public class FreezeText : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;           // Rigidbody2d component of puck sprite this script is attached to.
    [SerializeField] GameObject _menuPuckText; // MenuPuckText - prefab with TextMeshPro text component.
    GameObject puckTalk;                       // Empty game object to store prefab MenuPuckText.

    Camera MainCamera;   // Camera variable assigned in start.
    
    Vector2 screenBounds;   // Variable to store width and height of play camera screen.
    float objectWidth;      // Variable for storing the width of gameobject (puck) this script is attached to.
    float objectHeight;     // Variable for storing the height of gameobject (puck) this script is attached to.
    
    Vector3 viewPos; // Variable for storing the current transform position.
    float x;         // Variable for storing a random float.
    float y;         // Variable for storing a random float.
    float xPos;      // Float variable equal to x.
    float yPos;      // Float variable equal to y.

   public bool bounceOn; //Switch to set pucks inside boundaries or to allow them to speed up and fly off screen'
   
   Vector3 move;

    void Start()
    {
       // puckTalk = Instantiate(_menuPuckText, gameObject.transform) as GameObject; // MenuPuckText prefab assigned as child 
                                                                                   // of the game object this script is attached to.
       // _menuPuckText.SetActive(true);
         
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera; 

        bounceOn = true; // Starts bool as true.
        
            // rb.velocity = RandomVector(-5f, 5f); // Sets velocity of puck sprite using RandomVector function.
            viewPos = transform.localPosition; // Sets viewPos variable at start to current transform position.

            move = RandomVector(2f, 5f);
            xPos = x; // Stores x variable value in variable xPos.
            yPos = y; // Stores y variable value in variable yPos.

         screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width - 370, Screen.height - 190, 0));  // Sets the value of variable screenBound to screens width and height.
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2

    }

    
    void Update()
    {    

        

                 viewPos += move * Time.unscaledDeltaTime;
                 transform.localPosition = viewPos;

         if (bounceOn) // Only run if bool is set to true.
        {
            // viewPos = transform.position; // Make viewPos equal to current transform position.

                   if ( viewPos.x  <= (screenBounds.x - objectWidth) * -1 || viewPos.x >= screenBounds.x - objectWidth ) // If value of viewPos (current transform position) x is beyond the sreen bounds' x value, do -
                   { 
                        xPos = xPos * -1; // Sets xPos to opposite of current xPos.
                        move = new Vector3(xPos, yPos, 0);
                       // rb.velocity = new Vector2(xPos, yPos);   // Gives puck new velocity using new xPos value.
                   }
       
                  if ( viewPos.y  <= (screenBounds.y - objectWidth)* -1 || viewPos.y >= screenBounds.y - objectWidth )  // If value of viewPos (current transform position) y is beyond the sreen bounds' y value, do -
                   { 
                         yPos = yPos * -1;  // Sets yPos to opposite of current yPos.
                        move = new Vector3(xPos, yPos, 0);
                        // rb.velocity = new Vector2(xPos, yPos); // Gives puck new velocity using new yPos value.
                    }
           }   
           if (!bounceOn) // Only run if bool is set to false.
           {
              //  rb.velocity = new Vector2(xPos * 6, yPos * 6); // Increase current velocity (no boundaries set).
               move = new Vector3(xPos * 6, yPos * 6, 0);
           }   

           
    }


     private Vector3 RandomVector(float min, float max)  // Function to return random number vector used for velocity.
     {
         x = Random.Range(min, max);  
         y = Random.Range(min, max);
    
         return new Vector3(x, y, 0);
     }

}

