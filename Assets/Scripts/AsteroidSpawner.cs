using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // needed for spawning
    [SerializeField]
    GameObject prefabRock;
    [SerializeField]
    Sprite RedRock;
    [SerializeField]
    Sprite GreenRock;
    [SerializeField]
    Sprite WhiteRock;

    // spawn control

    Timer spawnTimer;

    // collision-free spawn support
    const int MaxSpawnTries = 20;
    float asteroidrColliderHalfWidth;
    float asteroidColliderHalfHeight;
    Vector2 min = new Vector2();
    Vector2 max = new Vector2();

    //spawn location support
    Vector3 location = new Vector3();
    float minSpawnX;
    float maxSpawnX;
    float minSpawnY;
    float maxSpawnY;


    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {

        minSpawnX = ScreenUtils.ScreenLeft;
        maxSpawnX = ScreenUtils.ScreenRight;
        minSpawnY = ScreenUtils.ScreenBottom;
        maxSpawnY = ScreenUtils.ScreenTop;

        // create and start timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = 1;
        spawnTimer.Run();

        // spawn and destroy an asteroid to cache collider values
        GameObject tempRock = Instantiate(prefabRock) as GameObject;
        BoxCollider2D collider = tempRock.GetComponent<BoxCollider2D>();
        asteroidrColliderHalfWidth = collider.size.x / 2;
        asteroidColliderHalfHeight = collider.size.y / 2;
        Destroy(tempRock);

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // check for time to spawn a new Asteroid
        if (spawnTimer.Finished)
        {
            if (GameObject.FindGameObjectsWithTag("rock").Length < 20)
            {
                SpawnRock();

                // change spawn timer duration and restart
                spawnTimer.Duration = 1;
                spawnTimer.Run();
            }
        }
    }

    /// <summary>
    /// Spawns a new Asteroid  at a random location
    /// </summary>
    void SpawnRock()
    {
        location.x = Random.Range(minSpawnX, maxSpawnX);
        location.y = Random.Range(minSpawnY, maxSpawnY);
        location.z = -Camera.main.transform.position.z;

        SetMinAndMax(location);

        int spawnTries = 1;
        while (Physics2D.OverlapArea(min, max) != null &&
               spawnTries < MaxSpawnTries)
        {
            // change location and calculate new rectangle points
            location.x = Random.Range(minSpawnX, maxSpawnX);
            location.y = Random.Range(minSpawnY, maxSpawnY);
            SetMinAndMax(location);

            spawnTries++;
        }

        //add asteroid if no collisions
        if (Physics2D.OverlapArea(min, max) == null)
        {
            GameObject rock = Instantiate(prefabRock);
            rock.transform.position = location;
            rock.GetComponent<SpriteRenderer>().sprite = randomSprite();
        }
    }

    //set min and max to check for collisions
    void SetMinAndMax(Vector3 location)
    {
        min.x = location.x - asteroidrColliderHalfWidth;
        min.y = location.y - asteroidColliderHalfHeight;
        max.x = location.x + asteroidrColliderHalfWidth;
        max.y = location.y + asteroidColliderHalfHeight;
    }

    //returns a random sprite
    public Sprite randomSprite()
    {
        int randomInt = Random.Range(1, 4);

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
