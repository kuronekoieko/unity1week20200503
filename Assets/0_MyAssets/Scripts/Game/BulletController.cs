using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletState
{
    Waiting,
    Shooting,
    Hided,
}

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 50f;
    public BulletState bulletState { get; set; }
    float timer;
    float timeLimit = 3;
    Vector3 vel;
    bool isCollision;

    public void OnStart()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
        bulletState = BulletState.Waiting;
        transform.localPosition = Vector3.zero;
    }

    void FixedUpdate()
    {
        switch (bulletState)
        {
            case BulletState.Shooting:
                rb.velocity = vel;
                Timer();
                break;
            default:
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        var enemy = collisionInfo.gameObject.GetComponent<EnemyController>();
        if (enemy) { return; }

        if (isCollision) { return; }
        isCollision = true;
        vel = Vector3.Reflect(vel, collisionInfo.contacts[0].normal);
        rb.velocity = vel;
        SoundManager.i.PlayOneShot(1);
    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        var enemy = collisionInfo.gameObject.GetComponent<EnemyController>();
        if (enemy) { return; }
        isCollision = false;
    }

    void Timer()
    {
        if (timer > timeLimit)
        {
            bulletState = BulletState.Hided;
            gameObject.SetActive(false);
        }
        timer += Time.deltaTime;
    }

    public void Shoot(Vector3 vec)
    {
        gameObject.SetActive(true);
        vel = vec.normalized * speed;
        transform.parent = null;
        bulletState = BulletState.Shooting;
    }
}
