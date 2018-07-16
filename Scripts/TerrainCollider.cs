using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCollider : MonoBehaviour {

    public float deathSpeed;

    private float velocity;
    

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            velocity = GameObject.Find(collider.gameObject.name).GetComponent < PlayerControl > ().currentSpeed;
            tooFast(velocity, collider);
        }

        if(collider.gameObject.tag == "Enemy")
        {
            
        }
    }

    void tooFast(float currentVelocity, Collision2D collider)
    {
        if(currentVelocity > deathSpeed)
        {
            Debug.Log("You have died");
            collider.gameObject.transform.position = new Vector2(0, 0);
        }
    }

}
