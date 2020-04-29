﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeCanvasManager : BaseCanvasManager
{
    [SerializeField] Button startButton;
    public readonly ScreenState thisScreen = ScreenState.Home;


    public override void OnStart()
    {
        base.SetScreenAction(thisScreen: thisScreen);

        startButton.onClick.AddListener(OnClickStartButton);
    }

    public override void OnUpdate()
    {
        if (Variables.screenState != thisScreen) { return; }

    }

    protected override void OnOpen()
    {
        gameObject.SetActive(true);
    }

    protected override void OnClose()
    {
        gameObject.SetActive(false);
    }

    void OnClickStartButton()
    {
        Variables.screenState = ScreenState.Game;
    }
}
