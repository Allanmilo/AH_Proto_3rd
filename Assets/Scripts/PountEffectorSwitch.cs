using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PountEffectorSwitch : MonoBehaviour
{
    
    void Start()
    {
        this.gameObject.SetActive(false);
    }


    public void SwitchEffector()
    {
        this.gameObject.SetActive(true);
    }
}
