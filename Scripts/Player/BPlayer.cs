using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPlayer {

    public void basicControl(Rigidbody2D myRigidBody, Transform transform, float maxSpeed, float moveSpeed)
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

    public void Kill(float velocity, float deathSpeed)
    {
        if (velocity > deathSpeed)
        {
            Debug.Log("You have died");
        }
    }
}
