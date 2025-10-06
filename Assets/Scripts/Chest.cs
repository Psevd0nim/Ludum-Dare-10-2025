using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Chest : Clickable
{
    public event Action OnOpen;

    [Header("Chest Values")]
    [SerializeField] private Sprite _chestOpenSprite;
    [SerializeField] private Transform _cellSpawnPos;
    [SerializeField] private int _cellsCount;
    [SerializeField] private float _timeUnlock;
    [SerializeField] private Transform _chestContentParent;

    private List<CellChest> _cells = new List<CellChest>();

    private bool _isOpen;

    private int _currentActiveCellNum;

    public override void OnPointerDown(PointerEventData eventData)
    {
        //base.OnPointerDown(eventData);
        if (!_isOpen)
            OpenChest();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (!_isOpen)
            base.OnPointerEnter(eventData);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (!_isOpen)
            base.OnPointerExit(eventData);
    }

    private void OpenChest()
    {
        _isOpen = true;
        CreateCells();
        FillCells();
        _spriteRenderer.sprite = _chestOpenSprite;
        UnlockCells();
    }

    private void CreateCells()
    {
        float cellSize = Factory.Instance.GetCellSize();
        float xValue = _cellSpawnPos.localPosition.x - (_cellsCount * cellSize / 2f - cellSize / 2f);
        Vector2 startPos = new Vector2(xValue, 0);
        for (int i = 0; i < _cellsCount; i++)
        {
            Vector2 currentPos = new Vector2(startPos.x + cellSize * i, startPos.y);
            CellChest tempCell = Factory.Instance.CreateChestCell();
            _cells.Add(tempCell);
            tempCell.transform.parent = _cellSpawnPos;
            tempCell.transform.localPosition = currentPos;
        }
    }

    private void FillCells()
    {
        foreach (var cell in _cells)
        {
            Reliq reliq = Factory.Instance.CreateReliq();
            reliq.Init();
            reliq.transform.position = cell.transform.position;
            reliq.transform.parent = _chestContentParent;
            cell.SetReliq(reliq);
            reliq.SetTargetCell(cell);
            cell.SetInterReliq(false);
        }
    }

    private void UnlockCells()
    {
        _cells[_currentActiveCellNum].StartUnlockAnim();
        _cells[_currentActiveCellNum].OnUnlock += AfterUnlock;
    }

    private void AfterUnlock()
    {
        _cells[_currentActiveCellNum].SetInterReliq(true);
        _currentActiveCellNum++;
        if(_currentActiveCellNum < _cells.Count)
            UnlockCells();
        else
        {
            OnOpen?.Invoke();
        }
    }
}
