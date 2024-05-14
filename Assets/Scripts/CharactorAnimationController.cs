using System;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
public class CharactorAnimationController: AnimationController
{
    private static readonly int isWalking = Animator.StringToHash("IsWalking");
    private static readonly int isRun = Animator.StringToHash("IsRun");
    private static readonly int isSit = Animator.StringToHash("IsSit");

    private readonly float magnituteThreadshold = 0.5f; //문턱

    public List<AnimatorOverrideController> animators;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        controller.OnMoveEvent += Walk;
        controller.OnDashEvent += Run;
        controller.OnEmotionEvent += Emotion;
    }

    private void Emotion(bool obj)
    {
        animator.SetBool(isSit, obj);
    }

    private void Run(bool obj)
    {
        animator.SetBool(isRun, obj);
        animator.SetBool(isSit, false);
    }

    private void Walk(Vector2 vector)
    {
        animator.SetBool(isWalking, vector.magnitude > magnituteThreadshold);
        animator.SetBool(isSit, false);

    }

    public void ChangeAnimator(int num)
    {
        animator.runtimeAnimatorController = animators[num];
    }
}


