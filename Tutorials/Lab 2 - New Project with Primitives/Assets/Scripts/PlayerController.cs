using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private Rigidbody playerRb;
    private float zBound = 16;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstainPlayerPosition();
    }

    private void ConstainPlayerPosition()
    {
        if (playerRb.position.z < -zBound)
        {
            playerRb.transform.position = new Vector3(playerRb.position.x, playerRb.position.y, -zBound);
        }
        else if (playerRb.position.z > zBound)
        {
            playerRb.transform.position = new Vector3(playerRb.position.x, playerRb.position.y, zBound);
        }
    }

    private void MovePlayer()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        playerRb.AddForce(Vector3.forward * speed * vertical);
        playerRb.AddForce(Vector3.right * speed * horizontal);
    }
}
