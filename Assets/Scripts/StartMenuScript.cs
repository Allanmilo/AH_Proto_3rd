using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuScript : MonoBehaviour
{
     public void StartMenuOff()
    {
        this.gameObject.SetActive(false);
    }

     public void StartMenuOn()
    {
        this.gameObject.SetActive(true);
    }
}
