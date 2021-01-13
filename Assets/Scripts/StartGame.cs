using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject[] oldScore = GameObject.FindGameObjectsWithTag("scoreCanvas");
            if (oldScore.Length > 0)
            {
                foreach (GameObject score in oldScore)
                {
                    Destroy(score);
                }
            }
            SceneManager.LoadScene("Scene0");
        }

        
    }
}
