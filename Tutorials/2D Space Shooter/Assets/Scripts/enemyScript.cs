using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public int speed = -5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var r2d = GetComponent<Rigidbody2D>();
        r2d.velocity = new Vector2(0, speed);
        r2d.angularVelocity = Random.Range(-200, 200);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        var name = col.gameObject.name;
        if (name == "bullet(Clone)")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }

        if (name == "spaceship")
        {
            Destroy(gameObject);
        }
    }
}
