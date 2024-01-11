using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot_Weapons : MonoBehaviour
{
    	// All in one script.
GameObject _AHScriptManager;
AHScriptManager _AHManager;

public GameObject carrot_Explosion;

 RectTransform carrot_Pos;

ParticleSystem ps;
	
public GameObject player_Paddle;
public Transform player_Paddle_Rect;
public Rigidbody2D carrot_RB;

public Vector2 force; // controls speed of carrot.
public  float speed; // controls speed of carrot.
public float rotation_Speed;



void Start()
{
	 

	_AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
	_AHManager =  _AHScriptManager.GetComponent<AHScriptManager>();

	carrot_RB = GetComponent<Rigidbody2D>();
	carrot_Pos = GetComponent<RectTransform>();
	player_Paddle = GameObject.FindGameObjectWithTag("Player");
    player_Paddle_Rect = player_Paddle.GetComponent<Transform>();

	ps = GetComponent<ParticleSystem>();

		if(_AHManager.diff_Level == 1)
		{
			force = new Vector2(9, 9); // controls speed of carrot.
			Carrot_Bullet();
		}
		
		if(_AHManager.diff_Level == 2)
		{
			speed = 9; // controls speed of carrot.
			rotation_Speed = 2;
			StartCoroutine(Carrot_Missile());
		}
		
		if(_AHManager.diff_Level == 3)
		{
			speed = 3; // controls speed of carrot.
			rotation_Speed = 3;
			StartCoroutine(Carrot_Missile());
		}

		// _AHManager.carrot_Bullet_List.Add(1);
}
	
	
	void OnCollisionEnter2D(Collision2D colPuck)
        {
            if (colPuck.gameObject.tag != "Opponent")
            
		Instantiate(carrot_Explosion, carrot_Pos.position, Quaternion.identity);

               
		 _AHManager.carrot_Bullet_List.Remove(1);
		 
           Destroy(gameObject);

					if(_AHManager.diff_Level == 1)
					{
						Debug.Log("Level is " + _AHManager.diff_Level);
					}
                    if(_AHManager.diff_Level == 2)
					{	
							Debug.Log("Level is " + _AHManager.diff_Level);
					}
	
					if(_AHManager.diff_Level == 3)
					{
						Debug.Log("Level is " + _AHManager.diff_Level);
					}
				
               
            
        }

	// shoots carrot to location player was at when carrot spawned.
	public void Carrot_Bullet()
	{
		// player position minus carrot position.
		Vector3 direction = player_Paddle_Rect.position - transform.position;
		
		//Velocity of carrot.
		carrot_RB.velocity = new Vector2(direction.x, direction.y).normalized * force;
		
		float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg; // Mathf.Rad2Deg converts number to degrees?
		transform.rotation = Quaternion.Euler(0, 0, rotation + 270); //  turned to point at player
	}
		
	
	
	
	
	IEnumerator Carrot_Missile()
{	
	while(true)
	{
		// player position minus carrot position.
		Vector3 direction = player_Paddle.transform.position - transform.position;
		direction.Normalize(); // makes sure direction is not zero?
		
		float rotationAmount = Vector3.Cross(direction, transform.up).z;
		
		//Velocity of carrot.
		carrot_RB.velocity = transform.up * speed;
		// speed of rotation.
		carrot_RB.angularVelocity = -rotationAmount * rotation_Speed;
			yield return null;
	}
}
}
