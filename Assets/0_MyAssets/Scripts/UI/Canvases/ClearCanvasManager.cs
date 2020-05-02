using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class ClearCanvasManager : BaseCanvasManager
{
    [SerializeField] Button nextButton;
    [SerializeField] UICameraController uICameraController;
    [SerializeField] Image[] starImages;
    public readonly ScreenState thisScreen = ScreenState.Clear;

    public override void OnStart()
    {
        base.SetScreenAction(thisScreen: thisScreen);

        nextButton.onClick.AddListener(OnClickNextButton);
        gameObject.SetActive(false);
    }

    public override void OnUpdate()
    {
        if (Variables.screenState != thisScreen) { return; }

    }

    protected override void OnOpen()
    {
        uICameraController.PlayConfetti();
        int bulletCountLeft = GameManager.i.bulletManager.GetLeftCount();
        LevelData levelData = LevelDataSO.i.levelDatas[Variables.currentStageIndex];
        int starCount = 1;
        if (bulletCountLeft >= levelData.twoStarMinimumBulletLeftCount) { starCount = 2; }
        if (bulletCountLeft >= levelData.threeStarMinimumBulletLeftCount) { starCount = 3; }
        Debug.Log(starCount);
        for (int i = 0; i < starImages.Length; i++)
        {
            starImages[i].color = (i < starCount) ? Color.white : Color.black;
            starImages[i].transform.localScale = Vector3.zero;
        }

        DOVirtual.DelayedCall(1.2f, () =>
        {
            gameObject.SetActive(true);
            starImages[0].transform.DOScale(Vector3.one, 1).SetEase(Ease.OutBack);
            starImages[1].transform.DOScale(Vector3.one, 1).SetEase(Ease.OutBack).SetDelay(0.1f);
            starImages[2].transform.DOScale(Vector3.one, 1).SetEase(Ease.OutBack).SetDelay(0.2f);
        });
    }

    protected override void OnClose()
    {
        gameObject.SetActive(false);
    }

    void OnClickNextButton()
    {
        base.ToNextScene();
    }

    void OnClickHomeButton()
    {
        Variables.screenState = ScreenState.Home;
    }
}
