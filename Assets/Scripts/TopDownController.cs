using System;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    //InputSystem의 Action을 연경해주는 컨트롤러아닐까.
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<bool> OnDashEvent;

   // [HideInInspector]public bool isDash;

    //protected virtual void Update()
    //{
    //    if(isDash)
    //    {
    //        CallDashEvent();
    //    }
    //}
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

   

}
