using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    Timer torpedoTimer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject ship = GameObject.FindGameObjectWithTag("ship");
        Ship script = ship.GetComponent<Ship>();
        Vector2 direction = script.getShipHeading();
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(direction * 700, ForceMode2D.Force);

        torpedoTimer = gameObject.AddComponent<Timer>();
        torpedoTimer.Duration = 2;
        torpedoTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (torpedoTimer.Finished)
        {
            Destroy(gameObject);
        }
    }
}

