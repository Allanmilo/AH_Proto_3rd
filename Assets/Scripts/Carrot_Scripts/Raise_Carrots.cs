using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Threading.Tasks;

public class Raise_Carrots : MonoBehaviour
{
    

    GameObject good_Bunny_02;
    GameObject good_Bunny_03;

 Rigidbody2D good_Bunny_03_Rb;
    RectTransform good_Bunny_02_Rec;

public List<GameObject> gameObject_List; // = new List<GameObject>();




public List<RectTransform> rec_List;

GameObject carrots;
 GameObject Carrot_Left_Glow;

GameObject Carrot_Bitten_Glow;

GameObject carrot_Right;

GameObject open_Mouth;

    Vector3 down;
    Vector3 up;

 Vector3 good_Bunny3_Start_Pos;
 Vector3 good_Bunny3_End_Pos;
 
Vector3 zero;
Vector3 one;

 SpriteRenderer Carrot_Left_Glow_SR;
 SpriteRenderer Carrot_Bitten_Glow_SR;
 Color color_Max;
 Color color_Zero;

 Color show_Color;
 Color alpha_Zero;
 private Animator left_Bunnies_Animator; 


 //public static List<bool> scale_Object_List = new List<bool>();
 // public static List<bool> rotate_Object_List = new List<bool>();



    void Start()
    {
      
      //  Left_Carrot = GameObject.FindGameObjectWithTag("Carrot_Left");
        good_Bunny_03 = GameObject.FindGameObjectWithTag("good_Bunny_03");
        good_Bunny_03_Rb = good_Bunny_03.GetComponent<Rigidbody2D>();

        good_Bunny_02 = GameObject.FindGameObjectWithTag("good_Bunny_02");
        good_Bunny_02_Rec = good_Bunny_02.GetComponent<RectTransform>();



        carrots = GameObject.FindGameObjectWithTag("Carrots");
        carrot_Right = GameObject.FindGameObjectWithTag("Carrot_Right");
        open_Mouth = GameObject.FindGameObjectWithTag("Open_Mouth");

        up = new Vector3(0, -3, 0);
        down = new Vector3(0, -10, 0); 

good_Bunny3_Start_Pos = new Vector3(7.5f, -4.8f, 0);
good_Bunny3_End_Pos = new Vector3(5f, -4.8f, 0);

zero = new Vector3(0, 0, 0);
one = new Vector3(1, 1, 1);

		left_Bunnies_Animator = good_Bunny_03.GetComponent<Animator>();
  
		Carrot_Left_Glow = GameObject.FindGameObjectWithTag("Carrot_Left_Glow");
		Carrot_Left_Glow_SR = Carrot_Left_Glow.GetComponent<SpriteRenderer>();

    Carrot_Bitten_Glow = GameObject.FindGameObjectWithTag("Carrot_Right_Glow");
		Carrot_Bitten_Glow_SR = Carrot_Bitten_Glow.GetComponent<SpriteRenderer>();

    show_Color = Carrot_Left_Glow_SR.material.color;

		color_Max = new Color(show_Color.r ,show_Color.g , show_Color.b, 1.1f);
		color_Zero = new Color(show_Color.r ,show_Color.g , show_Color.b, 0);

		Carrot_Left_Glow_SR.material.color = color_Zero; 		
    Carrot_Bitten_Glow_SR.material.color = color_Zero; 
    }

    
    void Update()
    {
      
         if (Input.GetKeyUp(KeyCode.S))
        {
          
            StartCoroutine(Lerp_Transform_Position(carrots, down, up, .7f, 0 ));
            StartCoroutine(Unfreeze());
        }

        if(Input.GetKeyUp(KeyCode.W))
      {
        StartCoroutine(Start_Carrots());
      }

    }

    
    IEnumerator Start_Carrots()
    {
      Carrot_Bitten_Glow.SetActive(false);

       StartCoroutine(Lerp_Transform_Position(carrots, down, up, .7f, 0 ));
            StartCoroutine(Unfreeze());

            while(gameObject_List.Contains(carrots))
            {
                  yield return null;
            }

            StartCoroutine(Bunny_Takes_A_Bite());
    }

