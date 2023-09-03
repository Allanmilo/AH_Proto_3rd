using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class Carrot_Right_Script : MonoBehaviour
{
    // GameObject the_Carrots;
  //  Raise_Carrots carrots_Script;

    GameObject AHScriptManager;
    AHScriptManager _AHManager;

    public TMP_Text m_TextComponent;

       
        Color32 first_Color;
        Color32 second_Color;

        Color32 now_Color;

        public float duration;

       // float startTime;

        TextMeshPro letters;

    //    RectTransform object_Rec;

void Awake()
        {
          //  m_TextComponent = gameObject.GetComponent<TMP_Text>();
        }


    void Start()
    {
       // the_Carrots = GameObject.FindGameObjectWithTag("Carrots");
       // carrots_Script = the_Carrots.GetComponent<Raise_Carrots>();

         AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
        _AHManager = AHScriptManager.GetComponent<AHScriptManager>();

        letters = this.gameObject.GetComponent<TextMeshPro>();

          //  object_Rec = this.gameObject.GetComponent<RectTransform>();

            first_Color = new Color32(255, 205, 5, 255);
            second_Color = new Color32(220, 5, 15, 255);
      //      startTime = Time.time;

            if(gameObject.tag == "Trytry");
            {
                Rainbow(first_Color, second_Color);
            }

             if(gameObject.tag == "Again");
            {
                Rainbow( second_Color, first_Color);
            }
    }

    

    void OnMouseEnter()
		{
			_AHManager.Carrot_Right_MO();
            
        }


void OnMouseExit()
		{				
			_AHManager.Carrot_Right_ME();
		}

public async void Rainbow(Color32 first, Color32 second)
        {
            Debug.Log(gameObject.tag);
        // yield return new WaitForSeconds(5f);
            float start_Point = Time.time;

                    while(duration > 0)
                {
                        now_Color = Color.Lerp( first , second ,  start_Point / duration) ;
                        m_TextComponent.outlineColor  = Color.Lerp(first_Color, second_Color, Mathf.PingPong(Time.time, 1));
                        await Task.Yield();
                }
        }




}


