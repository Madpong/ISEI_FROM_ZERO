using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ene_ATK : MonoBehaviour, Ienemie
{

    public float currentHealth;
    public float maxHealth;
    public GameObject MainGameObject;
    public GameObject player;

    //SOUND --------------------------------------------
    public AudioSource source;
    public AudioClip sDie;
    //--------------------------------------------------

    void Start() {
        player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            source = player.GetComponent<AudioSource>();
        }
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
            source.PlayOneShot(sDie);
            Die();
            
        }
    }

    void Die() {

        Destroy(MainGameObject);
        

    }
   
}
