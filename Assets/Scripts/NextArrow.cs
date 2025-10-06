using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class NextArrow : Clickable
{
    public event Action OnPressed;

    public override void OnPointerDown(PointerEventData eventData)
    {
        //base.OnPointerDown(eventData);
        Pressed();
    }

    private void Pressed()
    {
        OnPressed?.Invoke();
        SetDafaultSprite(true);
    }
}
