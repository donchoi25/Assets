using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*EDITS
 * Create terrain that kills character if going too fast, create a restart if killed
 * Add simple animation/sprite for ig plane
 * sight line that show predicted path of charge move
 * RESTRUCTURE CODE WITH SCRIPTS WITH ONE SPECIFIC FUNCTION
 * */

public class PlayerControl : MonoBehaviour, IKillable {
    
    //this is a test for sure
    public Camera c;
    public string chargeButton;
    public float chargeMax;
    public float chargeFactor;
    public float moveSpeed;
    public float maxSpeed;
    public float deathSpeed;

    private float currentSpeed;
    private Rigidbody2D myRigidBody;
    private float timer;
    private Vector2 mousePosition;
    private bool charging;
    private bool engineOn;
    private Fuel currentFuel;


    // Use this for initialization
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        engineOn = true;
        currentFuel = new Fuel(100);
    }

    void Update() {

        //Debug.Log(currentFuel.getFuel());
        if (engineOn)
        {
            chargeInput();
            BasicControl();
        }
        if (Input.GetButtonDown("Engine Button"))
        {
            engineButton();
        }

        currentSpeed = myRigidBody.velocity.magnitude;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        Kill(currentSpeed);
    }

    //adds force depending on arrow inputs, also caps movespeed during arrow movements
    void BasicControl()
    {

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            myRigidBody.AddForce(transform.right * Input.GetAxisRaw("Horizontal") * moveSpeed);
            MovespeedCap.checkSpeed(myRigidBody, maxSpeed);
        }

        if (Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myRigidBody.AddForce(transform.up * Input.GetAxisRaw("Vertical") * moveSpeed);
            MovespeedCap.checkSpeed(myRigidBody, maxSpeed);
        }

    }

    /*handles mouse down, hold, and release for charge dash. 
     * On mouse down, start timer and say player is charging, slow down time
     * On hold, execute charge dash if charging and goes over charge max time
     * On release, execute charge dash
     */
    void chargeInput()
    {
        if (Input.GetButtonDown(chargeButton))
        {
            //start timer
            timer = Time.time;

            charging = true;

            Time.timeScale = .4f;
        }

        if (Input.GetButton(chargeButton) && charging)
        {
            if ((Time.time - timer) / 0.4f > chargeMax)
            {
                chargeDash();
                charging = false;
            }
        }

        if (Input.GetButtonUp(chargeButton) && charging)
        {
            chargeDash();
            charging = false;
        }

    }

    //dash in direction of mouse and duration charge was held
    void chargeDash()
    {
        Vector2 mouseDirection;
        float chargeDuration;

        //Get Fixed time
        chargeDuration = (Time.time - timer) / 0.4f;

        //Get mouse position and convert to onscreen position
        mousePosition = Input.mousePosition;
        Vector2 p = c.ScreenToWorldPoint(new Vector2(mousePosition.x, mousePosition.y));

        //direction from object to mouse cursor
        mouseDirection = new Vector2(p.x - transform.position.x, p.y - transform.position.y).normalized;

        //if charge duration exceeds chargeMax, charge duration equals charge Max
        if (chargeDuration > chargeMax)
        {
            chargeDuration = chargeMax;
        }

        //takes time duration and determines distance and direction based on hold duration
        myRigidBody.velocity = mouseDirection * chargeDuration * chargeFactor;

        Time.timeScale = 1f;

        currentFuel.decreaseFuel(25);
    }

    //engine button that toggles on and off engine, increases gravity when engine is off
    void engineButton()
    {
        if(engineOn == false)
        {
            myRigidBody.gravityScale = 0.2f;
            engineOn = true;
        }
        else
        {
            myRigidBody.gravityScale = .8f;
            engineOn = false;
        }
    }

    public void Kill(float velocity)
    {
        if (velocity > deathSpeed)
        {
            Debug.Log("You have died");
        }
    }
}