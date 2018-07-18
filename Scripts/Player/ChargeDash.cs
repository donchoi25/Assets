using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeDash {

    private Camera c;
    private Rigidbody2D myRigidBody;
    private float chargeMax;
    private float chargeFactor;

    public ChargeDash(Camera c, Rigidbody2D myRigidBody, float chargeMax, float chargeFactor)
    {
        this.c = c;
        this.myRigidBody = myRigidBody;
        this.chargeMax = chargeMax;
        this.chargeFactor = chargeFactor;
    }

    public void chargeDash(float timer, Transform transform, Fuel currentFuel)
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

    public void chargeInput(Transform transform, Fuel currentFuel, string chargeButton)
    {
        float timer = 0;
        bool charging = false;

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
                chargeDash(timer, transform, currentFuel);
                charging = false;
            }
        }

        if (Input.GetButtonUp(chargeButton) && charging)
        {
            chargeDash(timer, transform, currentFuel);
            charging = false;
        }
    }
}
