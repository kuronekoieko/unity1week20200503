using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyController : MonoBehaviour
{
    [SerializeField] ParticleSystem deadPS;
    [NonSerialized] public bool isDead;


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
    }

    void HitHighSpeedObj(Collision2D collisionInfo)
    {
        var rb = collisionInfo.rigidbody;
        if (rb == null) { return; }
        //Debug.Log(rb.velocity.sqrMagnitude);
        if (rb.velocity.sqrMagnitude < 5) { return; }
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
