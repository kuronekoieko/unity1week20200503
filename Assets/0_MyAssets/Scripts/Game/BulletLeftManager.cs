using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BulletLeftManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer bulletLeftPrefab;
    SpriteRenderer[] bulletLeftSRs;
    float distance = 0.8f;
    int max;
    public void OnStart()
    {
        max = Variables.bulletLeftCount;
        BulletLeftGenerator();
        this.ObserveEveryValueChanged(bulletLeftCount => Variables.bulletLeftCount)
            .Subscribe(bulletLeftCount =>
            {
                for (int i = 0; i < max - bulletLeftCount; i++)
                {
                    bulletLeftSRs[i].color = Color.black;
                }
            })
            .AddTo(this.gameObject);
    }

    void BulletLeftGenerator()
    {
        bulletLeftSRs = new SpriteRenderer[Variables.bulletLeftCount];
        Vector3 pos = Vector3.zero;
        pos.y = 4;
        pos.x = Mathf.Floor(bulletLeftSRs.Length / 2) * (-distance);

        bool isEven = (bulletLeftSRs.Length % 2 == 0);
        if (isEven) { pos.x += distance / 2; }

        for (int i = 0; i < bulletLeftSRs.Length; i++)
        {
            bulletLeftSRs[i] = Instantiate(bulletLeftPrefab, pos, Quaternion.identity, transform);
            pos.x += distance;
        }
    }

    void Update()
    {

    }


}
