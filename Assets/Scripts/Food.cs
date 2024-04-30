using System.Collections;           //Impotiert Lybarys
using System.Collections.Generic;   //
using UnityEngine;                  //Lybary für Unity 

public class Food : MonoBehaviour   //Klasse Food // MonoBehviour für Implementierung in Unity mit Start und Setup Funktionen
{
  public BoxCollider2D gridArea;    //Variable gridArea vom Typ BoxCollider2D, dies ist die Triggerbox
    public int score;   //Variable score vom Typ int


    private void Start() // wird beim Start des Programms einmal ausgeführt
    {
      RandomizePosition(); // Funktion für das Setzten der Position des Essen
        score = 0;  // legt den Startwert des Scores fest
    }
    private void RandomizePosition() // Funktion für das Setzten der Position des Essen
    {
        Bounds bounds = this.gridArea.bounds;   // legt die Grenzen des Spielfeldes fest

        float x = Random.Range(bounds.min.x, bounds.max.x); // legt die x-Position auf einen zufälligen Wert im Rahmen fest
        float y = Random.Range(bounds.min.y, bounds.max.y); // legt die y-Position auf einen zufälligen Wert im Rahmen fest

        this.transform.position = new Vector3(Mathf.Round(x),Mathf.Round(y), 0.0f); // legt die Position fest;
                                                                                    // Mathf.Round rundet die Ergebnisse, sodass die Blöcke alle
                                                                                    // auf dem Koordinatensystem auf gleicher Höhe sind
    
    
    }



    private void OnTriggerEnter2D(Collider2D other) // Funktion für die Kollision mit dem Schlangenkopf
    {   if (other.tag == "Player") // wenn das Objekt mit dem kollidiert wird den Tag Player hat, diesen hat der Schlangenkopf
        {
            RandomizePosition(); // erscheint das Essen wieder an einem neuen Ort 
            score = score + 1;  // der Score wird um 1 erhöht
        }
    }
}
