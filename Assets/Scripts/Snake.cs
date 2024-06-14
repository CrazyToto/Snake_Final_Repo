using System.Collections;                    //Impotiert Libarys
using System.Collections.Generic;            //.
using UnityEngine;     


public class Snake : MonoBehaviour  //Klasse Snake
{
    private Vector2 _direction = Vector2.right; // Variable für die Bewegungsrichtung der Schlange
    private List<Transform> _segments = new List<Transform>();  // Liste für die Schlangenteile
    public Transform segmentPrefab; // Variable für das Schlangenteil
    public int initialSize = 4; // Variable für die Anzahl der Schlangenteile


    private void Start()    // wird einmalig beim Start des Spiels ausgeführt
    {
        ResetState();   // ruft die Funktion ResetState auf
    }

    private void Update()   // wird am Anfang jedes Frames ausgeführt
    {
        if (Input.GetKeyDown(KeyCode.W))    // Prüft den Tastendruck W
        {
            if (_direction != Vector2.down) // Prüft, dass die Schlange nicht in die entgegengesetzte Richtung gedreht wird
                                            // und somit mit sich selbst kollidieren würde
            {
                _direction = Vector2.up;    // setzt die Bewegungsrichtung nach oben
            }

        } else if (Input.GetKeyDown(KeyCode.S)) // Prüft den Tastendruck S 
        {
            if (_direction != Vector2.up)   // Prüft, dass die Schlange nicht in die entgegengesetzte Richtung fährt und somit mit sich selbst kollidieren würde
            {
                _direction = Vector2.down;  // setzt die Bewegungsrichtung nach unten
            }

        } else if(Input.GetKeyDown(KeyCode.D))  // Prüft den Tastendruck D 
        {
            if (_direction != Vector2.left) // Prüft, dass die Schlange nicht in die entgegengesetzte Richtung fährt und somit mit sich selbst kollidieren würde
            {
                _direction = Vector2.right; // setzt die Bewegungsrichtung nach rechts
            }

        } else if (Input.GetKeyDown(KeyCode.A)) // Prüft den Tastendruck A
        {
            if (_direction != Vector2.right)    // Prüft, dass die Schlange nicht in die entgegengesetzte Richtung fährt und somit mit sich selbst kollidieren würde
            {
                _direction = Vector2.left;  // setzt die Bewegungsrichtung nach links
            }
        }
        }


    private void FixedUpdate()  // wird in regelmäßigen Abständen ausgeführt
    {
        for (int i = _segments.Count -1; i > 0; i--)            // wiederholt die Anweisung in absteigender Reheinfolge für alle Schlangen Segmente
        {
            _segments[i].position = _segments[i - 1].position;  // setzt für jedes Segment die Position auf die vorherige Position
                                                                // des weiter vorne also näher am Schlangenkopf liegenden Segment
        }



        this.transform.position = new Vector3(                      // setzt die Position des Schlangenkopfes auf die neue Position
            Mathf.Round(this.transform.position.x) + _direction.x,  // rundet die x-Koordinate auf die nächste ganze Zahl
            Mathf.Round(this.transform.position.y) + _direction.y,  // rundet die y-Koordinate auf die nächste ganze Zahl
            0.0f                                                    // die z-Koordinate ist auf 0, weil wir sie im 2D Spiel nicht benötigen
            );
    }
    private void grow() // Funktion um mehrere Schlangenteile anzufügen
    {
        Transform segment = Instantiate(this.segmentPrefab);    // erstellt ein neues Schlangenteil
        segment.position = _segments[_segments.Count - 1].position; // setzt die Position des neuen Schlangenteils auf die Position des letzten Schlangenteils
        _segments.Add(segment); // fügt das neue Schlangenteil der Liste hinzu


    }

