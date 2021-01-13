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
    [SerializeField]
    GameObject prefabExplosion;

    Rigidbody2D asteroidRigidBody;
    SpriteRenderer asteroidSprite;

    ScoreCanvas score;

    const float ThrustForce = 20f;
    Vector3 ExplosionSize = new Vector3(2, 2, 1);

    // Start is called before the first frame update
    // add random force direction, sprite, torque to asteroid
    void Start()
    {
        asteroidSprite = gameObject.GetComponent<SpriteRenderer>();
        asteroidSprite.sprite = randomSprite();
        asteroidRigidBody = gameObject.GetComponent<Rigidbody2D>();
        asteroidRigidBody.AddForce(RandomVector2() * ThrustForce, ForceMode2D.Force);
        asteroidRigidBody.AddTorque(Random.Range(-2,2));

        GameObject canvas = GameObject.FindGameObjectWithTag("scoreCanvas");
        score = canvas.GetComponent<ScoreCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //destroys asteroid and renders explosion when shot with torpedo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "torpedo")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameObject explosion = Instantiate<GameObject>(prefabExplosion, transform.position, Quaternion.identity);
            explosion.transform.localScale = ExplosionSize;
            score.updateScore(10);
        }
    }

    //returns a random Vecto2
    public Vector2 RandomVector2()
    {
        float random = Random.value*360;
        return new Vector2(Mathf.Cos(random), Mathf.Sin(random));
    }

    //returns a random sprite
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
