
/*
This script is attached to the CircleBackround game object prefab.
It sets the PointEffectorCircle to false so the effector is off.
It also runs FreezeCircles function which freezes menu circles position.
There is also an UnfreezeCircles function to be called by another script.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject pointEffectorCircle; // Set in Inspector.
 
    MenuCircle_00[] menuCircleScript; // Creates array for menu circles using an empty script attached to each circle.
                                      // Type is set to the name of the script.

   
    void Start()
    {
        pointEffectorCircle.SetActive(false); // Sets effector to off.

        if(pointEffectorCircle.activeSelf)
        {
        Debug.Log("Menu script Start- pointeffector is not active");
        }

        menuCircleScript = GameObject.FindObjectsOfType<MenuCircle_00>(); // Loads array with menu circle.
        
        FreezeCircles();


    }

public void FreezeCircles()
{
         foreach (MenuCircle_00 menuCircle_00  in menuCircleScript)
         {
            menuCircle_00.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll; 

            if(menuCircle_00.gameObject.GetComponent<Rigidbody2D>().constraints == RigidbodyConstraints2D.FreezeAll)
            {
                Debug.Log("Menucircle is frozen");
            }
         }
}

public void UnFreezeCircles()
{
         foreach (MenuCircle_00 menuCircle_00  in menuCircleScript)
         {
            menuCircle_00.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None; 
         }
}

}
