using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesMovement : MonoBehaviour
{
    [SerializeField] float distanceToCover;
    [SerializeField] float speed;

    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        Vector3 vec = startingPosition;
        vec.x += distanceToCover * Mathf.Sin(Time.time * speed);
        transform.position = vec;
    }
}
