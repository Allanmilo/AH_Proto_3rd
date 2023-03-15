using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPuckDrop : MonoBehaviour
{
    public GameObject startingPuck;
    Vector2 puckPos;

    void Awake()
    {
        startingPuck.SetActive(false);
        puckPos = new Vector2(0f, -3f);

       //  PuckDrop();
    }

    void PuckDrop()
    {
        Instantiate(startingPuck, puckPos, Quaternion.identity);
    }
}
