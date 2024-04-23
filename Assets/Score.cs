using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public string ScoreText;
    public string HighscoreText;

    public int score = 0;
    public int highscore = 0;



    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
