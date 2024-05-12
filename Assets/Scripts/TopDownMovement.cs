using System;
using Unity.VisualScripting;
using UnityEngine;

public class TopDownMovement :MonoBehaviour
{
    private TopDownController controller;
    private Rigidbody2D rb;
    private Vector2 moveDireaction = Vector2.zero;
    private float speed = 3f;

    public void Awake()
    {
        controller = GetComponent<TopDownController>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = moveDireaction * speed;//나중에 속도를 곱해줘야 한다.
    }
    private void Start()
    {
        controller.OnMoveEvent += Move;
        controller.OnDashEvent += Dash;
    }

    private void Dash(bool push)
    {
        if(push)
        {
            speed = 10f; //나중에 값 바꾸자
        }
        else
        {
            speed = 3f;
        }
    }

    private void Move(Vector2 direaction)
    {
        moveDireaction=direaction;
    }
    
}


