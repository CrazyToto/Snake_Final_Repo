using System.Collections;                    //Impotiert Libarys
using System.Collections.Generic;            //.
using UnityEngine;     


public class Snake : MonoBehaviour  //Klasse Snake
{
    private Vector2 _direction = Vector2.right; // Variable f�r die Bewegungsrichtung der Schlange
    private List<Transform> _segments = new List<Transform>();  // Liste f�r die Schlangenteile
    public Transform segmentPrefab; // Variable f�r das Schlangenteil
    public int initialSize = 4; // Variable f�r die Anzahl der Schlangenteile


    private void Start()    // wird einmalig beim Start des Spiels ausgef�hrt
    {
        ResetState();   // ruft die Funktion ResetState auf
    }

    private void Update()   // wird am Anfang jedes Frames ausgef�hrt
    {
        if (Input.GetKeyDown(KeyCode.W))    // Pr�ft den Tastendruck W
        {
            if (_direction != Vector2.down) // Pr�ft, dass die Schlange nicht in die entgegengesetzte Richtung gedreht wird
                                            // und somit mit sich selbst kollidieren w�rde
            {
                _direction = Vector2.up;    // setzt die Bewegungsrichtung nach oben
            }

        } else if (Input.GetKeyDown(KeyCode.S)) // Pr�ft den Tastendruck S 
        {
            if (_direction != Vector2.up)   // Pr�ft, dass die Schlange nicht in die entgegengesetzte Richtung f�hrt und somit mit sich selbst kollidieren w�rde
            {
                _direction = Vector2.down;  // setzt die Bewegungsrichtung nach unten
            }

        } else if(Input.GetKeyDown(KeyCode.D))  // Pr�ft den Tastendruck D 
        {
            if (_direction != Vector2.left) // Pr�ft, dass die Schlange nicht in die entgegengesetzte Richtung f�hrt und somit mit sich selbst kollidieren w�rde
            {
                _direction = Vector2.right; // setzt die Bewegungsrichtung nach rechts
            }

        } else if (Input.GetKeyDown(KeyCode.A)) // Pr�ft den Tastendruck A
        {
            if (_direction != Vector2.right)    // Pr�ft, dass die Schlange nicht in die entgegengesetzte Richtung f�hrt und somit mit sich selbst kollidieren w�rde
            {
                _direction = Vector2.left;  // setzt die Bewegungsrichtung nach links
            }
        }
        }


    private void FixedUpdate()  // wird in regelm��igen Abst�nden ausgef�hrt
    {
        for (int i = _segments.Count -1; i > 0; i--)            // wiederholt die Anweisung in absteigender Reheinfolge f�r alle Schlangen Segmente
        {
            _segments[i].position = _segments[i - 1].position;  // setzt f�r jedes Segment die Position auf die vorherige Position
                                                                // des weiter vorne also n�her am Schlangenkopf liegenden Segment
        }



        this.transform.position = new Vector3(                      // setzt die Position des Schlangenkopfes auf die neue Position
            Mathf.Round(this.transform.position.x) + _direction.x,  // rundet die x-Koordinate auf die n�chste ganze Zahl
            Mathf.Round(this.transform.position.y) + _direction.y,  // rundet die y-Koordinate auf die n�chste ganze Zahl
            0.0f                                                    // die z-Koordinate ist auf 0, weil wir sie im 2D Spiel nicht ben�tigen
            );
    }
    private void grow() // Funktion um mehrere Schlangenteile anzuf�gen
    {
        Transform segment = Instantiate(this.segmentPrefab);    // erstellt ein neues Schlangenteil
        segment.position = _segments[_segments.Count - 1].position; // setzt die Position des neuen Schlangenteils auf die Position des letzten Schlangenteils
        _segments.Add(segment); // f�gt das neue Schlangenteil der Liste hinzu


    }

    private void ResetState()   // Funktion um die Schlange zu resetten
    {
        for (int i = 1; i < _segments.Count; i++)   // wiederholt die Anweisung f�r alle Schlangenteile
        {
            Destroy(_segments[i].gameObject);   // l�scht das Schlangenteil
        }

        _segments.Clear();  // l�scht die Liste der Schlangenteile
        _segments.Add(this.transform);  // f�gt das Schlangenteil der Liste hinzu

        for (int i = 1; i < this.initialSize; i++)  // wiederholt die Anweisung f�r die Anzahl der Schlangenteile
        {
            _segments.Add(Instantiate(this.segmentPrefab)); // erstellt ein neues Schlangenteil
        }

        this.transform.position = Vector3.zero; // setzt die Position des Schlangenkopfes auf 0
    }

    private void ResetScore()           // Funktion um Score auf 0 zu setzen
    {                                   //
        ScoreManager.scoreCount = 0;    //
    }                                   //

//--SEHR WICHTIG-- zum benutzden Tag von allen W�nden auf "Wall" stellen
//----------------------------------------------------------------------
    private void Teleport() // Funktion um die Schlange zu teleportieren
    {   
        if (_direction != Vector2.left) // Pr�ft ob die Schlange nicht nach links f�hrt
        {
            if (_direction != Vector2.right)    // Pr�ft ob die Schlange nicht nach rechts f�hrt
            {
                if (_direction != Vector2.up)   // Pr�ft ob die Schlange nicht nach oben f�hrt
                {
                    this.transform.position = new Vector3(  // setzt die Position des Schlangenkopfes auf die neue Position
                        this.transform.position.x,  // setzt die x-Koordinate auf die aktuelle x-Koordinate
                        this.transform.position.y * -1, // setzt die y-Koordinate auf die aktuelle y-Koordinate mal -1
                        0.0f    // setzt die z-Koordinate auf 0
                        );
                }
                else   // wenn die Schlange nach oben f�hrt
                {
                    this.transform.position = new Vector3(  // setzt die Position des Schlangenkopfes auf die neue Position
                         this.transform.position.x, // setzt die x-Koordinate auf die aktuelle x-Koordinate
                         this.transform.position.y * -1,    // setzt die y-Koordinate auf die aktuelle y-Koordinate mal -1
                         0.0f   // setzt die z-Koordinate auf 0
                         );
                }
            }
            else   // wenn die Schlange nach rechts f�hrt
            {
                this.transform.position = new Vector3(  // setzt die Position des Schlangenkopfes auf die neue Position
                     this.transform.position.x * -1,    // setzt die x-Koordinate auf die aktuelle x-Koordinate mal -1
                     this.transform.position.y, // setzt die y-Koordinate auf die aktuelle y-Koordinate
                     0.0f   // setzt die z-Koordinate auf 0
                     );
            }      
        }
        else  // wenn die Schlange nach links f�hrt
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
        if (other.tag == "Apple")    // Pr�ft ob die Schlange auf ein Apfel st��t
        {
            grow(); // ruft die Funktion grow auf
            ScoreManager.scoreCount += 1;   // addiert 1 zum Score

        }
        else if (other.tag == "Obstacle")   // Pr�ft ob die Schlange gegen ein Hindernis st��t
        {
            ResetState();   //resettet die Schlange
            ResetScore();   // resetet den Score
        }
        else if (other.tag == "Wall")   // Pr�ft ob die Schlange gegen eine Wand st��t
        {
            Teleport(); //ruft die Funktion Teleport auf
                        //Das ist f�r extra level = leicht
        }
    }
 

}



































