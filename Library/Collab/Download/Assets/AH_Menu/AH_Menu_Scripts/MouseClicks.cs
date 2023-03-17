using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicks : MonoBehaviour
{
   // [SerializeField]
    GameObject Pan;
    PanMovement _panMovement;

    [SerializeField]
    GameObject[] _menuLetters;

    [SerializeField]
    Rigidbody2D[] _menuLettersRB;
    Vector2[] _lettersPos;

    Vector2[] _lettersRePos;

    float x;
    float y;



    Vector3 pos;
    //GameObject _menuRingFill;
    Color _ringFillAlpha;

    public float alpha;
   // SpriteRenderer objectColor;   

   

   void Start()
   {
       // _lettersRePos = new Vector2[] {RandomVector(), RandomVector(), RandomVector(), RandomVector()};

       _lettersPos = new Vector2[_menuLetters.Length];

        for(int i = 0; i < _menuLetters.Length; i++)
        {
            Vector2 pos = _menuLetters[i].transform.position;
            _lettersPos[i] = pos;
           
        }


       _ringFillAlpha = GetComponent<SpriteRenderer>().color;
      
      _ringFillAlpha.a = 0f;
      GetComponent<SpriteRenderer>().color = _ringFillAlpha;

       _lettersRePos = new Vector2[] {RandomVector(), RandomVector(), RandomVector(), RandomVector()};
      RandomMove();

    Pan = GameObject.FindGameObjectWithTag("Pan");
    _panMovement = Pan.GetComponent<PanMovement>();

   }


   

   void Update()
   {
       alpha = _ringFillAlpha.a;  
   }



    public void RandomMove()
    {
        for(int i = 0; i < _menuLettersRB.Length; i++)
            {
                Vector2 vel = _lettersRePos[i] ;
                _menuLettersRB[i].velocity = vel;
            }
    }




    public void ReAlign()
    {
        for(int i = 0; i < _menuLetters.Length; i++)
            {
                Vector2 pos = _lettersPos[i] ;
                _menuLetters[i].transform.position = pos;
            }
    }

    void OnMouseEnter()
    {
        
    // Sets the alpha from 0 to .2 on the circle inside the menu ring.
    _ringFillAlpha.a = .2f;
    GetComponent<SpriteRenderer>().color = _ringFillAlpha;
    
    
        for(int i = 0; i < _menuLetters.Length; i++)
            {
               _menuLetters[i].GetComponent<BoxCollider2D> ().enabled = false;
                _menuLetters[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero; 
              
             
              //  _menuLetters[i].transform.position = Vector2.Lerp(_menuLetters[i].transform.position, _lettersPos[i], 15 * Time.deltaTime );
              
           // _menuLetters[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero; 
                // _menuLetters[i].GetComponent<Rigidbody2D> ().isKinematic = false;
           }

    }

    void OnMouseOver()
    {
        for(int i = 0; i < _menuLetters.Length; i++) // 
            {
                // Turns off letters collider so they pass through easch other.
            //_menuLetters[i].GetComponent<BoxCollider2D>().enabled = false; 
              
              // Sets the velocity of letters to zero.
             // _menuLetters[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero; 
                // Positions letters to sau 'menu'.
          _menuLetters[i].transform.position = Vector2.Lerp(_menuLetters[i].transform.position, _lettersPos[i], 15 * Time.deltaTime );
           
                // _menuLetters[i].GetComponent<Rigidbody2D> ().isKinematic = false;
           }
        
    } 
    void OnMouseExit()
    {
        for(int i = 0; i < _menuLetters.Length; i++)
            {
              _menuLetters[i].GetComponent<BoxCollider2D> ().enabled = true;
            }

        _ringFillAlpha.a = 0f;
        GetComponent<SpriteRenderer>().color = _ringFillAlpha;

        RandomMove();
    }
    
    void OnMouseUp()
    {
        _ringFillAlpha.a = 0f;
         GetComponent<SpriteRenderer>().color = _ringFillAlpha;

         for(int i = 0; i < _menuLetters.Length; i++)
            {
              _menuLetters[i].GetComponent<BoxCollider2D> ().enabled = true;
            }

       _panMovement.restoreMenu();
       RandomMove();
    }


 private Vector2 RandomVector() 
     {
         x = Random.Range(-3f, 3f);
         y = Random.Range(-3f, 3f);
    
         return new Vector2(x, y);
     }
}