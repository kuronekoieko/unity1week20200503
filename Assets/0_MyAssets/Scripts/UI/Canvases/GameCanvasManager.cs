﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// ゲーム画面
/// ゲーム中に表示するUIです
/// あくまで例として実装してあります
/// ボタンなどは適宜編集してください
/// </summary>
public class GameCanvasManager : BaseCanvasManager
{
    [SerializeField] Text stageNumText;
    [SerializeField] Button retryButton;

    public override void OnStart()
    {
        base.SetScreenAction(thisScreen: ScreenState.Game);

        this.ObserveEveryValueChanged(currentStageIndex => Variables.currentStageIndex)
            .Subscribe(currentStageIndex => { ShowStageNumText(); })
            .AddTo(this.gameObject);

        retryButton.onClick.AddListener(base.ReLoadScene);

        gameObject.SetActive(true);

    }

    public override void OnUpdate()
    {
        if (!base.IsThisScreenState()) { return; }

    }

    protected override void OnOpen()
    {
        gameObject.SetActive(true);
    }

    protected override void OnClose()
    {
        // gameObject.SetActive(false);
    }

    void ShowStageNumText()
    {
        stageNumText.text = "LEVEL " + (Variables.currentStageIndex + 1).ToString("000");
    }
}

