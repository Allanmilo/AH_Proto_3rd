using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicks : MonoBehaviour
{
    GameObject AHScriptManager;
    AHScriptManager _AHManager;



   void Start()
   {
         AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
        _AHManager = AHScriptManager.GetComponent<AHScriptManager>();

   }


void Update()
{

    
    if (Input.GetKeyDown(KeyCode.W))
    {
        _AHManager.OnMouseUp_Fun();
    }
    
}



    void OnMouseEnter()
    {
        
        _AHManager.OnMouseEnter_Fun();
    }

    void OnMouseOver()
    {
        _AHManager.OnMouseOver_Fun();
    } 
    void OnMouseExit()
    {

        _AHManager.OnMouseExit_Fun();
    }
    
    void OnMouseUp()
    {
        _AHManager.OnMouseUp_Fun();
    }

}