using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny_Left_Script : MonoBehaviour
{

    private Rigidbody2D Rb2D;

     RectTransform object_Rec;
	
	void Start()
	{
		Rb2D = GetComponent<Rigidbody2D>();

         object_Rec = this.gameObject.GetComponent<RectTransform>();

	}


void Update()
{
      if (Input.GetKeyUp(KeyCode.A))
                {
                  

                  StartCoroutine(Bouncy(object_Rec, 1f, .5f));
           
            

}

    void OnCollisionEnter2D(Collision2D collisionStuff)
    {
        if (collisionStuff.collider.tag == "Carrots" )
        {
            Rb2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            
        }
    }



    
void OnMouseOver()
    {

             // StartCoroutine(Move_Object_Bounce_03(object_Rec, Mathf.PI * 2, 2f, 0f, 1f, .5f, 0f, false));
        
    }


IEnumerator Bouncy(RectTransform _object_Rec, float Speed, float Amplitude)
    {
        

        // float y = 0;
        float time = 0;
        float x = _object_Rec.position.x;
         float y = _object_Rec.position.y;


                while (y >= 0)
                {
                    float angle = time * Time.deltaTime * Mathf.PI / Speed;
                    y = Amplitude * (Mathf.Sin(angle));

                     _object_Rec.position = new Vector3( x, y, 0);
                    time += 1f;

                    yield return null;
                }

        
       // yield return new WaitForSeconds(1);
		
        
    }

    IEnumerator Move_Object_Bounce_03(RectTransform _object_Rec, float cycle, float speed, float length_X, float length_Y, float duration, float WFS, bool switch_Bool)
        {
			yield return new WaitForSeconds(WFS);

         //   Move_Object_Bounce_Bool = false;

            float x = _object_Rec.position.x;
            float y = _object_Rec.position.y;

            float time = 0f;
            //float duration = 2f;
            //float length = .1f;

                    while(time < duration)
                    {
                        float yAxis = (Mathf.Sin(time * cycle) * speed) * length_Y;
                       // float yAxis = Mathf.PingPong (time * Time.deltaTime / 1f, length_Y) + y;
                        _object_Rec.position = new Vector3( x, yAxis, 0);

                       //  transform.position = Vector2.Lerp(Vector3_Starting_Position, Vector3_Ending_Position, time / duration );
                        time += Time.deltaTime;
                        yield return null;
                    }

           _object_Rec.position = new Vector3(x, y, 0);

          
             yield return null;

            //  Move_Object_Bounce_Bool = switch_Bool;
        }
}
}
