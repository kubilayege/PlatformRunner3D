using System;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : Agent
{
    public Animator anim;
    private Rigidbody rb;
    void Start()
    {
        currentLerpDir = Vector3.zero;
        nextLocation = transform.position;
        _speed = 5f;
        rb = GetComponent<Rigidbody>();
    }
    public float speed;
    private float _speed;
    Vector2 lastTouchPlace;

    public Vector3 currentLerpDir;
    public Vector3 nextLocation;
    public Vector3 lastLocation;
    public Vector3 currentLerpMovement;

    // Update is called once per frame
    void Update()
    {
        base.CheckPos();
        if (Input.GetMouseButtonDown(0))
        {
            lastTouchPlace = Input.mousePosition;
        }

        if (Helper.IsPlaying())
        {
            if(transform.position.HasReached(nextLocation,0.75f))
            {
                nextLocation = (ChoseLocationToMove());
                lastLocation = nextLocation;
            }
            else
            {
                currentLerpDir = nextLocation - transform.position;
                currentLerpMovement = Vector3.Lerp(transform.position, nextLocation, Time.deltaTime * _speed);
                MoveAI(currentLerpMovement);
            }
        }

    }

    private Vector3 ChoseLocationToMove()
    {
        var possibleLocations = new List<Vector3>();
        for (int i = -1; i < 2; i++)
        {
            for (float j = 0; j < 3; j+=0.5f)
            {
                var origin = transform.position + new Vector3(i, 2, j);
                Debug.DrawRay(origin, Vector3.down, Color.red, Time.deltaTime);
                if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit, 10f))
                {
                    if (hit.collider.CompareTag("Platform"))
                        possibleLocations.Add(new Vector3(hit.point.x, 0, hit.point.z));
                }
            }
        }
        if (possibleLocations.Count == 0)
            return transform.position;

        float distance = 1000f;
        var chosenLocation = possibleLocations[0] ;
        foreach(var pos in possibleLocations)
        {
            if(Vector3.Distance(pos, lastLocation) < distance)
            {
                chosenLocation = pos;
                distance = Vector3.Distance(pos, lastLocation);
            }
        }


        return possibleLocations[UnityEngine.Random.Range(0,possibleLocations.Count)];
    }

    public void Animate(Vector3 animVector)
    {
        var horizontal = animVector.x;
        var frontAxis = animVector.z;

        //Debug.Log(anim.GetFloat("Horizontal"));
        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("FrontAxis", frontAxis);
    }

    private void MoveAI(Vector3 currentDir)
    {
        _speed = speed;
        Animate(currentDir);
        rb.MovePosition(currentDir);
    }
}
