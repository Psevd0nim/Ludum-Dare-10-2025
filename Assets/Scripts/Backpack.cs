using Sirenix.OdinInspector;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField, OnValueChanged("CreateBackpack")] private int _sizeBackpack;
    [SerializeField] private Transform _boardParent;
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Transform _contentParent;

    private Cell[,] _backpackBoard;

    private void Start()
    {
        CreateBackpack();
    }

    public void SetContentToBackpack(GameObject content)
    {
        content.transform.parent = _contentParent;
    }

    private void CreateBackpack()
    {
        if (_sizeBackpack < 0)
            return;

        if(_backpackBoard != null)
        {
            foreach(Cell cell in _backpackBoard)
            {
                if(cell != null) 
                    DestroyImmediate(cell.gameObject);
            }
        }

        if (_boardParent.childCount > 0)
        {
            foreach (Transform transform in _boardParent)
            {
                DestroyImmediate(transform.gameObject);
            }
        }

        _backpackBoard = new Cell[_sizeBackpack, _sizeBackpack];
        float cellSize = Factory.Instance != null? Factory.Instance.GetCellSize() : _cellPrefab.transform.localScale.x;
        float distance = (_sizeBackpack * cellSize) / 2 - cellSize / 2;
        Vector2 startPosSpawn = new Vector2(-distance, -distance);

        for(int i = 0; i < _sizeBackpack; i++)
        {
            Vector2 currentSpawnPos = new Vector2(startPosSpawn.x, startPosSpawn.y + cellSize * i);

            for(int j = 0; j < _sizeBackpack; j++)
            {
                Cell tempCell = Factory.Instance != null ? Factory.Instance.CreateCell() : Instantiate(_cellPrefab);
                tempCell.transform.parent = _boardParent;
                tempCell.Init(i, j);
                tempCell.transform.localPosition = new Vector2(currentSpawnPos.x + j * cellSize, currentSpawnPos.y);
                _backpackBoard[i, j] = tempCell;
            }
        }
    }
}
