using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ene_ATK : MonoBehaviour, Ienemie
{

    public float health, currentHealth, power, toughness;
    public float maxHealth;
    public GameObject MainGameObject;

    void Start() {

        currentHealth = maxHealth;
    }

    public void PerformAttack()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (amount <= 0)
        {
            Die();
        }
    }

    void Die() {

        Destroy(gameObject);
    
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Enemigo atacando " + other.name);

        }
    }
}
