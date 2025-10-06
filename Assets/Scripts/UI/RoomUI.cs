using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomUI : MonoBehaviour
{
    public event Action<RoomUI> OnRoomChoosed;

    public StageType StageType { get { return _stageType; } }
    public RoomType RoomType { get; private set; }

    public List<RoomUI> RoomsForOpen => _listForOpen;

    [SerializeField] private StageType _stageType;
    [SerializeField] private Animator _animator;
    [SerializeField] private Image _viewImage;
    [SerializeField] private ViewConfig _viewConfig;
    [SerializeField] private GameObject _passedObject;

    [SerializeField] private List<RoomUI> _listForOpen;

    private Color _defColor;
    public bool IsOpen { get; private set; }
    public bool IsPassed { get; private set; }

    public void Init(RoomType roomType)
    {
        _viewImage.sprite = _viewConfig.GetSpriteByType(roomType);
        RoomType = roomType;
        _defColor = _viewImage.color;
    }

    public void SetAnimStatus(bool status)
    {
        if (!IsOpen || IsPassed)
            return;

        _animator.enabled = status;
        if (!status)
        {
            //_viewImage.gameObject.transform.localScale = Vector3.one;
            _viewImage.gameObject.transform.DOScale(Vector2.one, 0.15f);
        }
    }

    public void SetOpenStatus(bool status)
    {
        IsOpen = status;
        Color tempColor = _defColor;
        tempColor.a = status? 1 : 0.5f;
        _viewImage.color = tempColor;
    }

    public void SetPassed()
    {
        IsPassed = true;
        Color tempColor = _defColor;
        _viewImage.color = tempColor;
        _passedObject.SetActive(true);
    }

    public void Pressed()
    {
        if (IsOpen && !IsPassed)
            OnRoomChoosed?.Invoke(this);
    }
}
