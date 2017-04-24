using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ResetObject : MonoBehaviour
{
    public UnityEvent OnResetHandler;


    public void Reset()
    {
        OnResetHandler.Invoke();
    }

}
