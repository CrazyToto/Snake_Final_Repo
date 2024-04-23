using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 4;

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        { // Pr�ft den Tastendruck W 
            if (_direction != Vector2.down)  // Pr�ft, dass die Schlange nicht in die entgegengesetzte Richtung gedreht wird
                                             // und somit mit sich selbst kollidieren w�rde
            {
                _direction = Vector2.up;   // setzt die Bewegungsrichtung nach oben
            }

        } else if (Input.GetKeyDown(KeyCode.S))  // Pr�ft den Tastendruck S 
        {
            if (_direction != Vector2.up) // Pr�ft, dass die Schlange nicht in die entgegengesetzte Richtung f�hrt und somit mit sich selbst kollidieren w�rde
            {
                _direction = Vector2.down;   // setzt die Bewegungsrichtung nach unten
            }

        } else if(Input.GetKeyDown(KeyCode.D))  // Pr�ft den Tastendruck D 
        {
            if (_direction != Vector2.left) // Pr�ft, dass die Schlange nicht in die entgegengesetzte Richtung f�hrt und somit mit sich selbst kollidieren w�rde
            {
                _direction = Vector2.right;   // setzt die Bewegungsrichtung nach rechts
            }

        } else if (Input.GetKeyDown(KeyCode.A))  // Pr�ft den Tastendruck A
        {
            if (_direction != Vector2.right) // Pr�ft, dass die Schlange nicht in die entgegengesetzte Richtung f�hrt und somit mit sich selbst kollidieren w�rde
            {
                _direction = Vector2.left;   // setzt die Bewegungsrichtung nach links
            }
        }
        }

    private void text()
    {
       
    }

    private void FixedUpdate()  // wird nach jedem Timestep ausgef�hrt
    {
        for (int i = _segments.Count - 1; i > 0; i--) // wiederholt die Anweisung in absteigender Reheinfolge f�r alle Schlangen Segmente
        {
            _segments[i].position = _segments[i - 1].position; // setzt f�r jedes Segment die Position auf die vorherige Position
                                                               // des weiter vorne also n�her am Schlangenkopf liegenden Segment
        }



        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
            );
    }
    private void grow() // Funktion um mehrere Schlangenteile anzuf�gen
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
        
    }

    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.initialSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;
    }

//--SEHR WICHTIG-- zum benutzden Tag von allen W�nden auf "Wall" stellen
//----------------------------------------------------------------------
    private void Teleport() {
        if (_direction != Vector2.left) 
        {
            if (_direction != Vector2.right)
            {
                if (_direction != Vector2.up)
                {
                    this.transform.position = new Vector3(
                        this.transform.position.x,
                        this.transform.position.y * -1,
                        0.0f
                        );
                } else
                {
                    this.transform.position = new Vector3(
                         this.transform.position.x,
                         this.transform.position.y * -1,
                         0.0f
                         );
                }
            }
            else
            {
                this.transform.position = new Vector3(
                     this.transform.position.x * -1,
                     this.transform.position.y,
                     0.0f
                     );
            }      
        } else{
            this.transform.position = new Vector3(
                 this.transform.position.x * -1,
                 this.transform.position.y,
                 0.0f
                 );
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            grow();

        }
        else if (other.tag == "Obstacle")
        {
            ResetState();
        }

          else if (other.tag == "Wall")
              {
                Teleport();
              }
            }
    //    Das ist f�r extra level = leicht
    }










































