using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMidGame : MonoBehaviour
{
    public void MidGameMenuOff()
    {
        this.gameObject.SetActive(false);
    }

     public void MidGameMenuOn()
    {
        this.gameObject.SetActive(true);
    }
}
