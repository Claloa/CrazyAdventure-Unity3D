using UnityEngine;
using System.Collections;

public class UIBase : MonoBehaviour
{
    protected CanvasGroup CanvasGroup;

    protected virtual void Awake()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void DoOnEntering() { }

    public virtual void DoOnPausing() { }

    public virtual void DoOnResuming() { }

    public virtual void DoOnExiting() { }
}
