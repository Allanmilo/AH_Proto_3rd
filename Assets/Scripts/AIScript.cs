
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    private Rigidbody2D rbAI;

    private Vector2 startingPosition;
    private Vector2 targetPosition;
    public float MaxMovementSpeed;

    public Transform AIBoundaryHolder;
    private Boundary AIBoundary;

    private Rigidbody2D puck;

    [SerializeField]
    private GameObject _puck;

    public Transform PuckBoundaryHolder;
    private Boundary puckBoundary;

	public float paddleDelay;
    public bool oppPuck;

    public bool _hasChanged;
    public bool _activeSelf;
    public bool _activeInHierarchy;

    private float ratex = .5f;
    private float ratey = 3.67f;
    private Vector3 paddlePos;

    GameObject _AHScriptManager;
    AHScriptManager _AHManager;

    public GameObject carrot;
	public RectTransform carrotPos;

    GameObject mopseys_Visit;

    void Start()
    {
        _AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
		_AHManager =  _AHScriptManager.GetComponent<AHScriptManager>();

        mopseys_Visit = GameObject.FindGameObjectWithTag("Mopseys_Visit");

        paddlePos = transform.position;

        rbAI = GetComponent<Rigidbody2D>();
        startingPosition = rbAI.position;

        AIBoundary = new Boundary(AIBoundaryHolder.GetChild(0).position.y,
                                  AIBoundaryHolder.GetChild(1).position.y,
                                  AIBoundaryHolder.GetChild(2).position.x,
                                  AIBoundaryHolder.GetChild(3).position.x);

        puckBoundary = new Boundary(PuckBoundaryHolder.GetChild(0).position.y,
                                    PuckBoundaryHolder.GetChild(1).position.y,
                                    PuckBoundaryHolder.GetChild(2).position.x,
                                    PuckBoundaryHolder.GetChild(3).position.x);
                          
    }

   

    void Update()
    {
        MaxMovementSpeed = _AHManager._maxAISpeed;

        float movementSpeed = 0f;
        
        
        if(_puck.activeSelf)
        {
            puck = GameObject.FindGameObjectWithTag("Puck").GetComponent<Rigidbody2D>();
        
            if(!_puck.transform.hasChanged && puck.position.y < puckBoundary.Down)
            {
                Pace();
            }

            if (oppPuck)
            {
                StartCoroutine(Hesitate());
            }

            if (!oppPuck)
            {

                if (puck.position.y < puckBoundary.Down)
                {
                    Tracking();
                }

                if (puck.position.y > puckBoundary.Down && startingPosition.y > puck.position.y)
                {
                    FrontAttack();
                }

                if (puck.position.y > puckBoundary.Down && startingPosition.y < puck.position.y && startingPosition.x > puck.position.x)
                {
                    RightAttack();
                }

                if (puck.position.y > puckBoundary.Down && startingPosition.y < puck.position.y && startingPosition.x < puck.position.x)
                {
                    LeftAttack();
                }  

            
        }
        
        rbAI.MovePosition(Vector2.MoveTowards(rbAI.position, targetPosition, movementSpeed * Time.fixedDeltaTime));
    
        void Tracking()
        {
            movementSpeed = MaxMovementSpeed * Random.Range(0.01f, 0.2f);
            targetPosition = new Vector2(Mathf.Clamp(puck.position.x,
                                                     AIBoundary.Left,
                                                     AIBoundary.Right),
                                                     startingPosition.y);
        }
    
        void FrontAttack()
        {
			
            movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
            targetPosition = new Vector2(Mathf.Clamp(puck.position.x, AIBoundary.Left, AIBoundary.Right),
                                         Mathf.Clamp(puck.position.y, AIBoundary.Down, AIBoundary.Up));
        }

        void RightAttack()
        {
            movementSpeed = Random.Range(MaxMovementSpeed * .7f, MaxMovementSpeed);
            targetPosition = new Vector2(Mathf.Clamp(puck.position.x + 1, AIBoundary.Left, AIBoundary.Right),
                                         Mathf.Clamp(puck.position.y + 1, AIBoundary.Down, AIBoundary.Up));
        }

        void LeftAttack()
        {
            movementSpeed = Random.Range(MaxMovementSpeed * .7f, MaxMovementSpeed);
            targetPosition = new Vector2(Mathf.Clamp(puck.position.x - 1, AIBoundary.Left, AIBoundary.Right),
                                         Mathf.Clamp(puck.position.y + 1, AIBoundary.Down, AIBoundary.Up));

        }

        }
        
        
        else
        {
           Pace();
        }

    }




	void OnCollisionEnter2D(Collision2D colPuck)
        {
            if (colPuck.gameObject.tag == "Puck")
            {
                
            oppPuck = true;

            if(_AHManager.character == mopseys_Visit)
				{
					if(_AHManager.diff_Level == 1)
					{
						Invoke("Shoot_Carrot", 1);	
					}

                    if(_AHManager.diff_Level == 2)
					{
						Invoke("Shoot_Carrot", 1);	
					}
	
					if(_AHManager.diff_Level == 3)
					{
						Invoke("Shoot_Carrot", 1);
						Invoke("Shoot_Carrot", 2);
					}
				}
               
            }
        }

    IEnumerator Hesitate()
    {
        yield return new WaitForSeconds(paddleDelay);
        oppPuck = false;
    }

public void Pace()
         {
            //float sine = Mathf.Sin(Time.time * .5f);
            float cosine = Mathf.Cos(Time.time * .5f);
            
            transform.position = paddlePos + new Vector3(Mathf.PingPong(Time.time * ratex, 1f), Mathf.Cos(Time.time * ratey) * .03f, transform.position.z);
        }


    public void Shoot_Carrot()
    {
        Instantiate(carrot, carrotPos.position, Quaternion.identity);;
    }

}
