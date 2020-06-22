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
            Vector2 healpos = new Vector2(transform.position.x, transform.position.z);
            Vector2 playerpos = new Vector2(tPlayer.position.x, tPlayer.position.z);
            Debug.Log(Vector2.Distance(healpos, playerpos));
            if (Vector2.Distance(healpos, playerpos) <= healDistance)
            {
                player.GetComponent<PlayerMove>().currenthealth += HealPower;
                Destroy(gameObject);
            }
            //Si estamos cerca le subo la vida!
        }
    }
}
