using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFireWorks02 : MonoBehaviour
{
     ParticleSystem particles;

    void Start()
    {
        
    } 

    
    public void FireWorks02()
    {
        particles = GetComponent<ParticleSystem>();
        particles.Play();
    }
}
