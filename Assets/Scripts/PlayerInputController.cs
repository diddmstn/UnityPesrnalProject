using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController: TopDownController
{
    //InputSystem을 연결한 class를 상속받은 ...클래스? 왜 이렇게 나눠야 하는지는 아직 잘 모르겠다.
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized; // 뭐지,,입력 받는다는건가
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);

        newAim = (worldPos - (Vector2)transform.position).normalized;
        CallLookEvent(newAim);
    }
}


