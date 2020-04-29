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
        DOVirtual.DelayedCall(1.2f, () =>
        {
            gameObject.SetActive(true);
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
