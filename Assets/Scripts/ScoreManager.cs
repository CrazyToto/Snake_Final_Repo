using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;                                       // tells unity wich text to use
    public static int scoreCount;                                // Static variable to store the score
    public Text highscoreText;                                   // tells unity wich text to use
    public static int highscoreCount;                            // Static variable to store the highscore


    // Update is called once per frame
    void Update()
    {
        if(scoreCount > highscoreCount)                          // if the score is higher than the highscore
                                                                 // then the highscore is the score
        {                                                        //
            highscoreCount = scoreCount;                         //
            PlayerPrefs.SetInt("Highscore", highscoreCount);     //
        }

        scoreText.text = "Score: " + scoreCount;                 // updates the score text
        highscoreText.text = "Highscore: " + highscoreCount;     // updates the highscore text
    }
}
