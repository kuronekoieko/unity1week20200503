using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyController : MonoBehaviour
{
    [SerializeField] ParticleSystem deadPS;
    [NonSerialized] public bool isDead;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }


    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (isDead) { return; }
        HitBullet(collisionInfo);
        HitHighSpeedObj(collisionInfo);
        Slammed(collisionInfo);
    }

    void Slammed(Collision2D collisionInfo)
    {
        var colRb = collisionInfo.rigidbody;
        if (colRb) { return; }
        if (rb.velocity.sqrMagnitude < 5) { return; }
        Killed();
    }

    void HitHighSpeedObj(Collision2D collisionInfo)
    {
        var colRb = collisionInfo.rigidbody;
        if (colRb == null) { return; }
        //Debug.Log(rb.velocity.sqrMagnitude);
        if (colRb.velocity.sqrMagnitude < 5) { return; }
        Killed();
    }

    void HitBullet(Collision2D collisionInfo)
    {
        var bullet = collisionInfo.gameObject.GetComponent<BulletController>();
        if (bullet == null) { return; }
        Killed();
    }

    void Killed()
    {
        gameObject.layer = LayerMask.NameToLayer("Dead");
        isDead = true;
        deadPS.Play();
    }
}
