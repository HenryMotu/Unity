using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public int speed = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var r2d = GetComponent<Rigidbody2D>();
        r2d.velocity = new Vector2(0, speed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
