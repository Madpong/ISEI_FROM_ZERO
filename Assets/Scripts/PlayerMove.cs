using System;
using System.Threading;
using UnityEditor;
using UnityEngine;
 
public class PlayerMove : MonoBehaviour
{
    public Texture texture;
    // speed is the rate at which the object will rotate
    public float speed, walkSpeed, dashSpeed;
    private Vector3 pointShoot;
    public int currenthealth, maxHealth;
    
    public Animator swordAnim;
    public Animator shieldAnim;
    public Animator bodyAnim;

    private bool isblocking = false;

    private bool isDash = false, isDashing = false;
    private float dashTime, waitTime;

    void Start() {

        currenthealth = maxHealth;
    }
   
    void FixedUpdate()
    {
        // LOOK TO MOUSE PART
        //---------------------------------------------------------------------------------------
        // Generate a plane that intersects the transform's position with an upwards normal.
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determine the point where the cursor ray intersects the plane.
        // This will be the point that the object must look towards to be looking at the mouse.
        // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
        //   then find the point along that ray that meets that distance.  This will be the point
        //   to look at.
        float hitdist = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 targetPoint = ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            //pointShoot = targetPoint;
            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
        // ------------------------------------------------------------------------------------
        // END LOOK TO MOUSE PART

        //bodyAnim.SetTrigger("dash");
        // DASH MOVEMENT START ------------------------------------------------------------------------  
        if (!isDash) {
            if (Input.GetKey(KeyCode.Space)) { speed = dashSpeed; isDashing = true;  }
            if (isDashing) {
                dashTime += Time.deltaTime;
                if (dashTime >= 0.1) {
                    isDash = true;
                    isDashing = false;
                    speed = walkSpeed;
                    dashTime = 0;
                }
            }
        }
        else {
            if (isDash) { 
                waitTime += Time.deltaTime;
                if(waitTime >= 5) {
                    isDash = false;
                    waitTime = 0;
                }
            }
        }
        // DASH END       -------------------------------------------------------------------------------------

        // ARROW MOVEMENT -------------------------------------------------------------------------------------
        if (Input.GetKey(KeyCode.W)) { transform.position += Vector3.forward * speed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.S)) { transform.position += Vector3.back * speed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.A)) { transform.position += Vector3.left * speed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.D)) { transform.position += Vector3.right * speed * Time.deltaTime; }
        // ARROW MOVEMENT END ----------------------------------------------------------------------------------


        // ATACK ------------------------------------------------------------------------------------------------

        if (Input.GetKeyDown(KeyCode.Mouse0) && !isblocking)
        {
            swordAnim.SetTrigger("ATK");
        }


        // END ATACK ---------------------------------------------------------------------------------------------
    

        // BLOCK --------------------------------------------------------------------------------------------------

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
            isblocking = false;
            // }
        }



        // END BLOCK ----------------------------------------------------------------------------------------------

        // HEAL CHECKER --------------------------------------------------------------------------------------------

        if (currenthealth <= 0) {

            Die();
        
        }
        // EN HEAL CHECKER ------------------------------------------------------------------------------------------

    }

    void Die() {
        Destroy(gameObject);
    
    }
   void OnGUI()
    {
        
        
        GUILayout.BeginArea(new Rect(20, Screen.height - 150, 250, 250));

        //GUILayout.Label("Mouse Position: " + Input.mousePosition.ToString("F3"));
        //GUILayout.Label("Character Position: " + transform.position.ToString("F3"));
        // GUILayout.Label("Movement to: " + transform.forward.ToString("F3"));
        //GUILayout.Label("Is Dash: " + isDash);
        GUILayout.Label("Screen Height : " + Screen.height);
        GUILayout.Label("Time: " + Time.fixedTime.ToString("F2"));
        GUILayout.Label("Dash CD:" + waitTime);
        GUILayout.Label("Health: " + currenthealth);
        GUILayout.EndArea();


       
    }
}
