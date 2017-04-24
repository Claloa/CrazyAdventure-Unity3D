using UnityEngine;
using System.Collections;
using DG.Tweening;

public class UIOption : UIBase
{
    public override void DoOnEntering()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        CanvasGroup.interactable = true;
        CanvasGroup.DOFade(1f, .5f);
    }

    public override void DoOnPausing()
    {
        CanvasGroup.interactable = false;
    }

    public override void DoOnResuming()
    {
        CanvasGroup.interactable = true;
    }


    public override void DoOnExiting()
    {
        CanvasGroup.DOFade(0f, .5f);
        CanvasGroup.interactable = false;
    }

    public void GoToStart()
    {
        UIManager.Instance.PopUIPanel();
    }

    public void SetBGMMute(bool mute)
    {
        SoundManager.Instance.Mute = mute;
    }
}
