using UnityEngine;
using System.Collections;

public class GameRoot : MonoBehaviour
{
    void Start()
    {
        UIManager.Instance.PushUIPanel("UIStart");
    }
}
