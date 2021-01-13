using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;
    [SerializeField]
    GameObject prefabTorpedo;

    Rigidbody2D shipRigidBody;

    Vector2 thrustDirection = new Vector2(1,0);

    const float ThrustForce = 1.3f;
    const float RotateDegreesPerSecond = 70;




    // Start is called before the first frame update
    void Start()
    {
        //set the shipRigidBody field to the Rigidbody2D of the game object
        shipRigidBody = gameObject.GetComponent<Rigidbody2D>();
        AudioManager.Play(AudioClipName.Ambient);
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
            thrustDirection = getShipHeading();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Quaternion shipRotation = gameObject.transform.rotation;
            Instantiate<GameObject>(prefabTorpedo, transform.position, shipRotation);
            AudioManager.Play(AudioClipName.Torpedo);
        }
    }

    void FixedUpdate()
    {
        //adds thrust to the game objects rigidbody when 'Thrust' axis > 0
        if (Input.GetAxis("Thrust") > 0)
        {
            shipRigidBody.AddForce(thrustDirection * ThrustForce, ForceMode2D.Force);
        }
    }

    public Vector2 getShipHeading()
    {
        float rotationZ = transform.eulerAngles.z * Mathf.Deg2Rad;
        float x = Mathf.Cos(rotationZ);
        float y = Mathf.Sin(rotationZ);
        return new Vector2(x, y);
    }

    //destroy ship on collision with asteroid
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate<GameObject>(prefabExplosion, transform.position, Quaternion.identity);
        SceneManager.LoadScene("EndGame");
    }
}

