using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Bunnies_Animation : MonoBehaviour
{
     private Animator left_Bunnies_Animator;
     public AnimationClip Hit_Bunny;

void Start()
{
  left_Bunnies_Animator = gameObject.GetComponent<Animator>(); 
  left_Bunnies_Animator.speed = 0f;
}
void Update()
{
     if (Input.GetKeyUp(KeyCode.W))
        {
          //  left_Bunnies_Animator.speed = 2f;
         //  left_Bunnies_Animator.Play("Bunny_Left",-1 , 0);
        }
}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Carrot_Left")
            {
                left_Bunnies_Animator.speed = 2f;
                left_Bunnies_Animator.Play("Base Layer.Bunny_Left",-1 , 0);
            }
    }

    
}
