using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_heal : MonoBehaviour
{

    //busco al player
    public GameObject player;
    private Transform tPlayer;
    // Start is called before the first frame update

    public float healDistance;
    public int HealPower;
    void Start()
    {
        // lo asigno
        player = GameObject.FindGameObjectWithTag("Player");
        tPlayer = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            //Comparo si estamos cerca 
            if (Vector3.Distance(transform.position, tPlayer.position) <= healDistance)
            {
                player.GetComponent<PlayerMove>().currenthealth += HealPower;
                Destroy(gameObject);
            }
            //Si estamos cerca le subo la vida!
        }
    }
}
