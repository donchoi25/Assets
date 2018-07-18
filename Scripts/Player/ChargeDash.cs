using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeDash : BPlayer{

    private Camera c;
    private Rigidbody2D myRigidBody;
    private float chargeMax;
    private float chargeFactor;
    private float timer;
    private bool charging;
    private Transform transform;
    private Fuel currentFuel;
    private string chargeButton;

    public ChargeDash(Camera c, Rigidbody2D myRigidBody, float chargeMax, float chargeFactor, bool charging, Transform transform, Fuel currentFuel, string chargeButton)
    {
        this.c = c;
        this.myRigidBody = myRigidBody;
        this.chargeMax = chargeMax;
        this.chargeFactor = chargeFactor;
        this.charging = charging;
        this.transform = transform;
        this.currentFuel = currentFuel;
        this.chargeButton = chargeButton;
    }

    public void chargeDash()
    {
        Vector2 mouseDirection;
        float chargeDuration;

        //Get Fixed time
        chargeDuration = (Time.time - timer) / 0.4f;

        //Get mouse position and convert to onscreen position
        Vector2 p = c.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

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

    public void chargeInput()
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
}
