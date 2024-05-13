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
        if(Time.timeScale ==1)//캐릭터가 수정중이면 움직이지않는다.
        rb.velocity = moveDireaction * speed;
    }
    private void Start()
    {
        controller.OnMoveEvent += Move;
        controller.OnDashEvent += Dash;
    }

    private void Dash(bool push)
    {
        if(push)//대시 키를 누르고 있다면
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


