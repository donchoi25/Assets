using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineButton : BPlayer {

    private Rigidbody2D myRigidBody;

    public EngineButton(bool engineOn, Rigidbody2D myRigidBody)
    {
        this.myRigidBody = myRigidBody;
    }

    //engine button that toggles on and off engine, increases gravity when engine is off
    public bool engineToggle(bool engineOn)
    {
        if (engineOn == true)
        {
            myRigidBody.gravityScale = .8f;
            engineOn = false;
        }
        else 
        {
            myRigidBody.gravityScale = 0.2f;
            engineOn = true;
        }

        return engineOn;
    }
}
