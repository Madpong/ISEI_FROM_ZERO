using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_heal : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform [] spawPoints;
    public GameObject  GHeal;
    // tiempo entre Spawn Heal

    private bool canSpawn;
    public float HealCD, TimetoWait;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            int random = Random.Range(0, 2);
            GameObject a = Instantiate(GHeal, spawPoints[2].position, Quaternion.identity);
            canSpawn = false;
        }
        else {
            HealCD += Time.deltaTime;
            if(HealCD >= TimetoWait)
            {
                canSpawn = true;
                HealCD = 0;
            }
        }
    }
}
