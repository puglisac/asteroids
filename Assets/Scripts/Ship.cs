using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    Rigidbody2D shipRigidBody;
    Vector2 thrustDirection = new Vector2(1,0);
    const float ThrustForce = 0.8f;

    void FixedUpdate()
    {
        if (Input.GetAxis("Thrust") > 0)
        {
            shipRigidBody.AddForce(thrustDirection * ThrustForce, ForceMode2D.Force);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        shipRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
