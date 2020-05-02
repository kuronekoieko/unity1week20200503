﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class FailedCanvasManager : BaseCanvasManager
{
    [SerializeField] Button restartButton;
    public override void OnStart()
    {
        base.SetScreenAction(thisScreen: ScreenState.Failed);
        restartButton.onClick.AddListener(OnClickRestartButton);
        gameObject.SetActive(false);
    }

    public override void OnUpdate()
    {
        if (!base.IsThisScreenState()) { return; }

    }

    protected override void OnOpen()
    {
        DOVirtual.DelayedCall(0f, () =>
        {
            gameObject.SetActive(true);
        });
    }

    protected override void OnClose()
    {
        gameObject.SetActive(false);
    }

    void OnClickRestartButton()
    {
        base.ReLoadScene();
    }

    void OnClickHomeButton()
    {
        Variables.screenState = ScreenState.Home;
    }
}
