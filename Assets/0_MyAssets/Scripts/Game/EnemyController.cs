using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        var bullet = collisionInfo.gameObject.GetComponent<BulletController>();
        if (bullet == null) { return; }
        gameObject.layer = LayerMask.NameToLayer("Dead");
    }
}
