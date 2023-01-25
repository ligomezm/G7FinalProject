using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRelic : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Congratulations!");
        // victory
    }
}
