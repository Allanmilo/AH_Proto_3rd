using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFireWorks01 : MonoBehaviour
{
   ParticleSystem particles;

    void Start()
    {
        //particles = GetComponent<ParticleSystem>();
    } 

    
    public void FireWorks01()
    {
        particles = GetComponent<ParticleSystem>();
        particles.Play();
    }
}