    // Mouse Over Carrots Functions.
public void Carrot_Left_MO()
		{
			//Carrot_Left_Glow.SetActive(true); // Enable glow carrot sprite.
			StartCoroutine(Lerp_Color_Alpha(Carrot_Left_Glow_SR, color_Zero, color_Max, .5f, 0f));  // lerp glow carrot alpha to max.
			 
			left_Bunnies_Animator.speed = 2f;
      left_Bunnies_Animator.Play("Base Layer.good_Bunny_03_MO",-1 , 0);  // Make bunny twitch. 
		}


public void Carrot_Left_ME()
		{				
			StartCoroutine(Lerp_Color_Alpha(Carrot_Left_Glow_SR, color_Max, color_Zero, .5f, 0f));  // lerp glow carrot alpha to zero.
			
		}


public void Carrot_Right_MO()
		{
			//Carrot_Left_Glow.SetActive(true); // Enable glow carrot sprite.
			StartCoroutine(Lerp_Color_Alpha(Carrot_Bitten_Glow_SR, color_Zero, color_Max, .5f, 0f));  // lerp glow carrot alpha to max.
			 
			//.speed = 2f;
     // left_Bunnies_Animator.Play("Base Layer.good_Bunny_03_MO",-1 , 0);  // Make bunny twitch. 
		}


public void Carrot_Right_ME()
		{				
			StartCoroutine(Lerp_Color_Alpha(Carrot_Bitten_Glow_SR, color_Max, color_Zero, .5f, 0f));  // lerp glow carrot alpha to zero.
			
		}


void Turn_Off_Carrot()
			{
				carrot_Right.SetActive(false);
			}


    IEnumerator Unfreeze()
    {
       yield return new WaitForSeconds( .1f );
         good_Bunny_03_Rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }




IEnumerator Bunny_Takes_A_Bite()
{
      Rotate_Object(good_Bunny_02_Rec, 0, 0, .1f, 1, .2f, 0) ;  //Rotate
			StartCoroutine(Lerp_Transform_Position(good_Bunny_02, good_Bunny3_Start_Pos, good_Bunny3_End_Pos, .2f, 0 ));
      Scale_Object(open_Mouth, zero, one,  .5f, 0 );
	//		Invoke("Turn_Off_Carrot", .5f);
 
 	// yield return new WaitForSeconds( .5f );

   while(rec_List.Contains(good_Bunny_02_Rec ) || gameObject_List.Contains(open_Mouth) )
   {
        yield return null;
   }

      carrot_Right.SetActive(false);

      Scale_Object(open_Mouth, one, zero, .2f, 0 );
			Rotate_Object(good_Bunny_02_Rec, 0, 0, 0f, 1, 1, 0)	;
			StartCoroutine(Lerp_Transform_Position(good_Bunny_02, good_Bunny3_End_Pos, good_Bunny3_Start_Pos, .5f, 0 ));

      Carrot_Bitten_Glow.SetActive(true);
}


// Base transform Functions.

    IEnumerator Lerp_Color_Alpha(SpriteRenderer sprite_Renderer, Color start_Color, Color end_Color,  float duration, float secs_To_Wait)
		{
			 yield return new WaitForSeconds(secs_To_Wait);  

			float start_Point = 0;

			 while(start_Point < duration)
			{
       // Debug.Log("Color is " + sprite_Renderer.material.color);
       // Debug.Log("lerp color is " + Carrot_Left_Glow_SR.color);
				sprite_Renderer.material.color = Color.Lerp( start_Color , end_Color ,  start_Point / duration) ;
               
				start_Point += Time.unscaledDeltaTime;
				yield return null ;
			}		
		}


IEnumerator Lerp_Transform_Position(GameObject object_To_Lerp, Vector3 start_Lerp_Pos, Vector3 end_Lerp_Pos, float duration, float wait_For_Sec )
        {
           gameObject_List.Add(object_To_Lerp);

                float time = 0f;
                yield return new WaitForSeconds( wait_For_Sec );
                
                while(time < duration)
                {
                    object_To_Lerp.transform.localPosition = Vector3.Lerp( start_Lerp_Pos, end_Lerp_Pos, time / duration );
                    time += Time.unscaledDeltaTime;
                    yield return null;
                }

                gameObject_List.Remove(object_To_Lerp);
        } 
        






public async Task Rotate_Object(RectTransform _object_Rec, float x, float y, float z, float w, float duration, int WFS)
{
  rec_List.Add(_object_Rec); // Adds object rectransform variable to list.

        await Task.Delay(WFS);

        float time = 0;

                    Quaternion rotation = new Quaternion(x, y, z, w);

                   Quaternion current = _object_Rec.localRotation;

                     while(time < duration)
                    {
                        _object_Rec.rotation =  Quaternion.Slerp(current, rotation, time * 3);

                        time = time + Time.deltaTime;

                        await Task.Yield();
                    }

          rec_List.Remove(_object_Rec);   // removes object rectransform variable to list.

          await Task.Yield();
}


  public async void Scale_Object(GameObject object_To_Scale, Vector3 start_Size, Vector3 end_Size , float duration, int _sec_2_Wait )
            {
                gameObject_List.Add(object_To_Scale);
                  
                await Task.Delay(_sec_2_Wait);
 
                float time = 0f;

                    while(time <= duration)
                    {
                        object_To_Scale.transform.localScale = Vector3.Lerp(start_Size, end_Size, time / duration );
                        time += Time.unscaledDeltaTime; 
                       await Task.Yield();
                    }   

                object_To_Scale.transform.localScale = end_Size;

                gameObject_List.Remove(object_To_Scale);

            }


}
