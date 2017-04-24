using UnityEngine;
using System.Collections;

public class HeroAnim : MonoBehaviour
{
    private Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }


    public void IdleState()
    {
        Animator.SetBool("Die", false);

        Animator.SetFloat("Run", 1.0f);
    }

    public void RunState(bool isLeft)
    {
        float value = isLeft ? 0 : 2;
        Animator.SetFloat("Run", value);
    }

    public void JumpStart(bool isLeft)
    {
        if (isLeft)
            Animator.SetBool("JumpL", true);
        else
            Animator.SetBool("JumpR", true);
    }

    public void JumpOver()
    {
        Animator.SetBool("JumpL", false);
        Animator.SetBool("JumpR", false);
    }


    bool isDead = false;
    public void DieState()
    {
        if (!isDead)
        {
            Animator.SetBool("Die", true);
            isDead = false;
        }
    }


}
