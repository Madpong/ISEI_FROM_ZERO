using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ene_ATK : MonoBehaviour, Ienemie
{

    public float currentHealth;
    public float maxHealth;
    public GameObject MainGameObject;

    void Start() {

        currentHealth = maxHealth;
    }

    public void PerformAttack(int amount)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die() {

        Destroy(MainGameObject);
    
    }
   
}
