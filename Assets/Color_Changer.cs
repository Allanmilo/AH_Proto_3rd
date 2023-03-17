using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Changer : MonoBehaviour
{
    // special effect for star's angry background.
    [SerializeField] Transform blure_oval01;
    [SerializeField] Transform blure_oval02;
    [SerializeField] Vector3 _rotation;  
    [SerializeField] float _speed;

        void Update()
        {
            blure_oval01.Rotate( _rotation * _speed * Time.deltaTime);
            blure_oval02.Rotate( _rotation * _speed * Time.deltaTime);
        }


}
