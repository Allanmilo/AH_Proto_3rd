using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    Collider2D playerCollider;
    public bool toggle;
    private Vector2 returnPos;
    //private Vector2 newTranPos;


    public Transform BoundaryHolder;
    Boundary playerBoundary;

    Vector2 mousePos;

    void Awake()
    {
        toggle = false;
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();

        playerBoundary = new Boundary(BoundaryHolder.GetChild(0).position.y,
                                      BoundaryHolder.GetChild(1).position.y,
                                      BoundaryHolder.GetChild(2).position.x,
                                      BoundaryHolder.GetChild(3).position.x);

        returnPos = new Vector2(0f, -5.5f);
        //newTranPos = rb.position + returnPos;
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
    
}
