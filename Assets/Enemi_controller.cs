﻿using System;
using System.Threading;
using UnityEngine;

public class Enemi_controller : MonoBehaviour
{

    // speed is the rate at which the object will rotate
    public float speed, walkSpeed, dashSpeed;
    //private Vector3 pointShoot;


    private GameObject Gplayer;
    private Transform Player;

    public float MoveSpeed = 4;
    public float MaxDist = 10;
    public float MinDist = 1;
    public float AttackRange = 2.5f;

    //public Animator swordAnim;
    //public Animator shieldAnim;
   // public Animator bodyAnim;

   /* private bool isblocking = false;

    private bool isDash = false, isDashing = false;
    private float dashTime, waitTime;
    */

    void Start() {
        Gplayer = GameObject.FindWithTag("Player");
        if (Gplayer != null)
        {
            Player = Gplayer.GetComponent<Transform>();
        }

    }

    void FixedUpdate()
    {
        // LOOK AT PLAYER
        //---------------------------------------------------------------------------------------
        transform.LookAt(Player);


        // ------------------------------------------------------------------------------------
        // END LOOK TO MOUSE PART

        /*
        // DASH MOVEMENT START ------------------------------------------------------------------------  
        if (!isDash)
        {
            if (Input.GetKey(KeyCode.Space)) { speed = dashSpeed; isDashing = true; bodyAnim.SetTrigger("dash"); }
            if (isDashing)
            {
                dashTime += Time.deltaTime;
                if (dashTime >= 0.1)
                {
                    isDash = true;
                    isDashing = false;
                    speed = walkSpeed;
                    dashTime = 0;
                }
            }
        }
        else
        {
            if (isDash)
            {
                waitTime += Time.deltaTime;
                if (waitTime >= 5)
                {
                    isDash = false;
                    waitTime = 0;
                }
            }
        }
        // DASH END       -------------------------------------------------------------------------------------
        */
        //  MOVEMENT -------------------------------------------------------------------------------------
        if (Vector3.Distance(transform.position, Player.position) >= MinDist) {
            transform.position += transform.forward * speed * Time.deltaTime;
        }



        // ARROW MOVEMENT END ----------------------------------------------------------------------------------


            // ATACK ------------------------------------------------------------------------------------------------
           /* if(Vector3.Distance(transform.position, Player.position) <= AttackRange){
                swordAnim.SetTrigger("atk");
            }*/

          
            // END ATACK ---------------------------------------------------------------------------------------------


            // BLOCK --------------------------------------------------------------------------------------------------
            /*
            if (Input.GetKeyDown(KeyCode.F))
            {
                isblocking = true;
                if (isblocking)
                {
                    shieldAnim.SetTrigger("start_Block");
                    // {
                }
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                shieldAnim.SetTrigger("stop_block");
                //   isblocking = false;
                // }
            }

            */

            // END BLOCK ----------------------------------------------------------------------------------------------

    }
    /*void OnGUI()
     {
         GUILayout.BeginArea(new Rect(20, 20, 250, 250));
         GUILayout.Label("World position: " + pointShoot.ToString("F3"));
         GUILayout.Label("Character Position: " + transform.position.ToString("F3"));
         GUILayout.Label("Movement to: " + transform.forward.ToString("F3"));
         GUILayout.Label("Is Dash: " + isDash);
         GUILayout.Label("DashTime: " + dashTime);
         GUILayout.Label("Wait Time:" + waitTime);
         GUILayout.EndArea();


     }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Enemigo atacando " + other.name);

        }
    }
}
