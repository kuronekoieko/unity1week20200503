using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyController : MonoBehaviour
{
    [NonSerialized] public bool isDead;

    void Start()
    {

    }


    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        var bullet = collisionInfo.gameObject.GetComponent<BulletController>();
        if (bullet == null) { return; }
        gameObject.layer = LayerMask.NameToLayer("Dead");
        isDead = true;
    }
}
