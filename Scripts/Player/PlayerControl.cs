using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*EDITS
 * Create terrain that kills character if going too fast, create a restart if killed
 * Add simple animation/sprite for ig plane
 * sight line that show predicted path of charge move
 * RESTRUCTURE CODE WITH SCRIPTS WITH ONE SPECIFIC FUNCTION
 * */

public class PlayerControl : MonoBehaviour {
    
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
    private EngineButton myEngineButton;

    // Use this for initialization
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        engineOn = true;
        currentFuel = new Fuel(100);
        myChargeDash = new ChargeDash(c, myRigidBody, chargeMax, chargeFactor, charging, transform, currentFuel, chargeButton);
        myEngineButton = new EngineButton(engineOn, myRigidBody);
    }

    void Update() {

        if (engineOn)
        {
            myChargeDash.chargeInput();
            myChargeDash.basicControl(myRigidBody, transform, maxSpeed, moveSpeed);
        }

        if (Input.GetButtonDown("Engine Button"))
        {
            engineOn = myEngineButton.engineToggle(engineOn);
        }
        
        currentSpeed = myRigidBody.velocity.magnitude;
        Debug.Log(engineOn);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        myChargeDash.Kill(currentSpeed, deathSpeed);
    }    
}