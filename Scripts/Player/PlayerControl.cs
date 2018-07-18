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
    private bool charging;
    private bool engineOn;
    private Fuel currentFuel;
    private ChargeDash myChargeDash;

    // Use this for initialization
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        engineOn = true;
        currentFuel = new Fuel(100);
        myChargeDash = new ChargeDash(c, myRigidBody, chargeMax, chargeFactor);
    }

    void Update() {

        if (engineOn)
        {
            myChargeDash.chargeInput(transform, currentFuel, chargeButton);
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