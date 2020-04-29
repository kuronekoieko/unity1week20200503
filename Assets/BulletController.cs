using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot(Vector3 vec)
    {
        rb.velocity = vec.normalized * speed;
        transform.parent = null;
    }
}