    private void ResetState()   // Funktion um die Schlange zu resetten
    {
        for (int i = 1; i < _segments.Count; i++)   // wiederholt die Anweisung für alle Schlangenteile
        {
            Destroy(_segments[i].gameObject);   // löscht das Schlangenteil
        }

        _segments.Clear();  // löscht die Liste der Schlangenteile
        _segments.Add(this.transform);  // fügt das Schlangenteil der Liste hinzu

        for (int i = 1; i < this.initialSize; i++)  // wiederholt die Anweisung für die Anzahl der Schlangenteile
        {
            _segments.Add(Instantiate(this.segmentPrefab)); // erstellt ein neues Schlangenteil
        }

        this.transform.position = Vector3.zero; // setzt die Position des Schlangenkopfes auf 0
    }

    private void ResetScore()           // Funktion um Score auf 0 zu setzen
    {                                   //
        ScoreManager.scoreCount = 0;    //
    }                                   //

//--SEHR WICHTIG-- zum benutzden Tag von allen Wänden auf "Wall" stellen
//----------------------------------------------------------------------
    private void Teleport() // Funktion um die Schlange zu teleportieren
    {   
        if (_direction != Vector2.left) // Prüft ob die Schlange nicht nach links fährt
        {
            if (_direction != Vector2.right)    // Prüft ob die Schlange nicht nach rechts fährt
            {
                if (_direction != Vector2.up)   // Prüft ob die Schlange nicht nach oben fährt
                {
                    this.transform.position = new Vector3(  // setzt die Position des Schlangenkopfes auf die neue Position
                        this.transform.position.x,  // setzt die x-Koordinate auf die aktuelle x-Koordinate
                        this.transform.position.y * -1, // setzt die y-Koordinate auf die aktuelle y-Koordinate mal -1
                        0.0f    // setzt die z-Koordinate auf 0
                        );
                }
                else   // wenn die Schlange nach oben fährt
                {
                    this.transform.position = new Vector3(  // setzt die Position des Schlangenkopfes auf die neue Position
                         this.transform.position.x, // setzt die x-Koordinate auf die aktuelle x-Koordinate
                         this.transform.position.y * -1,    // setzt die y-Koordinate auf die aktuelle y-Koordinate mal -1
                         0.0f   // setzt die z-Koordinate auf 0
                         );
                }
            }
            else   // wenn die Schlange nach rechts fährt
            {
                this.transform.position = new Vector3(  // setzt die Position des Schlangenkopfes auf die neue Position
                     this.transform.position.x * -1,    // setzt die x-Koordinate auf die aktuelle x-Koordinate mal -1
                     this.transform.position.y, // setzt die y-Koordinate auf die aktuelle y-Koordinate
                     0.0f   // setzt die z-Koordinate auf 0
                     );
            }      
        }
        else  // wenn die Schlange nach links fährt
        { 
            this.transform.position = new Vector3(  // setzt die Position des Schlangenkopfes auf die neue Position
                 this.transform.position.x * -1,    // setzt die x-Koordinate auf die aktuelle x-Koordinate mal -1
                 this.transform.position.y, // setzt die y-Koordinate auf die aktuelle y-Koordinate
                 0.0f   // setzt die z-Koordinate auf 0
                 );
        }
    }



    private void OnTriggerEnter2D(Collider2D other) //Funktion welche aufgerufen wird, wenn die Schlange mit einem anderen Objekt kollidiert
    {
        if (other.tag == "Apple")    // Prüft ob die Schlange auf ein Apfel stößt
        {
            grow(); // ruft die Funktion grow auf
            ScoreManager.scoreCount += 1;   // addiert 1 zum Score

        }
        else if (other.tag == "Obstacle")   // Prüft ob die Schlange gegen ein Hindernis stößt
        {
            ResetState();   //resettet die Schlange
            ResetScore();   // resetet den Score
        }
        else if (other.tag == "Wall")   // Prüft ob die Schlange gegen eine Wand stößt
        {
            Teleport(); //ruft die Funktion Teleport auf
                        //Das ist für extra level = leicht
        }
    }
 

}



































