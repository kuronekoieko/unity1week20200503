using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    EnemyController[] enemyControllers;

    void Start()
    {
        enemyControllers = FindObjectsOfType<EnemyController>();
    }

    void Update()
    {
        bool isDeadAll = enemyControllers
            .Where(e => e.gameObject.activeSelf)
            .All(e => e.isDead);
        if (isDeadAll)
        {
            Variables.screenState = ScreenState.Clear;
        }
    }
}
