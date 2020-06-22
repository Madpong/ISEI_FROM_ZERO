using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara_Mov : MonoBehaviour
{
    public Transform playerPos;
    public float x, y, z;


    private void FixedUpdate() {

        if (playerPos != null)
        {
            float xNorm = playerPos.position.x;
            xNorm -= x;
            transform.position = new Vector3(xNorm, transform.position.y, playerPos.position.z - z);
        }
    }
}
