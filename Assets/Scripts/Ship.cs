using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    Rigidbody2D shipRigidBody;

    Vector2 thrustDirection = new Vector2(1,0);

    const float ThrustForce = 0.8f;
    const float RotateDegreesPerSecond = 30;


    // Start is called before the first frame update
    void Start()
    {
        //set the shipRigidBody field to the Rigidbody2D of the game object
        shipRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var rotationInput = Input.GetAxis("Rotate");
        if (rotationInput!=0)
        {
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);
        }
    }

    void FixedUpdate()
    {
        //adds thrust to the game objects rigidbody when 'Thrust' axis > 0
        if (Input.GetAxis("Thrust") > 0)
        {
            shipRigidBody.AddForce(thrustDirection * ThrustForce, ForceMode2D.Force);
        }
        if (Input.GetAxis("Thrust") < 0)
        {
            shipRigidBody.AddForce(-thrustDirection * ThrustForce, ForceMode2D.Force);
        }
    }

}

