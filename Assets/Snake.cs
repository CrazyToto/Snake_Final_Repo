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
        if (Input.GetKeyDown(KeyCode.W)) {
            if (_direction != Vector2.down ) {
                _direction = Vector2.up; }

        } else if (Input.GetKeyDown(KeyCode.S)) {
            if (_direction != Vector2.up) {
                _direction = Vector2.down; }

        } else if(Input.GetKeyDown(KeyCode.D)) {
            if (_direction != Vector2.left) { 
            _direction = Vector2.right; }

        } else if (Input.GetKeyDown(KeyCode.A)) { 
            if (_direction != Vector2.right) { 
            _direction = Vector2.left; }
        }
        }

    private void text()
    {
       
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }



        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
            );
    }
    private void grow()
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

//--SEHR WICHTIG-- zum benutzden Tag von allen Wänden auf "Wall" stellen
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
    //    Das ist für extra level = leicht
    }










































