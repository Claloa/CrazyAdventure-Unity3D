using UnityEngine;
using System.Collections;

public class UIPlaying : UIBase
{
    public override void DoOnEntering()
    {
        gameObject.SetActive(true);
        Camera.main.GetComponent<FollowPlayer>().enabled = true;
    }

    public override void DoOnPausing()
    {

    }

    public override void DoOnResuming()
    {
        HeroController.Instance.ResetPlayer();
        ResetObject[] ros = GameObject.FindObjectsOfType<ResetObject>();
        for (int i = 0; i < ros.Length; i++)
        {
            ros[i].Reset();
        }
    }

    public override void DoOnExiting()
    {
        gameObject.SetActive(false);
        Camera.main.GetComponent<FollowPlayer>().enabled = false;
    }

}
