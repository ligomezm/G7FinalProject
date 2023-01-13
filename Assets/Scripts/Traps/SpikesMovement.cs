using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesMovement : MonoBehaviour
{
    [SerializeField] float distanceToCover;
    [SerializeField] float speed;
    [SerializeField] Direction direction;

    public enum Direction { x, y, z }

    private Vector3 startingPosition;


    private void OnEnable()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 vec = startingPosition;

        if (direction == Direction.x)
        {
            vec.x += distanceToCover * Mathf.Sin(Time.time * speed);
        }

        if (direction == Direction.y)
        {
            vec.y += distanceToCover * Mathf.Sin(Time.time * speed);
        }

        if (direction == Direction.z)
        {
            vec.z += distanceToCover * Mathf.Sin(Time.time * speed);
        }

        transform.position = vec;
    }
}