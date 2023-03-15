using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part_Drop_Col : MonoBehaviour
{
    public ParticleSystem part;

    public List<ParticleCollisionEvent> collisionEvents;

    //public RectTransform stars_Paddle;

    public GameObject splash;

    void Start()
    {
        //part = GetComponent<ParticleSystem>();

       //splash = GameObject.FindGameObjectWithTag("Splash");

        collisionEvents = new List<ParticleCollisionEvent>();

        
    }
    
    void OnParticleCollision(GameObject other)
    {
         if (collisionEvents == null) 
		{
			return;
		}
        
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        int i = 0;

        while (i < numCollisionEvents)
        {
                Vector3 pos = collisionEvents[i].intersection;
                Vector3 newPos = pos + new Vector3(0, -.5f, 0);
               // stars_Paddle.position = pos;
                i++;
                Instantiate(splash, newPos, Quaternion.identity);
        }    
    }

}

