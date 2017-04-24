using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class UILose : UIBase
{
    public Text txt_IQ;

    public override void DoOnEntering()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;

        transform.GetChild(0).DOLocalMoveY(0, 1f);
        int IQ = Random.Range(-500, 200);
        txt_IQ.text = IQ.ToString();

        CanvasGroup.interactable = true;
    }

    public override void DoOnPausing()
    {

    }

    public override void DoOnResuming()
    {
        int IQ = Random.Range(-500, 200);
        txt_IQ.text = IQ.ToString();

        CanvasGroup.interactable = true;
    }

    public override void DoOnExiting()
    {
        CanvasGroup.interactable = false;
        transform.GetChild(0).DOLocalMoveY(466, 1f);
    }

    public void OnRePlayClick()
    {
        UIManager.Instance.PopUIPanel();
    }
}
