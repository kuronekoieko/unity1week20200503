﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class ClearCanvasManager : BaseCanvasManager
{
    [SerializeField] Button nextButton;
    [SerializeField] Button retryButton;
    [SerializeField] UICameraController uICameraController;
    [SerializeField] Image bgImage;
    [SerializeField] Text clearText;
    [SerializeField] Image[] starImages;

    public override void OnStart()
    {
        base.SetScreenAction(thisScreen: ScreenState.Clear);

        nextButton.onClick.AddListener(OnClickNextButton);
        retryButton.onClick.AddListener(base.ReLoadScene);
        gameObject.SetActive(false);
    }

    public override void OnUpdate()
    {
        if (!base.IsThisScreenState()) { return; }

    }

    protected override void OnOpen()
    {
        bool isLastStage = Variables.currentStageIndex == Variables.lastStageIndex;
        nextButton.gameObject.SetActive(!isLastStage);
        clearText.text = isLastStage ? "COMPLETE!!!" : "CLEAR!";

        SetStarCount();

        Color c = bgImage.color;
        c.a = 0;
        bgImage.color = c;


        DOVirtual.DelayedCall(0.8f, () =>
        {
            if (isLastStage)
            {
                SoundManager.i.PlayOneShot(5);
                uICameraController.PlayConfetti();
            }
            gameObject.SetActive(true);
            DOTween.ToAlpha(() => bgImage.color, color => bgImage.color = color, 0.3f, 0.5f);
            starImages[0].transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).OnStart(() => SoundManager.i.PlayOneShot(3));
            starImages[1].transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).SetDelay(0.1f).OnStart(() => SoundManager.i.PlayOneShot(3));
            starImages[2].transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).SetDelay(0.2f).OnStart(() => SoundManager.i.PlayOneShot(3));
        });
    }

    protected override void OnClose()
    {
        gameObject.SetActive(false);
    }

    void OnClickNextButton()
    {
        base.ToNextScene();
        //DOTween.ToAlpha(() => bgImage.color, color => bgImage.color = color, 0f, 0.5f).OnComplete(base.ToNextScene);
    }

    void OnClickHomeButton()
    {
        Variables.screenState = ScreenState.Home;
    }

    void SetStarCount()
    {
        int bulletCountUsed = GameManager.i.bulletManager.GetUsedCount();
        LevelData levelData = LevelDataSO.i.levelDatas[Variables.currentStageIndex];
        int starCount = 1;
        if (bulletCountUsed <= levelData.twoStarMinimumBulletCountUsed) { starCount = 2; }
        if (bulletCountUsed <= levelData.threeStarMinimumBulletCountUsed) { starCount = 3; }



        for (int i = 0; i < starImages.Length; i++)
        {
            starImages[i].color = (i < starCount) ? Color.white : Color.black;
            starImages[i].transform.localScale = Vector3.zero;
        }
    }
}
