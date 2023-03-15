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
        
        StartCoroutine(EdgeGlow());

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

         
    }

    public void ResetGlow()
    {
        StartCoroutine(EdgeGlow());
    }
    
    IEnumerator EdgeGlow()
                {
                    Color32 color01 = puckEdge.GetComponent<Renderer>().material.color;
	                color01 = new Color32(255, 204, 204, 255);

		            Color32 color02 = puckEdge.GetComponent<Renderer>().material.color;
	                color02 = new Color32(153, 0, 0, 255);

                    while(true)
                    {
                    newColor = Color.Lerp(color01, color02, Mathf.PingPong(frequency * Time.time, 1));
                    puckEdge.GetComponent<Renderer>().material.color = newColor;
                    yield return null;
                    }
                        
            
                }   
}
