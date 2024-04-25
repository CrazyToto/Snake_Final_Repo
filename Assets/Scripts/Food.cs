using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
  public BoxCollider2D gridArea;
    public int score;


    private void Start() // wird beim Start des Programms ausgeführt
    {
      RandomizePosition();
        score = 0;
    }
    private void RandomizePosition() // Funktion für das Setzten der Position des Essen
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x); // legt die x-Position auf einen zufälligen Wert im Rahmen
        float y = Random.Range(bounds.min.y, bounds.max.y); // legt die y-Position auf einen zufälligen Wert im Rahmen

        this.transform.position = new Vector3(Mathf.Round(x),Mathf.Round(y), 0.0f); // legt die Position fest;
                                                                                    // Mathf.Round rundet die Ergebnisse, sodass die Blöcke alle
                                                                                    // auf dem Koordinatensystem auf gleicher Höhe sind
    
    
    }



    private void OnTriggerEnter2D(Collider2D other) // Funktion für die Kollision mit dem Schlangenkopf
    {   if (other.tag == "Player") // wenn das Objekt mit dem kollidiert wird den Tag Player hat, diesen hat der Schlangenkopf
        {
            RandomizePosition(); // erscheint das Essen wieder an einem neuen Ort 
            score = score + 1;
            print($"Score:{score}");
        }
    }
}
