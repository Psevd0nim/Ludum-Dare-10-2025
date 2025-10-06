using UnityEngine;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private protected SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _defSprite, _selectSprite;

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        SetDafaultSprite(false);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        SetDafaultSprite(true);
    }

    private protected void SetDafaultSprite(bool isDefault)
    {
        _spriteRenderer.sprite = isDefault ? _defSprite : _selectSprite;
    }
}