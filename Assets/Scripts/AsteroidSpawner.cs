using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // needed for spawning
    [SerializeField]
    GameObject prefabRock;

    // spawn control

    Timer spawnTimer;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {


        // create and start timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = 1;
        spawnTimer.Run();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // check for time to spawn a new teddy bear
        if (spawnTimer.Finished)
        {
            if (GameObject.FindGameObjectsWithTag("rock").Length < 3)
            {
                SpawnRock();

                // change spawn timer duration and restart
                spawnTimer.Duration = 1;
                spawnTimer.Run();
            }
        }
    }

    /// <summary>
    /// Spawns a new teddy bear at a random location
    /// </summary>
    void SpawnRock()
    {
        Vector3 location = new Vector3(Random.Range(ScreenUtils.screenLeft, ScreenUtils.screenRight),
                    Random.Range(ScreenUtils.screenBottom, ScreenUtils.screenTop),
                    -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        GameObject rock = Instantiate(prefabRock) as GameObject;
        rock.transform.position = location;
    }
}
