using System.Collections;
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
       // SoundManager.i.PlayOneShot(2);
        uICameraController.PlayConfetti();
        SetStarCount();

        Color c = bgImage.color;
        c.a = 0;
        bgImage.color = c;


        DOVirtual.DelayedCall(1.2f, () =>
        {
            gameObject.SetActive(true);
            DOTween.ToAlpha(() => bgImage.color, color => bgImage.color = color, 0.3f, 0.5f);
            starImages[0].transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
            starImages[1].transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).SetDelay(0.1f);
            starImages[2].transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).SetDelay(0.2f);
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
