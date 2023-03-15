using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{
    private Rigidbody2D rbPuck;
    public float maxPuckSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rbPuck = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbPuck.velocity = Vector2.ClampMagnitude(rbPuck.velocity, maxPuckSpeed);
    }
}
