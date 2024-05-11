using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController: TopDownController
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>(); // 뭐지,,입력 받는다는건가
        CallMoveEvent(moveInput);
    }
}
