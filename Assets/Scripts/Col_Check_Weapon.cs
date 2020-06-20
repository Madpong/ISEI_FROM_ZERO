using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Check_Weapon : MonoBehaviour
{

    public int power;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Player Hit: " + other.name);
            // To Do
            other.GetComponent<Ienemie>().TakeDamage(power);
            //Do Damage 
            //other.GetComponent<Ienemy>().TakeDamaga(weaponDmg);
            //Block Damge if we are in Block State

            // Parry.... hehe
        }
    }
}
