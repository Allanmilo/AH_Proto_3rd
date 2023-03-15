using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Mat : MonoBehaviour
{

     [SerializeField]  Material bad_Arua;

     void Update()
     {
          if (Input.GetKeyDown(KeyCode.Space))
        {
           bad_Arua.color = new Color(1, 1, 1, 1);
           
           // Fade_In_Bad_Arua();       
        }
     }
    public void Fade_In_Bad_Arua()
{

        StartCoroutine(fadeOut());

}


        IEnumerator fadeOut()
        {
            float counter = 0;
            float duration = 1;
            Color mat_Color = bad_Arua.color;

            while (counter < duration)
            {
                counter += Time.deltaTime;
               
                float alpha = Mathf.Lerp(0, 1, counter / duration);
                Debug.Log(alpha);

                //Change alpha only
                bad_Arua.color = new Color(mat_Color.r, mat_Color.g, mat_Color.b, alpha);
                Debug.Log("Color is " + bad_Arua.color);
                Debug.Log("mat is " + bad_Arua);
                //Wait for a frame
                yield return null;
            }
        }
}
