using System;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    //InputSystem의 Action을 연경해주는 컨트롤러아닐까.
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
   
    public void  CallMoveEvent(Vector2 direaction)
    {
        OnMoveEvent?.Invoke(direaction);
    }

    public void CallLookEvent(Vector2 direaction)
    {
        OnLookEvent?.Invoke(direaction);
    }
   

}
