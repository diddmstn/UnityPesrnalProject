using System;
using Unity.VisualScripting;
using UnityEngine;

public class TopDownMovement :MonoBehaviour
{
    private TopDownController controller;
    private Rigidbody2D rb;
    private Vector2 moveDireaction = Vector2.zero;

    public void Awake()
    {
        controller = GetComponent<TopDownController>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = moveDireaction * 3f;//나중에 속도를 곱해줘야 한다.
    }
    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direaction)
    {
        moveDireaction=direaction;
    }
    
}


