using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletState
{
    Waiting,
    Shooting,
}

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 20f;
    public BulletState bulletState { get; set; }
    float timer;
    float timeLimit = 3;

    public void OnStart()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
        bulletState = BulletState.Waiting;
        transform.localPosition = Vector3.zero;
    }

    void Update()
    {
        if (timer > timeLimit)
        {
            gameObject.SetActive(false);
        }
        timer += Time.deltaTime;
    }

    public void Shoot(Vector3 vec)
    {
        gameObject.SetActive(true);
        rb.velocity = vec.normalized * speed;
        transform.parent = null;
        bulletState = BulletState.Shooting;
    }
}
