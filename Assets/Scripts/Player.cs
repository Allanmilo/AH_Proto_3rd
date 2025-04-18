using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    Collider2D playerCollider;

    Transform trans_ThisGameObject;
    public bool toggle;
    private Vector2 returnPos;
    //private Vector2 newTranPos;


    public Transform BoundaryHolder;
    Boundary playerBoundary;

    Vector2 mousePos;

    GameObject _AHScriptManager;
    AHScriptManager _AHManager;

    //Color32 color_Start;

   // Color32 color_End;

    public float timing;

    [SerializeField]float speed;

     [SerializeField] Color color_Start;
		 [SerializeField] Color	color_End;

Vector3 paddle_Scale;

public float scale_adjust;

Vector3 small_Scale;

    void Awake() 

    {
        toggle = false;
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        trans_ThisGameObject = GetComponent<Transform>();

        playerBoundary = new Boundary(BoundaryHolder.GetChild(0).position.y,
                                      BoundaryHolder.GetChild(1).position.y,
                                      BoundaryHolder.GetChild(2).position.x,
                                      BoundaryHolder.GetChild(3).position.x);

        returnPos = new Vector2(0f, -5.5f);
        //newTranPos = rb.position + returnPos;

        _AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
		_AHManager =  _AHScriptManager.GetComponent<AHScriptManager>();

        speed = 1;

        _AHManager.float_Pulse = 0.284f;
        paddle_Scale = trans_ThisGameObject.localScale;

        small_Scale = new Vector3(scale_adjust, scale_adjust, 0);
    }

    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

         if (toggle)
            {

                 mousePos = new Vector2(Mathf.Clamp(mousePos.x, playerBoundary.Left, playerBoundary.Right),
                                                        Mathf.Clamp(mousePos.y, playerBoundary.Down, playerBoundary.Up)) ;
                  
                    Cursor.visible=false;
                    Cursor.lockState = CursorLockMode.Confined;
                    Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x, playerBoundary.Left, playerBoundary.Right),
                                                        Mathf.Clamp(mousePos.y, playerBoundary.Down, playerBoundary.Up)) ;
                    rb.MovePosition(clampedMousePos);
            }

            if(!toggle)
            {   
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible=true;
                rb.MovePosition(returnPos);
                
            }
    }
    void Update()
    {
        

        

            if (Input.GetMouseButtonUp(0))
            {
                if   (playerCollider.OverlapPoint(mousePos))
                {
                    toggle = !toggle;
                }

                /*
                else
                {
                    toggle = false;
                }
                */
            }

           

           
        
    }
    
     void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Puck")
        {
           // color_Start = _AHManager.your_Paddle_SR.color;
             _AHManager.stop_Routines();
          //  _AHManager.stop_Routine = false;
            _AHManager.your_Paddle_SR.sprite = _AHManager.paddle_Fight_Sprites[Random.Range(0, 3)];
        //     color_Start = new Color(.5f, 0, .1f, 1);
		//	color_End = new Color(1, 0, .1f, 1);
			_AHManager.Start_Color_Pulse(_AHManager.your_Paddle_SR, color_Start, color_End, timing, speed);
		//_AHManager.your_Paddle_SR.color = Color.white;
        }

        if(col.gameObject.tag == "Carrot_Missile")
        {
             
            StartCoroutine(Scale_Paddle());
            _AHManager.Shake_PP();
        }
	}

    IEnumerator Scale_Paddle()
    {
        _AHManager.gameObject_List.Clear();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

            _AHManager.Scale_Object(this.gameObject, paddle_Scale, small_Scale, .3f, 0);
           
                    while(_AHManager.gameObject_List.Count > 0 )
                    {
                         yield return null;
                    }

           _AHManager.Scale_Object(this.gameObject, small_Scale, paddle_Scale, .3f, 0);

                  while(_AHManager.gameObject_List.Count > 0  )
                    {
                         yield return null;
                    } 

                    rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY; 
                    rb.constraints &= ~RigidbodyConstraints2D.FreezePositionX; 
    }
}
