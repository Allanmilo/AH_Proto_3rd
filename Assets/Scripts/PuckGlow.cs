using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckGlow : MonoBehaviour
{
    public bool _activeSelf;
    public bool _activeInHierarchy;
    [SerializeField]
    private GameObject _puck;
    [SerializeField]
    private Rigidbody2D rb2DPuck;

    private Transform puckCenter;
    private Transform puckEdge;
    private Color32 newColor;

    private float frequency;

    private Vector3 mLastPosition;
    public float speed;
    public float maxSpeed;
    ParticleSystem ps;

    GameObject _AHScriptManager;
    AHScriptManager _AHManager;

    Color32 color01;
	Color32 color02;

    //int moveForward = 0;

    void Start()
    {
        _AHScriptManager = GameObject.FindGameObjectWithTag("AHManager");
		_AHManager =  _AHScriptManager.GetComponent<AHScriptManager>();

        rb2DPuck = GetComponent<Rigidbody2D>();
        ps = GetComponent<ParticleSystem>();
       puckCenter = this.gameObject.transform.GetChild(0);
       puckEdge = this.gameObject.transform.GetChild(1);

        frequency = 0.7f;   

        

         
    }

    void Update()
    {
        maxSpeed = _AHManager._maxPuckSpeed;
        
        // StartCoroutine(EdgeGlow());

         speed = (transform.position - this.mLastPosition).magnitude / Time.deltaTime;
         this.mLastPosition = transform.position;

         if(speed > 100f)
         {
              ps.Play();
         }

         else
         {
              ps.Stop();
         }

          if(speed > maxSpeed)
          {
            rb2DPuck.velocity = Vector3.ClampMagnitude(rb2DPuck.velocity, maxSpeed);
          }

        // Debug.Log(rb2DPuck.velocity);
    }

    public void ResetGlow()
    {
      //  StartCoroutine(EdgeGlow());
    }
    
    IEnumerator EdgeGlow()
                {
                    Color32 color11 = puckEdge.GetComponent<Renderer>().material.color;
	                color11 = new Color32(255, 204, 204, 255);

		            Color32 color02 = puckEdge.GetComponent<Renderer>().material.color;
	                color02 = new Color32(153, 0, 0, 255);

                    while(true)
                    {
                    newColor = Color.Lerp(color11, color02, Mathf.PingPong(frequency * Time.time, 1));
                    puckEdge.GetComponent<Renderer>().material.color = newColor;
                    yield return null;
                    }
                }   


    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
         //    StopAllCoroutines();
         //   _AHManager.color_Pulse_Bool = false;
        //    _AHManager.your_Paddle_SR.sprite = _AHManager.paddle_Fight_Sprites[Random.Range(0, 3)];
        //    color01 = new Color32(250, 140, 140, 255);
		//	color02 = new Color32(255, 110, 110, 255);
		//	StartCoroutine(_AHManager.Color_Pulse(_AHManager.your_Paddle_SR, color01, color02, 1));
		//_AHManager.your_Paddle_SR.color = Color.white;

            
            if(_AHManager.moveForward < 3)
            {
                 _AHManager.moveForward += 1;
		    }
        }

        if (col.gameObject.tag == "Carrot_Missile")
        {
            
            rb2DPuck.velocity = rb2DPuck.velocity * 100;
             _AHManager.carrot_Bullet_List.Remove(1);
        }
	}
}
