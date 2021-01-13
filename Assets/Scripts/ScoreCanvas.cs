using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCanvas : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = $"Score: {score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int points)
    {
        score += points;
        scoreText.text = $"Score: {score}";
    }
}
