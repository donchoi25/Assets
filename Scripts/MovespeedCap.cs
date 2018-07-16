using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovespeedCap : MonoBehaviour {

	public static void checkSpeed(Rigidbody2D myRigidBody, float maxSpeed)
    {
        if (myRigidBody.velocity.magnitude > maxSpeed)
        {
            myRigidBody.velocity = myRigidBody.velocity.normalized * maxSpeed;
        }
    }
}