using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour
{
    [SerializeField]
    GameObject prefabRock;
    [SerializeField]
    GameObject prefabExplosion;

    Rigidbody2D asteroidRigidBody;

    ScoreCanvas score;

    const float ThrustForce = 20f;
    Vector3 ExplosionSize = new Vector3(2, 2, 1);

    // Start is called before the first frame update
    // add random force direction, sprite, torque to asteroid
    void Start()
    {
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
    //splits rock in 2 if larger than .5 scale
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "torpedo")
        {
            if (gameObject.transform.localScale.x > .5)
            {
                splitRock(gameObject.transform.localScale);
            }
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameObject explosion = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
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



    //splits rock into 2 new rocks
    void splitRock(Vector3 scale)
    {
        scale.x -= .25f;
        scale.y -= .25f;
        GameObject[] newRocks = new GameObject[2]
            {
                Instantiate(prefabRock),
                Instantiate(prefabRock)
            };
        foreach(GameObject rock in newRocks)
        {
            rock.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            rock.transform.position = gameObject.transform.position;
            rock.transform.localScale = scale;
        }


    }
}
