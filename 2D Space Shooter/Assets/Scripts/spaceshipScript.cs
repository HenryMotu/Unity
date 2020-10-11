using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipScript : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var r2d = GetComponent<Rigidbody2D>();


        if (Input.GetKey("right"))
        {
            r2d.velocity = new Vector2(10, 0);
        }
        else if (Input.GetKey("left"))
        {
            r2d.velocity = new Vector2(-10, 0);
        }
        else
        {
            r2d.velocity = new Vector2(0, 0);
        }

        if (Input.GetKeyDown("space"))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
