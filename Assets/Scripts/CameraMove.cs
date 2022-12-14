using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    public float speed  =   4;
    public Vector3 CameraPosition;

    void start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame

  
    void FixedUpdate()
    {
        if (player == null) TryGetPlayerArmature();
        Debug.Log(player);
        Vector3 Dposition = player.transform.position + CameraPosition;
        Vector3 Sposition = Vector3.Lerp(transform.position, Dposition, speed * Time.deltaTime);
        transform.position = Sposition;
    }
    void TryGetPlayerArmature()
    {
        try
        {
            player = GameObject.FindGameObjectsWithTag("Player")[1];
        }
        catch(System.Exception)
        {
            return;
        }
    }
}
