using UnityEngine;

public class AnimationController : MonoBehaviour
{
    protected Animator animator;
    protected TopDownController controller;

    protected void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<TopDownController>();
    }

}


