using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// 3D空間の処理の管理
/// </summary>
public class GameManager : MonoBehaviour
{
    public BulletManager bulletManager;
    public EnemyManager enemyManager;
    public BulletLeftManager bulletLeftManager;
    GameObject[] stages;
    PlayerController player;
    public static GameManager i;

    void Start()
    {
        i = this;
        Variables.bulletCount = 5;

        stages = Resources.LoadAll("Stages", typeof(GameObject)).Cast<GameObject>().ToArray();
        Variables.lastStageIndex = stages.Length - 1;
        Instantiate(stages[Variables.currentStageIndex], Vector3.zero, Quaternion.identity);

        player = FindObjectOfType<PlayerController>();
        player.OnStart(bulletManager);

        enemyManager.OnStart();

        bulletLeftManager.OnStart();
    }
}
