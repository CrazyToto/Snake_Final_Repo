using System.Collections;           //Impotiert Lybarys
using System.Collections.Generic;   //
using UnityEngine;                  //Lybary f�r Unity 

public class Food : MonoBehaviour   //Klasse Food // MonoBehviour f�r Implementierung in Unity mit Start und Setup Funktionen
{
  public BoxCollider2D gridArea;    //Variable gridArea vom Typ BoxCollider2D, dies ist die Triggerbox
    public int score;   //Variable score vom Typ int


    private void Start() // wird beim Start des Programms einmal ausgef�hrt
    {
      RandomizePosition(); // Funktion f�r das Setzten der Position des Essen
        score = 0;  // legt den Startwert des Scores fest
    }
    private void RandomizePosition() // Funktion f�r das Setzten der Position des Essen
    {
        Bounds bounds = this.gridArea.bounds;   // legt die Grenzen des Spielfeldes fest

        float x = Random.Range(bounds.min.x, bounds.max.x); // legt die x-Position auf einen zuf�lligen Wert im Rahmen fest
        float y = Random.Range(bounds.min.y, bounds.max.y); // legt die y-Position auf einen zuf�lligen Wert im Rahmen fest

        this.transform.position = new Vector3(Mathf.Round(x),Mathf.Round(y), 0.0f); // legt die Position fest;
                                                                                    // Mathf.Round rundet die Ergebnisse, sodass die Bl�cke alle
                                                                                    // auf dem Koordinatensystem auf gleicher H�he sind
    
    
    }



    private void OnTriggerEnter2D(Collider2D other) // Funktion f�r die Kollision mit dem Schlangenkopf
    {   if (other.tag == "Player") // wenn das Objekt mit dem kollidiert wird den Tag Player hat, diesen hat der Schlangenkopf
        {
            RandomizePosition(); // erscheint das Essen wieder an einem neuen Ort 
            score = score + 1;  // der Score wird um 1 erh�ht
        }
    }
}
