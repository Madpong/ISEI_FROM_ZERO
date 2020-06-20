using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ene_Atq : MonoBehaviour
{

    public float power;
  
    void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Player")
       // {
            Debug.Log("Enemigo atacando  a: " + other.name);

       // }
    }
}
