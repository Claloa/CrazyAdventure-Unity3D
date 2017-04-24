using UnityEngine;
using System.Collections;

public class UIStart : UIBase
{

    public override void DoOnEntering()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        SoundManager.Instance.PlayBGM("Audio_bgm_1");
        CanvasGroup.alpha = 1f;
    }

    public override void DoOnPausing()
    {
        CanvasGroup.interactable = false;
        CanvasGroup.alpha = 0f;
    }

    public override void DoOnResuming()
    {
        CanvasGroup.interactable = true;
        CanvasGroup.alpha = 1f;
    }

    public override void DoOnExiting()
    {
        CanvasGroup.alpha = 0f;
    }

    public void GoToOption()
    {
        UIManager.Instance.PushUIPanel("UIOption");
    }

    public void GoToPlay()
    {
        UIManager.Instance.PushUIPanel("Playing");
        //Debug.Log("Play");
    }
}
