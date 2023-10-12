using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot_Left_Script : MonoBehaviour
{
    
    //GameObject the_Carrots;
    //Raise_Carrots carrots_Script;

    GameObject AHScriptManager;
    AHScriptManager _AHManager;


    void Start()
    {
      //  the_Carrots = GameObject.FindGameObjectWithTag("Carrots");
      //  carrots_Script = the_Carrots.GetComponent<Raise_Carrots>();

        AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
        _AHManager = AHScriptManager.GetComponent<AHScriptManager>();

    }

    

    void OnMouseEnter()
		{
			_AHManager.Carrot_Left_MO();
            
        }


void OnMouseExit()
		{				
			_AHManager.Carrot_Left_ME();
		}


    void OnMouseUp()
		{
			_AHManager.Carrot_Left_MUP();
            
        }
}
