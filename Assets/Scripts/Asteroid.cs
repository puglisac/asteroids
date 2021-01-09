using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite RedRock;
    [SerializeField]
    Sprite GreenRock;
    [SerializeField]
    Sprite WhiteRock;

    Rigidbody2D asteroidRigidBody;
    SpriteRenderer asteroidSprite;

    const float ThrustForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        asteroidSprite = gameObject.GetComponent<SpriteRenderer>();
        asteroidSprite.sprite = randomSprite();
        asteroidRigidBody = gameObject.GetComponent<Rigidbody2D>();
        asteroidRigidBody.AddForce(RandomVector2() * ThrustForce, ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 RandomVector2()
    {
        float random = Random.value*360;
        return new Vector2(Mathf.Cos(random), Mathf.Sin(random));
    }

    public Sprite randomSprite()
    {
        int randomInt = Random.Range(1,4);

        if (randomInt == 1)
        {
            return RedRock;
        }
        else if (randomInt == 2)
        {
            return GreenRock;
        }
        else
        {
            return WhiteRock;
        }
    }
}
