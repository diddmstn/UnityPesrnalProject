using System;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<bool> OnDashEvent;
    public event Action<bool> OnEmotionEvent;

    public void  CallMoveEvent(Vector2 direaction)
    {
        OnMoveEvent?.Invoke(direaction);
    }

    public void CallLookEvent(Vector2 direaction)
    {
        OnLookEvent?.Invoke(direaction);
    }
    public void CallDashEvent(bool push)
    {
        OnDashEvent?.Invoke(push);
    }
    public void CallEmoteEvent(bool push)
    {
        OnEmotionEvent?.Invoke(push);
    }
}
