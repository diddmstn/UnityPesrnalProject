using System;
using Unity.VisualScripting;
using UnityEngine;

public class TopDownMovement :MonoBehaviour
{
    private TopDownController controller;
    private Rigidbody2D rb;
    private Vector2 moveDireaction = Vector2.zero;

    private CharacterStatHandler characterStatHandler;
    private float speed = 3f;

    public void Awake()
    {
        characterStatHandler= GetComponent<CharacterStatHandler>();
        controller = GetComponent<TopDownController>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = moveDireaction * speed;
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
            speed = characterStatHandler.characterInfo.runSpeed; 
        }
        else
        {
            speed = characterStatHandler.characterInfo.moveSpeed;
        }
    }

    private void Move(Vector2 direaction)
    {
        moveDireaction=direaction;
    }
    
}


