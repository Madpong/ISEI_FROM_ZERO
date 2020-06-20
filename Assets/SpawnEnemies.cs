using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemy;

    public float reSpawnTime = 0, waitTime = 10;
    public bool canSpawn = false;

    // Time to Spawn

    //// Start is called before the first frame update
    void Start()
    {
        //Cargo mi prefav aqui
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            SpawnEnemy();
            canSpawn = false;
        } else
        {
            reSpawnTime += Time.deltaTime;
            if(reSpawnTime >= waitTime)
            {
                canSpawn = true;
                reSpawnTime = 0;
            }
        }
        //si puedo espan
        // inicio my enemigo en la posicion de este spanw point

    }
    void SpawnEnemy() {
        GameObject a = Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
