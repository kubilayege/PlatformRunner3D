using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingObstacle : MonoBehaviour
{
    public enum MovementType
    {
        None,
        Rotate,
        Patrol
    }

    public enum Axis
    {
        None,
        XPositive,
        XNegative,
        YPositive,
        YNegative,
        ZPositive,
        ZNegative
    }

    public Axis direction;
    public MovementType movementType;

    private Axis _direction;
    private MovementType _movementType;
    
    
    [SerializeField]
    private float turnSpeed;

    [SerializeField]
    private float lenghtOfMovement;
    [SerializeField]
    private float moveSpeed;


    private Vector3 startingPos;
    private Vector3 targetPos;


    private Rigidbody rb;
    private bool patrol;

    public void Start()
    {
        patrol = false;
        rb = GetComponent<Rigidbody>();
        startingPos = transform.position;
        targetPos = startingPos + Helper.axisVectors[(int)direction] * lenghtOfMovement;
        
        //Defaults
        _direction = direction;
        _movementType = movementType;
    }


    public void Update()
    {
        switch (movementType)
        {
            case MovementType.Rotate:
                RotationMovement();
                break;
            case MovementType.Patrol:
                PatrolMovement();
                break;
            default:
                break;
        }
    }

    private void RotationMovement()
    {
        rb.AddTorque( Helper.axisVectors[(int)direction] * rb.mass * turnSpeed);
    }

    private void PatrolMovement()
    {
        if (!patrol)
        {
            if (rb.MoveToUntil(targetPos, moveSpeed))
                patrol = true;
        }
        else
        {
            if (rb.MoveToUntil(startingPos, moveSpeed))
                patrol = false;
        }
    }
}
