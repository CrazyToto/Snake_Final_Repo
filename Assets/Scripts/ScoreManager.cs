using System.Collections;           //impotiert Lybarys
using System.Collections.Generic;   //
using UnityEngine;                  //
using UnityEngine.UI;               //

public class ScoreManager : MonoBehaviour //Klasse ScoreManager
{
    public Text scoreText;                                       // sagt unity welchen Text zu benutzen
    public static int scoreCount;                                // Static variable um den Score zu speichern
    public Text highscoreText;                                   // sagt unity welchen Text zu benutzen
    public static int highscoreCount;                            // Static variable um den Highscore zu speichern


    void Update()   //Update wird zu beginn jedes Frame aufgerufen
    {
        if(scoreCount > highscoreCount)                          // wenn der score größer ist als der highscore
                                                                 // wird der score zum highscore
        {                                                        //
            highscoreCount = scoreCount;                         //
            PlayerPrefs.SetInt("Highscore", highscoreCount);     //
        }

        scoreText.text = "" + scoreCount;                 // Updatet den Score Text
        highscoreText.text = "" + highscoreCount;     // Updatet den Highscore Text
    }
}
