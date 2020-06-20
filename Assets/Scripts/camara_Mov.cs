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
            transform.position = new Vector3(playerPos.position.x, transform.position.y, playerPos.position.z - z);
        }
    }
}
