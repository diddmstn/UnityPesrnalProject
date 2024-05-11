using System;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;
    private TopDownController controller;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
    }
    private void Start()
    {
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 vector)
    {
        RotateAim(vector);
    }

    private void RotateAim(Vector2 direction)
    {
        //Atan2 역탄젠트를 계산, Rad2Deg 각도를 라디안으로 변환
        float rotZ = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
        //.Abs 절대값을 반환한다 (= 양수만 나온다)
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
        
    }
}


