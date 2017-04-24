using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CollisionCondition : MonoBehaviour
{
    public bool NeedDie = false;
    public bool NeedWin = false;
    public UnityEvent OnCollisionHandler;

    //头部触发
    public bool NeedHead = false;
    //下路时候不能触发
    public bool NotFall = false;
    //需要保存进度
    public bool NeedSave = false;
	
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (NeedHead && collision.collider.name != "Head")
            return;

        OnCollisionHandler.Invoke();

        if (NeedDie)
        {
            HeroController.Instance.IsDead = true;
        }
        else if (NeedWin)
        {
            //EditorUtility.DisplayDialog("提示", "恭喜你游戏胜利", "大爷知道了");
            Debug.Log("Win");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (NeedSave)
        {
            HeroController.Instance.DefaultPosition =
                transform.position;
        }

        if (NotFall && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
            return;

        OnCollisionHandler.Invoke();

        if (NeedDie)
        {
            HeroController.Instance.IsDead = true;
        }
        else if (NeedWin)
        {
            //EditorUtility.DisplayDialog("提示", "恭喜你游戏胜利", "大爷知道了");
            Debug.Log("Win");
        }
    }
}
