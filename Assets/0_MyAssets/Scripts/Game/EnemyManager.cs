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
        CheckClear();
    }

    void CheckClear()
    {
        if (Variables.screenState != ScreenState.Game) { return; }

        bool isDeadAll = enemyControllers
                   .Where(e => e.gameObject.activeSelf)
                   .All(e => e.isDead);
        if (!isDeadAll) { return; }

        Variables.screenState = ScreenState.Clear;
    }
}
