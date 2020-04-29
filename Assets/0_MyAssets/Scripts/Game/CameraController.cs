using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Unityで解像度に合わせて画面のサイズを自動調整する
/// http://www.project-unknown.jp/entry/2017/01/05/212837
/// </summary>
public class CameraController : MonoBehaviour
{
    bool isStart;
    public static CameraController i;
    void Start()
    {
        i = this;
    }

    void Update()
    {

    }

    public void Move(float distance)
    {
        if (isStart == false)
        {
            isStart = true;
            return;
        }
        transform.DOLocalMoveZ(distance, 1).SetRelative();
    }
}
